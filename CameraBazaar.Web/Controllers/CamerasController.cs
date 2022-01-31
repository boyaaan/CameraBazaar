namespace CameraBazaar.Web.Controllers
{
    using Service;
    using Service.Models;
    using Models.Cameras;
    using Infrastructure.Constants;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using CameraBazaar.Service.Constants;

    public class CamerasController : Controller
    {
        private readonly ICameraService camera;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public CamerasController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, ICameraService camera)
        {
            this.roleManager = roleManager;
            this.camera = camera;
            this.userManager = userManager;
        }
        [Authorize]
        public IActionResult Add() => this.View();
        [Authorize]
        [HttpPost]
        public IActionResult Add(AddCameraViewModel cameraModel)
        {
            if (!ModelState.IsValid)
            {
                return View(cameraModel);
            }

            this.camera.Create(
               cameraModel.Make,
               cameraModel.Model,
               cameraModel.Price,
               cameraModel.Quantity,
               cameraModel.MinshutterSpeed,
               cameraModel.MinISO,
               cameraModel.MaxISO,
               cameraModel.IsFullFrame,
               cameraModel.VideoResolution,
               cameraModel.LightMeterings,
               cameraModel.Description,
               cameraModel.ImageURL,
               this.userManager.GetUserId(User));

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
        [HttpGet]
        [Authorize]
        public IActionResult All(int page = 1)
        {
            return GetCameras(page);
        }
        [HttpGet]
        [Authorize]
        public IActionResult Profile(int page = 1)
        {
            return GetCameras(page);
        }
        [Authorize]
        public IActionResult Details(int id)
        {
            var detail = this.camera.GetCameraDetail(id);
            return View(detail);
        }
        [Authorize]
        public IActionResult Delete(int id) => this.View(id);
        [Authorize]
        public IActionResult Destroy(int id)
        {
            this.camera.Destroy(id);
            return RedirectToAction(nameof(All));
        }
        [Authorize]
        public IActionResult Edit(int id)
        {
            var result = this.camera.GetCamera(id);

            if (result == null)
            {
                return NotFound();
            }

            return View(new GetEditModel
            {
                Id = result.Id,
                Model = result.Model,
                Make = result.Make,
                Price = result.Price,
                Quantity = result.Quantity,
                ImageURL = result.ImageURL
            });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(int id, GetEditModel models)
        {
            if (!ModelState.IsValid)
            {
                models.IsEdit = true;
                return View(models);
            }

            this.camera.Edit(
                       id,
                models.Make,
                models.Model,
                models.Price,
                models.Quantity,
                models.ImageURL);

            return RedirectToAction(nameof(All));
        }
        protected IActionResult GetCameras(int page = 1)
        {
            var camera = this.camera.GetAllCameras(page);

            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            var result = new CameraPageModel
            {
                Cameras = camera,
                CurrentPage = page,
                Url = HttpContext.Request.Path.Value,
                TotalPages = (int)Math.Ceiling(this.camera.Total() / PageSizeConastants.PageSize)
            };

            return View(result);
        }
    }
}

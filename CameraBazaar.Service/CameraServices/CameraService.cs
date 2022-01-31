namespace CameraBazaar.Service.CameraServices
{
    using Data;
    using Models;
    using Data.Models;
    using Data.Enums;
    using AutoMapper;
    using Constants;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper.QueryableExtensions;

    public class CameraService : ICameraService
    {
        private readonly CameraBazaarDbContext db;
        private readonly IMapper mapper;
        public CameraService(CameraBazaarDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public void Create(
               MakeModelTypes make,
               string model,
               decimal price,
               int quantity,
               int minShutterSpeed,
               MinISO minISO,
               int maxISO,
               bool isFullFrame,
               string videoResolution,
               IEnumerable<LightMetering> lightMeterings,
               string description,
               string imageURL,
               string userId)
        {
            var camera = new CameraModel
            {
                Make = make,
                Model = model,
                Price = price,
                Quantity = quantity,
                MinshutterSpeed = minShutterSpeed,
                MinISO = minISO,
                MaxISO = maxISO,
                IsFullFrame = isFullFrame,
                VideoResolution = videoResolution,
                LightMetering = (LightMetering)lightMeterings.Cast<int>().Sum(),
                Description = description,
                ImageURL = imageURL,
                UserId = userId
            };

            this.db.Add(camera);
            this.db.SaveChanges();
        }
        public void Destroy(int id)
        {
            var camera = this.db.Camera.Find(id);

            if (camera == null)
            {
                return;
            }

            this.db.Camera.Remove(camera);
            this.db.SaveChanges();
        }
        public void Edit(int id, MakeModelTypes make, string model, decimal price, int quantity, string imageUrl)
        {
            var camera = this.db.Camera.Find(id);

            if (camera == null)
            {
                return;
            }

            camera.Id = id;
            camera.Model = model;
            camera.Make = make;
            camera.Price = price;
            camera.Quantity = quantity;
            camera.ImageURL = imageUrl;

            this.db.SaveChanges();
        }
        public GetEditModel GetCamera(int id)
              => this.db
                    .Camera
                    .Where(c => c.Id == id)
                    .ProjectTo<GetEditModel>(this.mapper.ConfigurationProvider)
                    .FirstOrDefault();
        public IEnumerable<AllCamerasModel> GetAllCameras(int page = 1)
                => this.db
                    .Camera
                    .OrderByDescending(p => p.Id)
                    .Skip((page - 1) * (int)PageSizeConastants.PageSize)
                    .Take((int)PageSizeConastants.PageSize)
                    .ProjectTo<AllCamerasModel>(mapper.ConfigurationProvider)
                    .ToList();

        public CameraDetailsModel GetCameraDetail(int id)
        {
            var camera = this.db
                 .Camera
                 .OrderByDescending(p => p.Id)
                 .ProjectTo<CameraDetailsModel>(this.mapper.ConfigurationProvider)
                 .Where(x => id == x.Id)
                 .FirstOrDefault();

            if (camera == null)
            {
                return null;
            }
            return camera;
        }
        public int Total() => this.db.Camera.Count();
    }
}

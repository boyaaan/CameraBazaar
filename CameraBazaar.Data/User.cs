namespace CameraBazaar.Data
{
    using CameraBazaar.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    public class User : IdentityUser
    {
        public List<CameraModel> Cameras = new List<CameraModel>();
    }
}

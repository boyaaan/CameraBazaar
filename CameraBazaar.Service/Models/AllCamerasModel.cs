namespace CameraBazaar.Service.Models
{
    using Comon;
    using Data.Models;
    using Data.Enums;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AllCamerasModel : IMapFrom<CameraModel>
    {
        public int Id { get; set; }
        [Required]
        public MakeModelTypes Make { get; set; }
        [Required]
        [RegularExpression("[A-Z0-9-]+")]
        public string Model { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        [Range(0, 100)]
        public int Quantity { get; set; }

        [Required]
        public string ImageURL { get; set; }

        public List<AllCamerasModel> Cameras { get; set; } = new List<AllCamerasModel>();
    }
}

namespace CameraBazaar.Web.Models.Cameras
{
    using CameraBazaar.Data.Enums;
    using System.ComponentModel.DataAnnotations;

    public class AllCameraViewModel
    {
        public int Id { get; set; }
        [Required]
        public MakeModelTypes Make { get; set; }
        [Required]
        [RegularExpression("[A-Z0-9-]+")]
        public string Model { get; set; }
        [Required]
        [Range(0, 100)]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }

        [Required]
        public string ImageURL
        {
            get; set;
        }
    }
}

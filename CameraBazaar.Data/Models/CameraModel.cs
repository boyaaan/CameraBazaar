namespace CameraBazaar.Data.Models
{
    using CameraBazaar.Data.Enums;
    using System.ComponentModel.DataAnnotations;
    public class CameraModel
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
        [Range(1, 30)]
        public int MinshutterSpeed { get; set; }
        [Required]
        [Range(2000, 8000)]
        public int MaxshutterSpeed { get; set; }
        [Required]
        public MinISO MinISO { get; set; }
        [Required]
        [Range(200, 409600)]
        public int MaxISO { get; set; }
        [Required]
        public bool IsFullFrame { get; set; }
        [Required]
        [MaxLength(15)]
        public string VideoResolution { get; set; }
        [Required]
        public LightMetering LightMetering { get; set; }
        [Required]
        [StringLength(6000)]
        public string Description { get; set; }
        [Required]
        public string ImageURL { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}


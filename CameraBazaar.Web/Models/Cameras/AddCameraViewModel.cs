namespace CameraBazaar.Web.Models.Cameras
{
    using CameraBazaar.Data.Enums;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System;

    public class AddCameraViewModel
    {
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
        [Display(Name = "Min shutter Speed")]
        public int MinshutterSpeed { get; set; }
        [Required]
        [Range(2000, 8000)]
        [Display(Name = "Max shutter Speed")]
        public int MaxshutterSpeed { get; set; }
        [Required]
        [Display(Name = "Min ISO")]
        public MinISO MinISO { get; set; }
        [Required]
        [Range(200, 409600)]
        [Display(Name = "Max ISO")]
        public int MaxISO { get; set; }
        [Required]
        [Display(Name = "Full Frame")]
        public bool IsFullFrame { get; set; }
        [Required]
        [MaxLength(15)]
        [Display(Name = "Video Resolution")]
        public string VideoResolution { get; set; }
        [Required]
        [Display(Name = "Light Metering")]
        public IEnumerable<LightMetering> LightMeterings { get; set; }
        [Required]
        [StringLength(6000)]
        public string Description { get; set; }
        [Required]
        public string ImageURL { get; set; }
    }
}

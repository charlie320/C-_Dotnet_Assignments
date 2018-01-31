using System.ComponentModel.DataAnnotations;

namespace LostInWoods.Models

{
    public class Trail : BaseEntity {

        public int Id { get; set; }
        
        [Required]
        [MinLength(2, ErrorMessage = "Trail name must be at least 2 characters long")]
        [Display(Name = "Trail Name:")]
        public string TrailName {get; set;}

        [Required]
        [MinLength(10, ErrorMessage = "Description must be at least 10 characters long")]
        [Display(Name = "Description:")]
        public string Description {get; set;}

        [Required]
        [Display(Name = "Trail Length:")]
        public double TrailLength {get; set;}

        [Required]
        [Display(Name = "Elevation Change:")]
        public int ElevationChange {get; set;}

        [Required]
        [Display(Name = "Longitude:")]
        public double Longitude { get; set; }

        [Required]
        [Display(Name = "Longitude Hemisphere:")]
        public char LongitudeHemisphere { get; set; }

        [Required]
        [Display(Name = "Latitude:")]
        public double Latitude { get; set; }

        [Required]
        [Display(Name = "Latitude Hemisphere:")]
        public char LatitudeHemisphere { get; set; }
    }
}
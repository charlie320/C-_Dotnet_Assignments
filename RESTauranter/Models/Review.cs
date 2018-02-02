using System;
using System.ComponentModel.DataAnnotations;

namespace RESTauranter.Models

{
    public class Review : BaseEntity {
        [Key]
        public int review_id { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters long.")]
        [Display(Name = "Reviewer Name:")]
        public string ReviewerName {get; set;}

        [Required]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters long.")]
        [Display(Name = "Restaurant Name:")]
        public string RestaurantName {get; set;}

        [Required]
        [MinLength(10, ErrorMessage = "Review must be at least 10 characters.")]
        [Display(Name = "Review:")]
        public string ReviewText {get; set;}

        [Required]
        [Display(Name = "Date of Visit:")]
        [DataType(DataType.DateTime)]
        public DateTime DateVisit {get; set;}

        [Required]
        [Display(Name = "Stars")]
        public int Stars {get; set;}

        public DateTime created_at {get; set;}

        public DateTime updated_at {get; set;}

    }
}
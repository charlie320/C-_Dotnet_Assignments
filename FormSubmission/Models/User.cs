using System.ComponentModel.DataAnnotations;

namespace FormSubmission.Models

{
    public class User : BaseEntity {
        [Required]
        [MinLength(2, ErrorMessage = "First name must be at least 2 characters long")]
        [Display(Name = "First Name:")]
        public string FirstName {get; set;}

        [Required]
        [MinLength(2, ErrorMessage = "Last name must be at least 2 characters long")]
        [Display(Name = "Last Name:")]
        public string LastName {get; set;}
        
        [Required]
        [Range(13,125, ErrorMessage = "Age must at least 13 years old.")]
        [Display(Name = "Age:")]
        public int Age {get; set;}

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address:")]
        public string EmailAddress {get; set;}

        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
        public string Password {get; set;}

    }
}
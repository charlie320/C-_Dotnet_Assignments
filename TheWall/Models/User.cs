using System.ComponentModel.DataAnnotations;

namespace TheWall.Models

{
    public class User : BaseEntity {

        public int Id { get; set; }
        
        [Required]
        [MinLength(2, ErrorMessage = "First name must be at least 2 characters long")]
        [Display(Name = "First Name:")]
        public string FirstName {get; set;}

        [Required]
        [MinLength(2, ErrorMessage = "Last name must be at least 2 characters long")]
        [Display(Name = "Last Name:")]
        public string LastName {get; set;}

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address:")]
        public string EmailAddress {get; set;}

        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
        public string Password {get; set;}

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm password doesn't match.  Type again.")]
        [Display(Name = "Password Confirmation:")]
        public string ConfirmPassword { get; set; }

    }
}
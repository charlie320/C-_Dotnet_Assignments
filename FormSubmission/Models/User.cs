using System.ComponentModel.DataAnnotations;

namespace FormSubmission.Models

{
    public class User {
        [Required]
        [MinLength(2, ErrorMessage = "First name must be at least 2 characters long")]
        public string FirstName {get; set;}

        [Required]
        [MinLength(2, ErrorMessage = "Last name must me at least 2 characters long")]
        public string LastName {get; set;}
        
        [Required]
        [Range(13,110, ErrorMessage = "Age must at least 13 years old.")]
        public int Age {get; set;}

        [Required]
        [EmailAddress]
        public string EmailAddress {get; set;}

        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters.")]
        [DataType(DataType.Password)]
        public string Password {get; set;}

    }
}
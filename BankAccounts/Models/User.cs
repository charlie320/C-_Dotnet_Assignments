using System;
using System.ComponentModel.DataAnnotations;

namespace BankAccounts.Models

{
    public class User : BaseEntity {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "First name must be at least 2 characters long")]
        [Display(Name = "First Name:")]
        public string FirstName {get; set;}

        [Required]
        [MinLength(2, ErrorMessage = "Last name must be at least 2 characters long")]
        [Display(Name = "Last Name:")]
        public string LastName {get; set;}

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address:")]
        public string Email {get; set;}

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
        public string Password {get; set;}

        public DateTime created_at {get; set;}

        public DateTime updated_at {get; set;}
        

    }
}
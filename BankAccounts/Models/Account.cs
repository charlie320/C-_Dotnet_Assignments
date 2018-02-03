using System;
using System.ComponentModel.DataAnnotations;

namespace BankAccounts.Models

{
    public class Account : BaseEntity {
        [Key]
        public int AccountId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters long")]
        [Display(Name = "Name:")]
        public string Name {get; set;}

        [Required]
        [Range(1,10, ErrorMessage = "Level must be between 1 and 10.")]
        [Display(Name = "Level:")]
        public int Level {get; set;}

        [Display(Name = "Description:")]
        public string Description {get; set;}

        [Display(Name = "Dojo ID:")]
        public int dojos_id {get; set;}

        public DateTime created_at {get; set;}

        public DateTime updated_at {get; set;}

        
        public string DojoName {get; set;}

    }
}
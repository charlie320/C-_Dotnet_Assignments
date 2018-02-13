using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class Customer : BaseEntity {
        [Key]
        public int CustomerId {get; set;}

        [Required]
        [MinLength(2, ErrorMessage="First name must be at least 2 characters.")]
        [Display(Name = "First Name")]
        public string FirstName {get; set;}

        [Required]
        [MinLength(2, ErrorMessage="Last name must be at least 2 characters.")]
        [Display(Name = "Last Name")]
        public string LastName {get; set;}

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email {get; set;}

        public DateTime created_at {get; set;}

        public DateTime updated_at {get; set;}

        public List<Order> OrdersPlaced {get; set;}

        public Customer() {
            OrdersPlaced = new List<Order>();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class Product : BaseEntity {
        [Key]
        public int ProductId {get; set;}

        [Required]
        [MinLength(2, ErrorMessage="Name must be at least 2 characters.")]
        [Display(Name = "Product Name")]
        public string Name {get; set;}

        [Required]
        [MinLength(10, ErrorMessage="Description must be at least 10 characters.")]
        [Display(Name = "Product Name")]
        public string Description {get; set;}

        public string ImageUrl {get; set;}

        public int QuantityAvailable {get; set;}
        
        public DateTime created_at {get; set;}

        public DateTime updated_at {get; set;}
    }
}
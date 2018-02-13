using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class Order : BaseEntity {
        [Key]
        public int OrderId {get; set;}

        [Required]
        [Display(Name = "Customer")]
        public int CustomerId {get; set;}

        public Customer Customer {get; set;}

        [Required]
        [Display(Name = "Product")]
        public int ProductId {get; set;}

        public Product Product {get; set;}

        [Required]
        [Display(Name = "Quantity")]
        public int Quantity {get; set;}

        public DateTime created_at {get; set;}

        public DateTime updated_at {get; set;}

    }
}
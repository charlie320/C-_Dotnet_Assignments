using System;
using System.ComponentModel.DataAnnotations;

namespace BankAccounts.Models

{
    public class Transaction : BaseEntity {
        [Key]
        public int TransId { get; set; }

        [Required]   
        [Range(-999999999, 999999999)]
        [Display(Name = "Amount")]
        public double Amount {get; set;}

        public DateTime created_at {get; set;}

        public DateTime updated_at {get; set;}
        
        public int UserId { get; set; }
    }
}
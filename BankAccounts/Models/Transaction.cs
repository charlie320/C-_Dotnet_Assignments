using System;
using System.ComponentModel.DataAnnotations;

namespace BankAccounts.Models

{
    public class Transaction : BaseEntity {
        [Key]
        public int TransId { get; set; }

        public string Amount {get; set;}

        public DateTime created_at {get; set;}

        public DateTime updated_at {get; set;}
        
        public int UserId { get; set; }
    }
}
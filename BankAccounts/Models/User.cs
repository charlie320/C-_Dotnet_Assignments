using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankAccounts.Models

{
    public class User : BaseEntity {
        [Key]
        public int UserId { get; set; }

        public string FirstName {get; set;}

        public string LastName {get; set;}

        public string Email {get; set;}

        public string Password {get; set;}

        public double AccountBalance {get; set;}

        public DateTime created_at {get; set;}

        public DateTime updated_at {get; set;}
        
        public List<Transaction> Transactions {get; set;}

        public User() {
            Transactions = new List<Transaction>();
        }

    }
}
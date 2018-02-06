using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models

{
    public class Wedding : BaseEntity {
        [Key]
        public int WeddingId { get; set; }

        public string WedderOne {get; set;}

        public string WedderTwo {get; set;}

        public DateTime Date {get; set;}

        public string WeddingAddress {get; set;}

        public int PlannerId {get; set;}

        public User Planner {get; set;}

        public DateTime created_at {get; set;}

        public DateTime updated_at {get; set;}

        public List<WeddingConfirmation> GuestsAttending {get; set;}
        
        public Wedding() {
            GuestsAttending = new List<WeddingConfirmation>();
        }

    }
}
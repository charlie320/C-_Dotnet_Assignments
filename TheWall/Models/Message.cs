using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DbConnection;

namespace TheWall.Models

{
    public class Message : BaseEntity {

        private readonly DbConnector _dbConnector;

        public int Id { get; set; }

        [Required]
        [MinLength(15, ErrorMessage = "Message must be at least 15 characters long")]
        [Display(Name = "Message:")]
        public string MessageText {get; set;}

        public int UserId {get; set;}

    }
}
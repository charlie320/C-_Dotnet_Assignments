using System.ComponentModel.DataAnnotations;

namespace TheWall.Models

{
    public class Message : BaseEntity {
        public int Id { get; set; }

        [Required]
        [MinLength(15, ErrorMessage = "Message must be at least 15 characters long")]
        [Display(Name = "Message:")]
        public string MessageText {get; set;}

        public User User {get; set;}
    }
}
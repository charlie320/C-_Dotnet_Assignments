using System.ComponentModel.DataAnnotations;

namespace TheWall.Models

{
    public class Comment : BaseEntity {
        public int Id { get; set; }

        [Required]
        [MinLength(15, ErrorMessage = "Comment must be at least 15 characters long")]
        [Display(Name = "Comment:")]
        public string CommentText {get; set;}

        public int MessageId {get; set;}
        
        public int UserId {get; set;}
    }
}
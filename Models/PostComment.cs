using System.ComponentModel.DataAnnotations;

namespace FeedBackWebApi.Models
{
    public class PostComment
    {
        public int Id { get; set; } 
        [MaxLength(150)]
        public string FullName { get; set; } 
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } =  DateTime.UtcNow;

        // navigation 
        List<PostReaction> PostReactions { get; set; }
        
    }
}

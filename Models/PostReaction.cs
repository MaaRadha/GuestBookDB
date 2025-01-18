using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace FeedBackWebApi.Models
{
    public class PostReaction
    {
        public int Id { get; set; }
        public int Likes { get; set; } = 0;
        public int Dislikes { get; set; } = 0;
        public int Hearts { get; set; } = 0;

        // Navigation property 
        public int PostCommentId { get; set; } // Foreign key 
        

    }
}

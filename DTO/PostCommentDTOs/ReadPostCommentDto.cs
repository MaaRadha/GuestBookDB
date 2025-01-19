using FeedBackWebApi.Models;
using System.ComponentModel.DataAnnotations;

namespace FeedBackWebApi.DTO.PostCommentDTOs
{
    public class ReadPostCommentDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string FullName { get; set; }
        [MaxLength(1500)]
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
       
    }
}

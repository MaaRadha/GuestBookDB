namespace FeedBackWebApi.DTO.PostReactionDTOs
{
    public class PostReadReactionDto
    {
        public int Id { get; set; }
        public int Likes { get; set; } = 0;
        public int Dislikes { get; set; } = 0;
        public int Hearts { get; set; } = 0;

    }
}

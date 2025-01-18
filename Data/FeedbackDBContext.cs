using FeedBackWebApi.Models;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace FeedBackWebApi.Data
{
    public class FeedbackDBContext : DbContext
    {
        // DbSet
        public DbSet<PostComment> PostComments { get; set; }
        public DbSet<PostReaction> PostReactions { get; set; }

        // Constructure
        public FeedbackDBContext(DbContextOptions<FeedbackDBContext> options) : base(options) { }

        // overrides
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<PostComment> postComments = new();
            List<PostReaction> postReactions = new();

            postComments.Add(new() { Id = 1, FullName ="Astri05", Content = "Keep going", CreatedAt = DateTime.Now.AddDays(-1) });
            postComments.Add(new() { Id = 2, FullName = "Martin", Content = "Looks ok but more things i can see to work on ", CreatedAt = DateTime.Now.AddDays(-2) });

            postReactions.Add(new() {Id = 1, Likes = 1, Dislikes = 0, Hearts = 0, PostCommentId = 2  });
            postReactions.Add(new() { Id = 2, Likes = 1, Dislikes = 0, Hearts = 0, PostCommentId = 1 });

            modelBuilder.Entity<PostComment>().HasData(postComments);
            modelBuilder.Entity<PostReaction>().HasData(postReactions);

        }

    }
}

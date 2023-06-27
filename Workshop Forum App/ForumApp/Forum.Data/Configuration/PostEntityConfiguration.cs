using Forum.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forum.Data.Configuration
{
    public class PostEntityConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasData(SeedPosts());
        }

        private ICollection<Post> SeedPosts()
        {
            var posts = new HashSet<Post>();

            Post post = new Post()
            {
                Title = "My first post",
                Content = "This is my first post!"
            };
            posts.Add(post);

            post = new Post()
            {
                Title = "My second post",
                Content = "This is my second post!"
            };
            posts.Add(post);

            post = new Post()
            {
                Title = "My third post",
                Content = "This is my third post!"
            };
            posts.Add(post);

            return posts;
        }
    }
}

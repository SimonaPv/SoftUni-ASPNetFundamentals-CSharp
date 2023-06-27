using Forum.Data;
using Forum.Services.Interfaces;
using Forum.ViewModels.Posts;
using Microsoft.EntityFrameworkCore;
using Forum.Data.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Forum.Services
{
    public class PostService : IPostService
    {
        private readonly ForumAppDbContext _dbContext;

        public PostService(ForumAppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task AddPostAsync(PostAddViewModel postModel)
        {
            Post newPost = new Post()
            {
                Title = postModel.Title,
                Content = postModel.Content
            };

            await this._dbContext.Posts.AddAsync(newPost);
            await this._dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<PostListViewModel>> ListAllAsync()
        {
            List<Post> allPostsEntities = await _dbContext.Posts
                .ToListAsync();

            List<PostListViewModel> allPosts = new List<PostListViewModel>();

            foreach (var post in allPostsEntities)
            {
                allPosts.Add(new PostListViewModel
                {
                    Id = post.Id.ToString(),
                    Title = post.Title,
                    Content = post.Content
                });
            }

            return allPosts;
        }

        public async Task<PostAddViewModel> GetForEditOrDeleteByIdAsync(string id)
        {
            Post postToEdit = await this._dbContext
                .Posts
                .FirstAsync(p => p.Id.ToString() == id);

            return new PostAddViewModel()
            {
                Title = postToEdit.Title,
                Content = postToEdit.Content
            };
        }

        public async Task EditByIdAsync(string id, PostAddViewModel postEditedModel)
        {
            Post postToEdit = await this._dbContext
                .Posts
                .FirstAsync(p => p.Id.ToString() == id);

            postToEdit.Title = postEditedModel.Title;
            postToEdit.Content = postEditedModel.Content;

            await this._dbContext.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(string id)
        {
            Post postToDelete = await this._dbContext
                .Posts
                .FirstAsync(p => p.Id.ToString() == id);

            this._dbContext.Posts.Remove(postToDelete);
            await this._dbContext.SaveChangesAsync();
        }
    }
}

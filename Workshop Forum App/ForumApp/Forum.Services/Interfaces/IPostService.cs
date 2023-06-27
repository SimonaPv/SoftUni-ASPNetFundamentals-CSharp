using Forum.ViewModels.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Services.Interfaces
{
    public interface IPostService
    {
        Task<ICollection<PostListViewModel>> ListAllAsync();

        Task AddPostAsync(PostAddViewModel postModel);

        Task<PostAddViewModel> GetForEditOrDeleteByIdAsync(string id);

        Task EditByIdAsync(string id, PostAddViewModel postEditedModel);

        Task DeleteByIdAsync(string id);
    }
}

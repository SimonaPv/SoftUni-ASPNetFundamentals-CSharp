using Forum.Services.Interfaces;
using Forum.ViewModels.Posts;
using Microsoft.AspNetCore.Mvc;

namespace ForumApp.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            this._postService = postService;
        }

        public async Task<IActionResult> All()
        {
            var allPosts = await this._postService.ListAllAsync();

            return View(allPosts);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(PostAddViewModel postModel)
        {
            if (!ModelState.IsValid)
            {
                return View(postModel);
            }

            try
            {
                await this._postService.AddPostAsync(postModel);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occurred, while adding your post!");
                return View(postModel);
            }

            return RedirectToAction("All", "Post");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            try
            {
                PostAddViewModel postModel =
                    await this._postService.GetForEditOrDeleteByIdAsync(id);

                return View(postModel);
            }
            catch (Exception)
            {
                return this.RedirectToAction("All", "Post");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, PostAddViewModel postModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(postModel);
            }

            try
            {
                await this._postService.EditByIdAsync(id, postModel);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occurred while updating your post!");

                return View(postModel);
            }

            return RedirectToAction("All", "Post");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await this._postService.DeleteByIdAsync(id);
            }
            catch (Exception)
            {

            }

            return RedirectToAction("All", "Post");
        }
    }
}

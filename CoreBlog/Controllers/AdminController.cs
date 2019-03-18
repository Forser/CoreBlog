using CoreBlog.Models;
using CoreBlog.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlog.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IPostRepository repository;

        public AdminController(IPostRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index() => View(new PostsListViewModel
        {
            Posts = repository.Posts.OrderByDescending(p => p.PostId)
        });

        public IActionResult NewPost()
        {
            var viewModel = new PostViewModel();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult NewPost(PostViewModel postViewModel)
        {
            if (ModelState.IsValid)
            {
                repository.CreateNewBlogPost(postViewModel.Post, postViewModel.Category);
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("error", "ID wasn't available");
            return View(postViewModel);
        }

        public IActionResult DeletePost(int postId = 0)
        {
            Post deletedPost = repository.DeleteBlogPost(postId);

            if (deletedPost != null)
            {
                TempData["message"] = $"{deletedPost.Title} was deleted";
            }

            return RedirectToAction("Index");
        }

        public IActionResult EditPost(int id)
        {
            var result = repository.GetBlogPostById(id);

            if(result == null) { return View("PostNotFound"); }

            return View(result);
        }

        [HttpPost]
        public IActionResult EditPost(PostViewModel postViewModel)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateBlogPost(postViewModel);
                return RedirectToAction("Index", "Post");
            }

            ModelState.AddModelError("error", "Model Error");
            return View(postViewModel);
        }

        public IActionResult Unpublish(int postId)
        {
            Post post = repository.UnPublishPost(postId);

            if (post != null)
            {
                TempData["message"] = $"{post.Title} was unpublished";
            }

            return RedirectToAction("Index");
        }

        public IActionResult Publish(int postId)
        {
            Post post = repository.PublishPost(postId);

            if (post != null)
            {
                TempData["message"] = $"{post.Title} was published";
            }

            return RedirectToAction("Index");
        }
    }
}
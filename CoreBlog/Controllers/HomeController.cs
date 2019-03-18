using CoreBlog.Models;
using CoreBlog.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreBlog.Controllers
{
    public class HomeController : Controller
    {
        private IPostRepository repository;

        public HomeController(IPostRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index() => View();

        [ActionName("Category")]
        public ViewResult ViewPostsByCategory(string id)
        {
            var _category = repository.Categories.Where(p => p.CategoryName == id).Select(p => p.CategoryId).FirstOrDefault();
            PostsListViewModel Posts = new PostsListViewModel { Posts = repository.Posts.Where(p => p.CategoryId == _category)
                .Where(u=>u.Published == true).OrderByDescending(p => p.PostId) };

            return View("List", Posts);
        }

        [ActionName("ViewPost")]
        public IActionResult ViewPostBySlug(string id)
        {
            var result = repository.GetBlogPostByUrlSlug(id);

            if (result == null) { return View("PostNotFound"); }

            return View(result);
        }

        public ViewResult List() => View(new PostsListViewModel
        {
            Posts = repository.Posts.Where(p => p.Published == true).OrderByDescending(p => p.PostId)
        });
    }
}
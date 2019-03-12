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

        public ViewResult ViewPost(int? id)
        {
            var result = repository.GetBlogPost(id);

            if(result != null) { return View(result); }

            return View();
        }

        public ViewResult List() => View(new PostsListViewModel
        {
            Posts = repository.Posts.OrderBy(p => p.PostId).Where(p => p.Published == true)
        });
    }
}
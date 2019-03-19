using CoreBlog.Models;
using CoreBlog.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreBlog.Controllers
{
    public class HomeController : Controller
    {
        private IPostRepository repository;
        public int PageSize = 4;

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

        public ViewResult List(string category, int postsPage = 1)
        {
            Category _category = new Category();
            if (category != null)
            {
                _category = repository.Categories.Where(e => e.CategoryName == category).SingleOrDefault();
            }

            return View(new PostsListViewModel {
                Posts = repository.Posts.Where(p => p.Published == true)
                    .Where(p => category == null || p.Category == _category)
                    .OrderByDescending(p => p.PostId)
                    .Skip((postsPage - 1) * PageSize)
                    .Take(PageSize), PagingInfo = new PagingInfo
                    {
                        CurrentPage = postsPage,
                        ItemsPerPage = PageSize,
                        TotalItems = category == null ?
                        repository.Posts.Where(p => p.Published == true).Count() : repository.Posts.Where(e => e.Category == _category).Where(p => p.Published == true).Count()
                    },
                CurrentCategory = category
            });
        }
    }
}
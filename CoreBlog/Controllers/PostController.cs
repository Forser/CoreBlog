﻿using CoreBlog.Models;
using CoreBlog.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlog.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostRepository repository;

        public PostController(IPostRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index() => View();

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
            }
            return RedirectToAction("List", "Home");
        }

        public IActionResult DeletePost(int id = 0)
        {
            if(id >= 0)
            { 
                repository.DeleteBlogPost(id);
                return RedirectToAction("List", "Home");
            }

            ModelState.AddModelError("error", "ID wasn't available");
            return View();
        }
    }
}
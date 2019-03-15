using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using CoreBlog.Models;
using System.Linq;
using System;
using CoreBlog.Controllers;
using CoreBlog.Models.ViewModels;

namespace CoreBlog.Tests
{
    public class BlogPostTests
    {
        [Fact]
        public void Get_All_Blog_Posts()
        {
            // Arrange
            Mock<IPostRepository> mock = new Mock<IPostRepository>();
            mock.SetupGet(m => m.Posts).Returns(new Post[]
            {
                new Post
                {
                    PostId = 1,
                    Title = "My First Title",
                    Content = "Lorem Ipsum",
                    ShortContent = "Lorem",
                    MetaDataDescription = "Lorem, Ipsum",
                    UrlSlug = "/my_first_title",
                    Published = true,
                    PostCreatedAt = DateTime.Parse("2018-12-24 12:00"),
                    User = new User { AuthorName = "Marcus Eklund" },
                    Blog = new Blog { BlogId = 1 },
                    Category = new Category { CategoryName = "Development " }
                },
                new Post
                {
                    PostId = 2,
                    Title = "My Second Title",
                    Content = "Ipsum Lorem",
                    ShortContent = "Ipsum",
                    MetaDataDescription = "Ipsum, Lorem",
                    UrlSlug = "/my_second_title",
                    Published = false,
                    PostCreatedAt = DateTime.Now,
                    User = new User { AuthorName = "Marcus Eklund" },
                    Blog = new Blog { BlogId = 1 },
                    Category = new Category { CategoryName = "Development " }
                },
                new Post
                {
                    PostId = 3,
                    Title = "My Third Title",
                    Content = "Icky Lorem",
                    ShortContent = "Snicky",
                    MetaDataDescription = "Scooby",
                    UrlSlug = "/my_third_title",
                    Published = true,
                    PostCreatedAt = DateTime.Now,
                    User = new User { AuthorName = "Marcus Eklund" },
                    Blog = new Blog { BlogId = 1 },
                    Category = new Category { CategoryName = "Development " }
                }
            }.AsQueryable<Post>);

            // Act
            HomeController controller = new HomeController(mock.Object);
            PostsListViewModel result = controller.List().ViewData.Model as PostsListViewModel;

            // Assert
            Post[] postsArray = result.Posts.Where(p => p.Published == true).ToArray();
            Assert.True(postsArray.Length == 2);
            Assert.Equal("My Third Title", postsArray[0].Title);
        }

        [Fact]
        public void Get_One_Blog_Post_ByUrlSlug()
        {
            // Arrange
            Mock<IPostRepository> mock = new Mock<IPostRepository>();

            var mockPost = new Post
            {
                PostId = 1,
                Title = "My First Title",
                Content = "Lorem Ipsum",
                ShortContent = "Lorem",
                MetaDataDescription = "Lorem, Ipsum",
                UrlSlug = "my_first_title",
                Published = true,
                PostCreatedAt = DateTime.Parse("2018-12-24 12:00"),
                User = new User { AuthorName = "Marcus Eklund" },
                Blog = new Blog { BlogId = 1 }
            };

            var mockCategory = new Category
            {
                CategoryId = 1,
                CategoryName = "Development",
                UrlSlug = "development"
            };

            var mockViewPost = new PostViewModel
            {
                Post = mockPost,
                Category = mockCategory
            };

            mock.Setup(repo => repo.GetBlogPostByUrlSlug("my_first_title", true)).Returns(mockViewPost);
            HomeController target = new HomeController(mock.Object);

            // Act
            var result = target.ViewPostBySlug("my_first_title");

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(mockViewPost, viewResult.ViewData.Model);
        }

        [Fact]
        public void Return_Post_Not_Found_ByUrlSlug()
        {
            // Arrange
            Mock<IPostRepository> mock = new Mock<IPostRepository>();
            var mockPost = new Post
            {
                PostId = 3,
                Title = "My First Title",
                Content = "Lorem Ipsum",
                ShortContent = "Lorem",
                MetaDataDescription = "Lorem, Ipsum",
                UrlSlug = "my_first_title",
                Published = true,
                PostCreatedAt = DateTime.Parse("2018-12-24 12:00"),
                User = new User { AuthorName = "Marcus Eklund" },
                Blog = new Blog { BlogId = 1 },
                Category = new Category { CategoryName = "Development " }
            };
            mock.Setup(repo => repo.GetBlogPostByUrlSlug("my_second_title", true)).Returns((PostViewModel)null);
            var target = new HomeController(mock.Object);

            // Act
            var result = target.ViewPostBySlug("my_second_title");

            // Assert
            Assert.IsType<ViewResult>(result);
            var contentResult = result as ViewResult;
            Assert.Equal("PostNotFound", contentResult.ViewName);
        }

        private T GetViewModel<T>(IActionResult result) where T : class
        {
            return (result as ViewResult)?.ViewData.Model as T;
        }
    }
}
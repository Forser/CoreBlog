using System;
using System.Linq;
using CoreBlog.Controllers;
using CoreBlog.Models;
using CoreBlog.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CoreBlog.Tests
{
    public class AdminContollerTests
    {
        [Fact]
        public void Post_New_Blog_Post()
        {
            // Arrange
            Mock<IPostRepository> mock = new Mock<IPostRepository>();
            var mockPostViewModel = new PostViewModel();
            
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
                Blog = new Blog { BlogId = 1 }
            };

            var mockCategory = new Category { CategoryName = "Test, Kalle, Anka" };

            mockPostViewModel = new PostViewModel
            {
                Post = mockPost,
                Category = mockCategory
            };

            var controller = new PostController(mock.Object);

            // Act
            var target = controller.NewPost(mockPostViewModel);

            // Assert
            var routeResult = Assert.IsType<RedirectToActionResult>(target);
            Assert.Equal("List", routeResult.ActionName);
        }

        [Fact]
        public void Edit_One_Blog_Post()
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
                CategoryId = 2,
                CategoryName = "Rant",
                UrlSlug = "rant"

            };

            PostViewModel mockView = new PostViewModel
            {
                Post = mockPost,
                Category = mockCategory
            };

            mock.Setup(m => m.GetBlogPostByUrlSlug("my_first_title", false)).Returns(mockView);

            // Act
            var fetchController = new PostController(mock.Object);

            var modifiedPost = new Post
            {
                PostId = mockView.Post.PostId,
                Title = "My New Title",
                Content = "Kalle Anka",
                ShortContent = mockView.Post.ShortContent,
                MetaDataDescription = "Kalle Anka",
                UrlSlug = "my_new_title",
                Published = false,
                PostCreatedAt = mockView.Post.PostCreatedAt,
                ModifiedLastAt = DateTime.Now,
                User = mockView.Post.User,
                Blog = mockView.Post.Blog
            };

            var modifiedCategory = new Category
            {
                CategoryId = mockView.Category.CategoryId,
                CategoryName = "Rants Worse",
                UrlSlug = "rants_worse"
            };

            var modifiedView = new PostViewModel
            {
                Post = modifiedPost,
                Category = modifiedCategory
            };

            var result = fetchController.EditPost(modifiedView);

            // Assert
            var routeResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", routeResult.ActionName);
            Assert.NotEqual(modifiedView.Post.Title, mockView.Post.Title);
        }

        [Fact]
        public void Delete_One_Blog_Post()
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
            var controller = new PostController(mock.Object);
            var homeController = new HomeController(mock.Object);

            // Act
            var target = controller.DeletePost(2);
            var result = homeController.List().ViewData.Model as PostsListViewModel;

            // Assert
            Post[] postsArray = result.Posts.Where(p => p.Published == true).ToArray();
            var routeResult = Assert.IsType<RedirectToActionResult>(target);
            Assert.Equal("List", routeResult.ActionName);
            Assert.True(postsArray.Count() == 2);
        }
    }
}
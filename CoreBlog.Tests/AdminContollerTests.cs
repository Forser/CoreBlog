using System;
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

            // Act

            // Assert

        }

        [Fact]
        public void Delete_One_Blog_Post()
        {
            // Arrange

            // Act

            // Assert

        }

        [Fact]
        public void Delete_Several_Blog_Posts()
        {
            // Arrange

            // Act

            // Assert

        }
    }
}
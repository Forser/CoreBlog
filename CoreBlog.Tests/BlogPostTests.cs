using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using CoreBlog.Models;
using System.Linq;
using System;
using CoreBlog.Controllers;
using CoreBlog.Models.ViewModels;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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
                    Author = new User { UserId = 1 },
                    Blog = new Blog { BlogId = 1 }
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
                    Author = new User { UserId = 1 },
                    Blog = new Blog { BlogId = 1 }
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
                    Author = new User { UserId = 1 },
                    Blog = new Blog { BlogId = 1 }
                }
            }.AsQueryable<Post>);

            // Act
            HomeController controller = new HomeController(mock.Object);
            PostsListViewModel result = controller.List().ViewData.Model as PostsListViewModel;

            // Assert
            Post[] postsArray = result.Posts.Where(p => p.Published == true).ToArray();
            Assert.True(postsArray.Length == 2);
            Assert.Equal("My Third Title", postsArray[1].Title);
        }

        [Fact]
        public void Get_One_Blog_Post()
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
                UrlSlug = "/my_first_title",
                Published = true,
                PostCreatedAt = DateTime.Parse("2018-12-24 12:00"),
                Author = new User { UserId = 1 },
                Blog = new Blog { BlogId = 1 }
            };
            mock.Setup(repo => repo.GetBlogPost(1)).Returns(mockPost);
            HomeController target = new HomeController(mock.Object);

            // Act
            var result = target.ViewPost(1);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(mockPost, viewResult.ViewData.Model);
        }

        [Fact]
        public void Post_New_Blog_Post()
        {
            // Arrange
            
            // Act

            // Assert

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

        private T GetViewModel<T>(IActionResult result) where T : class
        {
            return (result as ViewResult)?.ViewData.Model as T;
        }
    }
}
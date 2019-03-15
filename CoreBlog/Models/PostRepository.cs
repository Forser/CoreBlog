using CoreBlog.Models.ViewModels;
using System;
using System.Linq;

namespace CoreBlog.Models
{
    public class PostRepository : IPostRepository
    {
        private BlogDbContext context;

        public PostRepository(BlogDbContext ctx) { context = ctx; }

        public IQueryable<Post> Posts => context.Posts;

        public void CreateNewBlogPost(Post post, Category category)
        {
            var user = context.Users.Where(u => u.AuthorName == "Marcus Eklund").Select(a => a.UserId).FirstOrDefault();
            var blog = context.Blogs.Where(a => a.BlogId == a.Users.Where(b => b.UserId == user).Select(c => c.BlogForeignKey)
            .FirstOrDefault()).Select(d => d.BlogId).FirstOrDefault();
            var shortcontent = post.Content.Substring(0, 55) + "...";

            context.Posts.Add
                (new Post {
                    Title = post.Title,
                    Content = post.Content,
                    ShortContent = shortcontent,
                    MetaDataDescription = post.MetaDataDescription,
                    UrlSlug = post.UrlSlug,
                    Published = post.Published,
                    PostCreatedAt = DateTime.Now,
                    AuthorForeignKey = user,
                    BlogForeignKey = blog,
                    Category = new Category { CategoryName = category.CategoryName }
                });
            context.SaveChanges();
        }

        public void DeleteBlogPost(int postId)
        {
            Post dbPost = context.Posts.SingleOrDefault(p => p.PostId == postId);

            if (dbPost != null)
            {
                context.Posts.Remove(dbPost);
                context.SaveChanges();
            }
        }

        public Post GetBlogPostById(int? postId)
        {
            Post dbPost = new Post();

            if (postId != 0)
            {
                dbPost = context.Posts.SingleOrDefault(p => p.PostId == postId);
            }

            return dbPost;
        }

        public PostViewModel GetBlogPostByUrlSlug(string urlSlug, bool published = true)
        {
            PostViewModel dbPost = new PostViewModel();
            var post = new Post();


            if (!string.IsNullOrEmpty(urlSlug))
            {
                if (published == true)
                {
                    post = context.Posts.Where(c => c.Published == published).SingleOrDefault(p => p.UrlSlug == urlSlug);
                }
                else
                {
                    post = context.Posts.SingleOrDefault(p => p.UrlSlug == urlSlug);
                }
                var categories = context.Categories.Single(p => p.CategoryId == post.CategoryId);
                dbPost.Post = post;
                dbPost.Category = categories;
                return dbPost;
            }

            return null;
        }

        public void UpdateBlogPost(PostViewModel post)
        {
            context.Posts.Update(post.Post);
            context.Categories.Update(post.Category);

            context.SaveChanges();
        }
    }
}

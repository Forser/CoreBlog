using System;
using System.Linq;

namespace CoreBlog.Models
{
    public class PostRepository : IPostRepository
    {
        private BlogDbContext context;

        public PostRepository(BlogDbContext ctx) { context = ctx; }

        public IQueryable<Post> Posts => context.Posts;

        public void CreateNewBlogPost(Post post)
        {
            throw new NotImplementedException();
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

        public Post GetBlogPostByUrlSlug(string urlSlug)
        {
            Post dbPost = new Post();

            if (!string.IsNullOrEmpty(urlSlug))
            {
                dbPost = context.Posts.SingleOrDefault(p => p.UrlSlug == urlSlug);
            }

            return dbPost;
        }

        public void UpdateBlogPost(Post post)
        {
            throw new NotImplementedException();
        }
    }
}

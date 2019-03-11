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
            Post dbPost = context.Posts.FirstOrDefault(p => p.PostId == postId);
            if (dbPost != null)
            {
                context.Posts.Remove(dbPost);
                context.SaveChanges();
            }
        }

        public Post GetBlogPost(int postId)
        {
            Post dbPost = new Post();

            if (postId != 0)
            {
                dbPost = context.Posts.FirstOrDefault(p => p.PostId == postId);
            }

            return dbPost;
        }

        public void UpdateBlogPost(Post post)
        {
            throw new NotImplementedException();
        }
    }
}

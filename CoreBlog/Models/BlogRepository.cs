using System.Linq;

namespace CoreBlog.Models
{
    public class BlogRepository : IBlogRepository
    {
        private BlogDbContext context;

        public BlogRepository(BlogDbContext ctx) { context = ctx; }

        public IQueryable<Blog> Blogs => context.Blogs;

        public Blog GetBlog(Blog blog) { return blog; }
    }
}
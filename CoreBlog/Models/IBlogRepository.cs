using System.Linq;

namespace CoreBlog.Models
{
    public interface IBlogRepository
    {
        IQueryable<Blog> Blogs { get; }

        Blog GetBlog(Blog blog);
    }
}
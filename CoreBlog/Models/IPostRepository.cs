using System.Linq;

namespace CoreBlog.Models
{
    public interface IPostRepository
    {
        IQueryable<Post> Posts { get; }

        void CreateNewBlogPost(Post post);

        void DeleteBlogPost(int postId);

        Post GetBlogPost(int postId);

        void UpdateBlogPost(Post post);
    }
}
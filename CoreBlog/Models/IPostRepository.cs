using System.Linq;

namespace CoreBlog.Models
{
    public interface IPostRepository
    {
        IQueryable<Post> Posts { get; }

        void CreateNewBlogPost(Post post);

        void DeleteBlogPost(int postId);

        Post GetBlogPostById(int? postId);

        Post GetBlogPostByUrlSlug(string urlSlug);

        void UpdateBlogPost(Post post);
    }
}
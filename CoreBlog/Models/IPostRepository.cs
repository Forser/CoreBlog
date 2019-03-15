using CoreBlog.Models.ViewModels;
using System.Linq;

namespace CoreBlog.Models
{
    public interface IPostRepository
    {
        IQueryable<Post> Posts { get; }

        void CreateNewBlogPost(Post post, Category category);

        void DeleteBlogPost(int postId);

        Post GetBlogPostById(int? postId);

        PostViewModel GetBlogPostByUrlSlug(string urlSlug, bool published);

        void UpdateBlogPost(PostViewModel post);
    }
}
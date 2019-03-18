using CoreBlog.Models.ViewModels;
using System.Linq;

namespace CoreBlog.Models
{
    public interface IPostRepository
    {
        IQueryable<Post> Posts { get; }

        void CreateNewBlogPost(Post post, Category category);

        Post DeleteBlogPost(int postId);

        PostViewModel GetBlogPostById(int? postId);

        PostViewModel GetBlogPostByUrlSlug(string urlSlug);

        void UpdateBlogPost(PostViewModel post);

        Post UnPublishPost(int? postId);
        Post PublishPost(int? postId);
    }
}
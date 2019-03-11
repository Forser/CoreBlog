using System.Collections.Generic;

namespace CoreBlog.Models.ViewModels
{
    public class PostsListViewModel
    {
        public IEnumerable<Post> Posts { get; set; }
    }
}
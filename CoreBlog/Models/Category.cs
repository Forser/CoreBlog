using System.Collections.Generic;

namespace CoreBlog.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string UrlSlug { get; set; }
        public string Description { get; set; }

        public List<Post> Posts { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreBlog.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Need one Category")]
        public string CategoryName { get; set; }
        public string UrlSlug { get; set; }
        public string Description { get; set; }

        public List<Post> Posts { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreBlog.Models
{
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }
        public string Url { get; set; }

        public List<Post> Posts { get; set; }

        public List<User> Users { get; set; }
    }
}
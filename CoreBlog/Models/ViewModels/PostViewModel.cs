using System.Collections.Generic;

namespace CoreBlog.Models.ViewModels
{
    public class PostViewModel
    {
        public Post Post { get; set; }
        public Category Category { get; set; }
        public Tag Tag { get; set; }
    }
}
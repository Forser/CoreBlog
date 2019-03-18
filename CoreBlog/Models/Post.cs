using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreBlog.Models
{
    public class Post
    {
        public int PostId { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Your content is empty!")]
        public string Content { get; set; }
        public string ShortContent { get; set; }
        public string MetaDataDescription { get; set; }
        public string UrlSlug { get; set; }
        public bool Published { get; set; } = false;
        public DateTime PostCreatedAt { get; set; }
        public DateTime? ModifiedLastAt { get; set; }


        public int BlogForeignKey { get; set; }
        public Blog Blog { get; set; }

        public int AuthorForeignKey { get; set; }
        public User User { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public List<PostTag> PostTags { get; set; }
    }
}
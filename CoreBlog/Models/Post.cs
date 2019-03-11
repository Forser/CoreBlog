using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreBlog.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ShortContent { get; set; }
        public string MetaDataDescription { get; set; }
        public string UrlSlug { get; set; }
        public bool Published { get; set; } = false;
        public DateTime PostCreatedAt { get; set; }
        public DateTime? ModifiedLastAt { get; set; }


        public int AuthorForeignKey { get; set; }
        [ForeignKey("AuthorForeignKey")]
        public User Author { get; set; }

        public int BlogForeignKey { get; set; }
        [ForeignKey("BlogForeignKey")]
        public Blog Blog { get; set; }

        public Category Category { get; set; }

        public List<PostTag> PostTags { get; set; }
    }
}
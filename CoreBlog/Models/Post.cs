using System;
using System.Collections.Generic;

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


        public int BlogForeignKey { get; set; }
        public Blog Blog { get; set; }

        public int AuthorForeignKey { get; set; }
        public User User { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public List<PostTag> PostTags { get; set; }
    }
}
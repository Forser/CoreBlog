using System.Collections.Generic;

namespace CoreBlog.Models
{
    public class Tag
    {
        public int TagId { get; set; }
        public string TagName { get; set; }
        public string UrlSlug { get; set; }

        public List<PostTag> PostTags { get; set; }
    }
}

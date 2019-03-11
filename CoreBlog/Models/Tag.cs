using System.Collections.Generic;

namespace CoreBlog.Models
{
    public class Tag
    {
        public string TagId { get; set; }

        public List<PostTag> PostTags { get; set; }
    }
}

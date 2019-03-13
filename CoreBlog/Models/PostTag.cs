using System.ComponentModel.DataAnnotations;

namespace CoreBlog.Models
{
    public class PostTag
    {
        [Key]
        public int id { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
        
    }
}
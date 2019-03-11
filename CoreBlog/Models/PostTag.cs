using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreBlog.Models
{
    public class PostTag
    {
        [Key]
        public int PostId { get; set; }
        public Post Post { get; set; }

        public int TagForeignKey { get; set; }
        [ForeignKey("TagForeignKey")]
        public Tag Tag { get; set; }
    }
}
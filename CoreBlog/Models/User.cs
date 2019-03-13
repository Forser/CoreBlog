using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreBlog.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AuthorName { get; set; }

        public List<Post> Posts { get; set; }

        public int BlogForeignKey { get; set; }
        public Blog Blog { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public class Post
    {
        public int userId { get; set; }

        public int postId { get; set; }

        public string caption { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime modifiedDate { get; set; }
        public int image { get; set; }


    }
}

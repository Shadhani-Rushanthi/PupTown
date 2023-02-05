using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public class comment
    {
        public int userId { get; set; }
        public int postId { get; set; }
        public int cmtId { get; set; }
        public string comments { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime modifiedDate { get; set; }
        public string IsSubcomment { get; set; }


    }
}

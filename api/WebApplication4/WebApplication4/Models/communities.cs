using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public class communities
    {
        public int userId { get; set; }
        public int communityId { get; set; }
        public string name { get; set; }
        public DateTime birthday { get; set; }
        public string breed { get; set; }
        public string purpose { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime modifiedDate { get; set; }
        public int profileImage { get; set; }
        public int coverImage { get; set; }
    }
}

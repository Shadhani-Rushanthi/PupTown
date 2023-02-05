using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public class communityfollow
    {
        public int userId { get; set; }
        public int communityId { get; set; }
        public DateTime StartedDate { get; set; }
    }
}

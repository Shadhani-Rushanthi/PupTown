using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public class personalfollow
    {
        public int userId { get; set; }
        public string followedBy { get; set; }
        public DateTime StartedDate { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public class Like
    {
        public int userId { get; set; }
        public int postId { get; set; }
        public int LikeId { get; set; }
        public string type { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime modifiedDate { get; set; }

    }
}

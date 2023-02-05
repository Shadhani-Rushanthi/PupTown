using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public class Chat
    {
        public int chatId { get; set; }
        public int userId { get; set; }
        public string message { get; set; }
        public string sentTo { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime modifiedDate { get; set; }

    }
}

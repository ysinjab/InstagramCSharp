using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramCSharp.Models
{
    public class Comment
    {
        public long Created_time { get; set; }
        public string Text { get; set; }
        public User From { get; set; }
        public string Id { get; set; }
    }
}

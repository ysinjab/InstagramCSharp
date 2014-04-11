using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramCSharp.Models
{
    public class Likes
    {
        public int Count { get; set; }
        public List<User> Data { get; set; }
    }
}

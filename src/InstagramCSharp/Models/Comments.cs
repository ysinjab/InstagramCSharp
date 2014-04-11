using System.Collections.Generic;

namespace InstagramCSharp.Models
{
    public class Comments
    {
        public int Count { get; set; }
        public List<Comment> Data { get; set; }
    }
}

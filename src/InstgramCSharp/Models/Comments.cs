using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstgramCSharp.Models
{
    public class Comments
    {
        public int Count { get; set; }
        public List<Comment> Data { get; set; }
    }
}

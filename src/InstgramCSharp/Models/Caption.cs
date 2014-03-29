using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstgramCSharp.Models
{
    public class Caption
    {
        public long Created_Time { get; set; }
        public string Text { get; set; }
        public User From { get; set; }
        public string id { get; set; }
    }
}

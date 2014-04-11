using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramCSharp.Models
{
    public class Feed
    {
        public Pagination Pagination { get; set; }
        public Meta Meta { get; set; }
        public List<Media> Data { get; set; }
    }
}

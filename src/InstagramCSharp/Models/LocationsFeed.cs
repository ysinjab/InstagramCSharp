using System.Collections.Generic;

namespace InstagramCSharp.Models
{
    public class LocationsFeed
    {
        public Meta Meta { get; set; }
        public List<Location> Data { get; set; }
    }
}

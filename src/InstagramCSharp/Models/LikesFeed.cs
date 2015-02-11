using System.Collections.Generic;

namespace InstagramCSharp.Models
{
   public  class LikesFeed
    {
        public Meta Meta { get; set; }
        public List<User> Data { get; set; }
    }
}

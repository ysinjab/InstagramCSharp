
using System.Collections.Generic;
namespace InstagramCSharp.Models
{
    public class FollowedByFeed
    {
        public Pagination Pagination { get; set; }
        public Meta Meta { get; set; }
        public List<User> Data { get; set; }
    }
}

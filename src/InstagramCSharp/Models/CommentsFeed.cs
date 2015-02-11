using System.Collections.Generic;

namespace InstagramCSharp.Models
{
    public class CommentsFeed
    {
        public Meta Meta { get; set; }
        public List<Comment> Data { get; set; }
    }

}

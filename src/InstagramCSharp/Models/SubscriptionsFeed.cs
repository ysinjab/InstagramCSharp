using System.Collections.Generic;

namespace InstagramCSharp.Models
{
    public class SubscriptionsFeed
    {
        public Meta meta { get; set; }
        public List<Subscription> data { get; set; }
    }
}

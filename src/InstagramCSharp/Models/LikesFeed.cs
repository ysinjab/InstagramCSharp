using System;
using System.Collections.Generic;

namespace InstagramCSharp.Models
{
    [Obsolete("LikesFeed class is deprecated, please use Envelope<List<User>> instead.")]
    public class LikesFeed : Envelope<List<User>>
    {
    }
}

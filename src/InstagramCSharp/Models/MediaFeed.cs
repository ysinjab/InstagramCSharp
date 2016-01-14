using System;
using System.Collections.Generic;

namespace InstagramCSharp.Models
{
    [Obsolete("MediaFeed class is deprecated, please use Envelope<List<Media>> instead.")]
    public class MediaFeed : Envelope<List<Media>>
    {
    }
}

using System;
using System.Collections.Generic;

namespace InstagramCSharp.Models
{
    [Obsolete("LocationsFeed class is deprecated, please use Envelope<List<Location>> instead.")]
    public class LocationsFeed : Envelope<List<Location>>
    {
    }
}

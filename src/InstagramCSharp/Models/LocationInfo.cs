using System;
namespace InstagramCSharp.Models
{
    [Obsolete("LocationInfo class is deprecated, please use Envelope<Location> instead.")]
    public class LocationInfo : Envelope<Location>
    {
    }
}

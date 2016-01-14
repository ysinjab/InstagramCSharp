using System;
namespace InstagramCSharp.Models
{
    [Obsolete("UserBasicInfo class is deprecated, please use Envelope<User> instead.")]
    public class UserBasicInfo : Envelope<User>
    {
    }
}

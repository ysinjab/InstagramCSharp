
namespace InstagramCSharp.Models
{
    public class Subscription
    {
        public ulong Id { get; set; }
        public string Type { get; set; }
        public string @object { get; set; }
        public string Aspect { get; set; }
        public string Callback_Url { get; set; }
        public string Object_Id { get; set; }
    }
}

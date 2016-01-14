namespace InstagramCSharp.Models
{
    public class Comment
    {
        public long Created_time { get; set; }
        public string Text { get; set; }
        public User From { get; set; }
        public string Id { get; set; }
    }
}

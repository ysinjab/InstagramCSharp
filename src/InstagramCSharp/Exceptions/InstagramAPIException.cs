using System;

namespace InstagramCSharp.Exceptions
{
    public class InstagramAPIException : Exception
    {
        public InstagramAPIException(string message)
            : base(message) { }
        public int Code { get; set; }
        public string Error_type { get; set; }
        public string Error_message { get; set; }
    }
}

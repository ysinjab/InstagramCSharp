using System;

namespace InstagramCSharp.Exceptions
{
    public class InstagramAPIException : Exception
    {
        public InstagramAPIException(string message)
            : base(message) { }
    }
}

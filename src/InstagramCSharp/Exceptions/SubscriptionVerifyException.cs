using System;

namespace InstagramCSharp.Exceptions
{
    public class SubscriptionVerifyException : Exception
    {
        public SubscriptionVerifyException(string message)
            : base(message) { }
    }
}

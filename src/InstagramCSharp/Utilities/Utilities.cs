using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace InstagramCSharp
{
    internal static class Utilities
    {
        internal static string ComputeHash<T>(byte[] data, byte[] key) where T : HMAC
        {
            var hmac  = HMAC.Create(typeof(T).ToString());
            MemoryStream stream = new MemoryStream(data);
            return hmac.ComputeHash(stream).Aggregate("", (s, e) => s + String.Format("{0:x2}", e), s => s);
        }
        internal static string GenerateSig(string endPoint, string clientSecret, NameValueCollection querystring)
        {
            string sig = endPoint;
            foreach (var key in querystring)
            {
                sig += String.Format("|{0}={1}", key, querystring[key.ToString()].ToString());
            }
            return ComputeHash<HMACSHA256>(Encoding.UTF8.GetBytes(sig), Encoding.UTF8.GetBytes(clientSecret));
        }
    }
}

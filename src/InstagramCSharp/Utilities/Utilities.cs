using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace InstagramCSharp
{
    internal static class Utilities
    {
        internal static string ComputeHash<T>(byte[] data, byte[] key) where T : HMAC
        {
            var hmac  = HMAC.Create(typeof(T).ToString());
            hmac.Key = key;
            MemoryStream stream = new MemoryStream(data);
            return hmac.ComputeHash(stream).Aggregate("", (s, e) => s + String.Format("{0:x2}", e), s => s);
        }
        internal static string GenerateSig(string endPoint, string clientSecret, string query)
        {
            string sig = endPoint;
            NameValueCollection queryParams = HttpUtility.ParseQueryString(query);
            foreach (var key in queryParams)
            {
                sig += String.Format("|{0}={1}", key, queryParams[key.ToString()].ToString());
            }
            return ComputeHash<HMACSHA256>(Encoding.UTF8.GetBytes(sig), Encoding.UTF8.GetBytes(clientSecret));
        }
        internal static string GenerateSig(string endPoint, string clientSecret, List<KeyValuePair<string, string>> parameters)
        {
            string sig = endPoint;
            foreach (var parameter in parameters)
            {
                sig += String.Format("|{0}={1}", parameter.Key, parameter.Value);
            }
            return ComputeHash<HMACSHA256>(Encoding.UTF8.GetBytes(sig), Encoding.UTF8.GetBytes(clientSecret));
        }
    }
}

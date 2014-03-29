using InstgramCSharp.Enums;
using InstgramCSharp.Factories;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace InstgramCSharp.OAuth
{
    public static class InstgramOAuth
    {
        public static string GetAuthorizationUrl(string clientId, string redirectUri, string responseType, IEnumerable<AccessScopes> Scopes)
        {
            return OAuthInstgramUrlsFactory.CreateAuthorizationUrl(clientId, redirectUri, responseType, Scopes);
        }

        public static async Task<HttpResponseMessage> AuthenticateUser(string clientId, string clientSecret, string grant_type, string redirectUri, string code)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var postData = new List<KeyValuePair<string, string>>();
                postData.Add(new KeyValuePair<string, string>("client_id", clientId));
                postData.Add(new KeyValuePair<string, string>("client_secret", clientSecret));
                postData.Add(new KeyValuePair<string, string>("grant_type", grant_type));
                postData.Add(new KeyValuePair<string, string>("redirect_uri", redirectUri));
                postData.Add(new KeyValuePair<string, string>("code", code));
                FormUrlEncodedContent content = new FormUrlEncodedContent(postData);
                var response = await httpClient.PostAsync(InstgramAPIUrls.OAuthAccessTokenUrl, content);
                return response;
            }

        }


    }
}

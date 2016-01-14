using InstagramCSharp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstagramCSharp.Factories
{
    public static class OAuthInstagramUrlsFactory
    {
        public static string CreateAuthorizationUrl(string clientId, string redirectUri, string responseType, IEnumerable<AccessScopes> Scopes)
        {
            var queryString = BuildAuthorizationUrlQueryString(clientId, redirectUri, responseType, Scopes);
            return BuildAuthorizationUrl(InstagramAPIUrls.AuthorizationUrl, queryString);
        }

        private static string BuildAuthorizationUrl(string url, string queryString)
        {
            return url+"?"+queryString;
        }

        private static string BuildAuthorizationUrlQueryString(string clientId, string redirectUri, string responseType, IEnumerable<AccessScopes> accessScopes)
        {           
            var queryString = HttpUtility.ParseQueryString("");
            queryString["client_id"] = clientId;
            queryString["redirect_uri"] = redirectUri;
            queryString["response_type"] = responseType;
            if (accessScopes.Count() > 0)
            {
                List<string> scopes = new List<string>();
                foreach (var accessScope in accessScopes)
                {
                    switch (accessScope)
                    {
                        case AccessScopes.Basic:
                            scopes.Add("basic");
                            break;
                        case AccessScopes.Comments:
                            scopes.Add("comments");
                            break;
                        case AccessScopes.Relationships:
                            scopes.Add("relationships");
                            break;
                        case AccessScopes.Likes:
                            scopes.Add("likes");
                            break;
                        case AccessScopes.FollowerList:
                            scopes.Add("follower_list");
                            break;
                        case AccessScopes.PublicContent:
                            scopes.Add("public_content");
                            break;

                    }
                }             

                return queryString.ToString() + "&scope=" + String.Join("+", scopes);
            }
            return queryString.ToString();
        }
    }
}

using System;
using System.Web;

namespace InstagramCSharp.Factories
{
    public class TagEndpointsUrlsFactory
    {
        public static Uri CreateTagInfoUrl(string tagName, string accessToken)
        {
            var queryString = BuildTagEndpointsUrlQueryString(accessToken);
            return new Uri(InstagramAPIUrls.BaseAPIUrl + string.Format(InstagramAPIEndpoints.TagInfoEndpoint, tagName) + "?" + queryString);
        }
        public static Uri CreateRecentTaggedMediaUrl(string tagName, string accessToken, int count = 0, string minTagId = null, string maxTagId = null)
        {
            var queryString = BuildTagEndpointsUrlQueryString(accessToken, count, minTagId, maxTagId);
            return new Uri(InstagramAPIUrls.BaseAPIUrl + string.Format(InstagramAPIEndpoints.RecentTaggedMediaEndpoint, tagName) + "?" + queryString);
        }
        public static Uri CreateSearchTagUrl(string q, string accessToken)
        {
            var queryString = BuildTagEndpointsUrlQueryString(accessToken, 0, null, null, q);
            return new Uri(InstagramAPIUrls.BaseAPIUrl + InstagramAPIEndpoints.SearchTagEndpoint + "?" + queryString);
        }
        private static string BuildTagEndpointsUrlQueryString(string accessToken, int count = 0, string minTagId = null, string maxTagId = null, string q = null)
        {
            var queryString = HttpUtility.ParseQueryString("");
            queryString["access_token"] = accessToken;
            if (count != 0)
            {
                queryString["count"] = count.ToString();
            }
            if (minTagId != null)
            {
                queryString["min_tag_id"] = minTagId;
            }
            if (maxTagId != null)
            {
                queryString["max_tag_id"] = maxTagId;
            }
            if (q != null)
            {
                queryString["q"] = q;
            }
            return queryString.ToString();
        }
    }
}

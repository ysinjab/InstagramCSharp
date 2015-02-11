using System.Web;

namespace InstagramCSharp.Factories
{
    public class TagEndpointsUrlsFactory
    {
        public static string CreateTagInfoUrl(string tagName, string accessToken)
        {
            var queryString = BuildTagEndpointsUrlQueryString(accessToken);
            return BuildTagInfoUrl(tagName, InstagramAPIUrls.TagsEndpointsUrl, queryString);
        }
        public static string CreateRecentTaggedMediaUrl(string tagName, string accessToken,int count=0, string minTagId = null, string maxTagId = null)
        {
            var queryString = BuildTagEndpointsUrlQueryString(accessToken,count, minTagId, maxTagId);
            return BuildRecentTaggedMediaUrl(tagName, InstagramAPIUrls.TagsEndpointsUrl, queryString);
        }
        public static string CreateSearchTagUrl(string q, string accessToken)
        {
            var queryString = BuildTagEndpointsUrlQueryString(accessToken,0,null,null, q);
            return BuildSearchTagUrl(InstagramAPIUrls.TagsEndpointsUrl, queryString);
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
        private static string BuildTagInfoUrl(string tagName, string url, string queryString)
        {
            url = string.Format(url + "/{0}", tagName);
            return url + "?" + queryString;
        }
        private static string BuildRecentTaggedMediaUrl(string tagName, string url, string queryString)
        {
            url = string.Format(url + "/{0}/media/recent", tagName);
            return url + "?" + queryString;
        }

        private static string BuildSearchTagUrl(string url, string queryString)
        {
            url = url + "/search";
            return url + "?" + queryString;
        }
    }
}

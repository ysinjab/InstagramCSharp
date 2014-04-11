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
        public static string CreateRecentTaggedMediaUrl(string tagName, string accessToken, string minId = null, string maxId = null)
        {
            var queryString = BuildTagEndpointsUrlQueryString(accessToken, minId, maxId);
            return BuildRecentTaggedMediaUrl(tagName, InstagramAPIUrls.TagsEndpointsUrl, queryString);
        }
        public static string CreateSearchTagUrl(string q, string accessToken)
        {
            var queryString = BuildTagEndpointsUrlQueryString(accessToken,null,null, q);
            return BuildSearchTagUrl(InstagramAPIUrls.TagsEndpointsUrl, queryString);
        }
        private static string BuildTagEndpointsUrlQueryString(string accessToken, string minId = null, string maxId = null, string q = null)
        {
            var queryString = HttpUtility.ParseQueryString("");
            queryString["access_token"] = accessToken;
            if (minId != null)
            {
                queryString["min_id"] = minId;
            }
            if (maxId != null)
            {
                queryString["max_id"] = maxId;
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
            url = url + "/tags/search";
            return url + "?" + queryString;
        }
    }
}

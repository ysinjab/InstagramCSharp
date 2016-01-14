using System.Web;

namespace InstagramCSharp.Factories
{
    public static class UserEndpointUrlsFactory
    {
        public static string CreateSelfUserUrl(string accessToken)
        {
            var queryString = BuildUserEndpointUrlQueryString(accessToken);
            return BuildSelfUserUrl(InstagramAPIUrls.UserEndpointsUrl, queryString);
        }
        public static string CreateUserBasicInfoUrl(long userId, string accessToken)
        {
            var queryString = BuildUserEndpointUrlQueryString(accessToken);
            return BuildUserBasicInfoUrl(userId, InstagramAPIUrls.UserEndpointsUrl, queryString);
        }
        public static string CreateSelfRecentMediaUrl(string accessToken, int count = 0, string minId = null, string maxId = null)
        {
            var queryString = BuildUserEndpointUrlQueryString(accessToken, count, minId, maxId);
            return BuildSelfRecentMediaUrl(InstagramAPIUrls.UserEndpointsUrl, queryString);
        }
        public static string CreateUserRecentMediaUrl(long userId, string accessToken, int count = 0, string minId = null, string maxId = null, long minTimestamp = 0, long maxTimestamp = 0)
        {
            var queryString = BuildUserEndpointUrlQueryString(accessToken, count, minId, maxId, minTimestamp, maxTimestamp);
            return BuildUserRecentMediaUrl(userId, InstagramAPIUrls.UserEndpointsUrl, queryString);
        }
        public static string CreateUserLikedMediaUrl(string accessToken, int count = 0, string maxLikeId = null)
        {
            var queryString = BuildUserEndpointUrlQueryString(accessToken, count, null, null, 0, 0, maxLikeId);
            return BuildUserLikedMediaUrl(InstagramAPIUrls.UserEndpointsUrl, queryString);
        }
        public static string CreateSearchUsersUrl(string accessToken, string q, int count = 0)
        {
            var queryString = BuildUserEndpointUrlQueryString(accessToken, count, null, null, 0, 0, null, q);
            return BuildSearchUsersUrl(InstagramAPIUrls.UserEndpointsUrl, queryString);
        }
        private static string BuildUserEndpointUrlQueryString(string accessToken = null,int count = 0, string minId = null, string maxId = null, long minTimestamp = 0, long maxTimestamp = 0, string maxLikeId = null, string q = null)
        {
            var queryString = HttpUtility.ParseQueryString("");
            if (accessToken != null)
            {
                queryString["access_token"] = accessToken;
            }
            if (count != 0)
            {
                queryString["count"] = count.ToString();
            }
            if (minId != null)
            {
                queryString["min_id"] = minId;
            }
            if (maxId != null)
            {
                queryString["max_id"] = maxId;
            }
            if (minTimestamp != 0)
            {
                queryString["min_timestamp"] = minTimestamp.ToString();
            }
            if (maxTimestamp != 0)
            {
                queryString["max_timestamp"] = maxTimestamp.ToString();
            }
            if (maxLikeId != null)
            {
                queryString["max_like_id"] = maxLikeId;
            }
            if (q != null)
            {
                queryString["q"] = q;
            }
            return queryString.ToString();

        }
        private static string BuildSelfUserUrl(string url, string queryString)
        {
            return url + "/self" + "?" + queryString;
        }
        private static string BuildUserBasicInfoUrl(long userId, string url, string queryString)
        {
            url = string.Format(url + "/{0}", userId);
            return url + "?" + queryString;
        }
        private static string BuildSelfRecentMediaUrl(string url, string queryString)
        {
            url = url + "/self/media/recent";
            return url + "?" + queryString;
        }
        private static string BuildUserRecentMediaUrl(long userId, string url, string queryString)
        {
            url = string.Format(url + "/{0}/media/recent", userId);
            return url + "?" + queryString;
        }
        private static string BuildUserLikedMediaUrl(string url, string queryString)
        {
            url = url + "/self/media/liked";
            return url + "?" + queryString;
        }
        private static string BuildSearchUsersUrl(string url, string queryString)
        {
            url = url + "/search";
            return url + "?" + queryString;
        }
    }
}

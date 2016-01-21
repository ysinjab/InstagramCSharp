using System;
using System.Web;

namespace InstagramCSharp.Factories
{
    public static class UserEndpointUrlsFactory
    {
        public static Uri CreateSelfUserUrl(string accessToken)
        {
            var queryString = BuildUserEndpointUrlQueryString(accessToken);
            return new Uri(InstagramAPIUrls.BaseAPIUrl + InstagramAPIEndpoints.SelfUserInfoEndpoint + "?" + queryString);
        }
        public static Uri CreateUserBasicInfoUrl(long userId, string accessToken)
        {
            var queryString = BuildUserEndpointUrlQueryString(accessToken);
            return new Uri(InstagramAPIUrls.BaseAPIUrl + string.Format(InstagramAPIEndpoints.UserBasicInfoEndpoint, userId) + "?" + queryString);
        }
        public static Uri CreateSelfRecentMediaUrl(string accessToken, int count = 0, string minId = null, string maxId = null)
        {
            var queryString = BuildUserEndpointUrlQueryString(accessToken, count, minId, maxId);
            return new Uri(InstagramAPIUrls.BaseAPIUrl + InstagramAPIEndpoints.SelfRecentMediaEndpoint + "?" + queryString);
        }
        public static Uri CreateUserRecentMediaUrl(long userId, string accessToken, int count = 0, string minId = null, string maxId = null, long minTimestamp = 0, long maxTimestamp = 0)
        {
            var queryString = BuildUserEndpointUrlQueryString(accessToken, count, minId, maxId, minTimestamp, maxTimestamp);
            return new Uri(InstagramAPIUrls.BaseAPIUrl + string.Format(InstagramAPIEndpoints.UserRecentMediaEndpoint, userId) + "?" + queryString);
        }
        public static Uri CreateUserLikedMediaUrl(string accessToken, int count = 0, string maxLikeId = null)
        {
            var queryString = BuildUserEndpointUrlQueryString(accessToken, count, null, null, 0, 0, maxLikeId);
            return new Uri(InstagramAPIUrls.BaseAPIUrl + InstagramAPIEndpoints.UserLikedMediaEndpoint + "?" + queryString);
        }
        public static Uri CreateSearchUsersUrl(string accessToken, string q, int count = 0)
        {
            var queryString = BuildUserEndpointUrlQueryString(accessToken, count, null, null, 0, 0, null, q);
            return new Uri(InstagramAPIUrls.BaseAPIUrl + InstagramAPIEndpoints.SearchUsersEndpoint + "?" + queryString);
        }
        private static string BuildUserEndpointUrlQueryString(string accessToken = null, int count = 0, string minId = null, string maxId = null, long minTimestamp = 0, long maxTimestamp = 0, string maxLikeId = null, string q = null)
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
    }
}

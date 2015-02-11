using InstagramCSharp.Enums;
using System.Web;

namespace InstagramCSharp.Factories
{
    public class RealTimeSubscriptionsUrlsFactory
    {
        public static string CreateGETAllSubscriptionsUrl(string clientId, string clientSecret)
        {
            var queryString = BuildGETAllSubscriptionsUrlQueryString(clientId, clientSecret);
            return BuildRealTimeSubscriptionUrl(InstagramAPIUrls.RealTimeSubscriptionsUrl, queryString);
        }

        private static object BuildGETAllSubscriptionsUrlQueryString(string clientId, string clientSecret)
        {
            var queryString = HttpUtility.ParseQueryString("");
            queryString["client_id"] = clientId;
            queryString["client_secret"] = clientSecret;
            return queryString.ToString();
        }
        public static string CreateDELETESubscriptionsUrl(string clientId, string clientSecret, long id)
        {
            var queryString = BuildDELETESubscriptionsUrlQueryString(clientId, clientSecret, id);
            return BuildRealTimeSubscriptionUrl(InstagramAPIUrls.RealTimeSubscriptionsUrl, queryString);
        }

        public static string CreateDELETESubscriptionsUrl(string clientId, string clientSecret, RealTimeObjects obj)
        {
            var queryString = BuildDELETESubscriptionsUrlQueryString(clientId, clientSecret, obj);
            return BuildRealTimeSubscriptionUrl(InstagramAPIUrls.RealTimeSubscriptionsUrl, queryString);
        }

        private static object BuildDELETESubscriptionsUrlQueryString(string clientId, string clientSecret, long id)
        {
            var queryString = HttpUtility.ParseQueryString("");
            queryString["client_id"] = clientId;
            queryString["client_secret"] = clientSecret;
            queryString["id"] = id.ToString();
            return queryString.ToString();
        }
        private static object BuildDELETESubscriptionsUrlQueryString(string clientId, string clientSecret, RealTimeObjects obj)
        {
            var queryString = HttpUtility.ParseQueryString("");
            queryString["client_id"] = clientId;
            queryString["client_secret"] = clientSecret;
            switch (obj)
            {
                case RealTimeObjects.User:
                    queryString["object"] = "user";
                    break;
                case RealTimeObjects.Tag:
                    queryString["object"] = "tag";
                    break;
                case RealTimeObjects.Location:
                    queryString["object"] = "location";
                    break;
                case RealTimeObjects.Geography:
                    queryString["object"] = "geography";
                    break;
                case RealTimeObjects.All:
                    queryString["object"] = "all";
                    break;
                default:
                    break;
            }
            return queryString.ToString();
        }
        private static string BuildRealTimeSubscriptionUrl(string url, object queryString)
        {
            return url + "?" + queryString;
        }
    }
}

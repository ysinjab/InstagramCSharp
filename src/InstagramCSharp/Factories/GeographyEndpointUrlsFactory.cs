using System.Web;

namespace InstagramCSharp.Factories
{
    public class GeographyEndpointUrlsFactory
    {
        public static string CreateRecentGeographyMediaUrl(long geoId, string clientId, int count = 0, string minId = null)
        {
            var queryString = BuildGeographyUrlQueryString(clientId, count, minId);
            return BuildRecentGeographyMediaUrl(geoId, InstagramAPIUrls.GeographyEndpointsUrl, queryString);
        }
        private static string BuildRecentGeographyMediaUrl(long geoId, string url, object queryString)
        {
            url = string.Format(url + "/{0}/media/recent", geoId);
            return url + "?" + queryString;
        }
        private static object BuildGeographyUrlQueryString(string clientId, int count, string minId)
        {
            var queryString = HttpUtility.ParseQueryString("");
            queryString["client_id"] = clientId;
            if (count != 0)
            {
                queryString["count"] = count.ToString();
            }
            if (minId != null)
            {
                queryString["min_id"] = minId;
            }
            return queryString.ToString();
        }

    }
}

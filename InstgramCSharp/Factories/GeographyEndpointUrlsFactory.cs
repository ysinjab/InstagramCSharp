using System.Web;

namespace InstgramCSharp.Factories
{
    public class GeographyEndpointUrlsFactory
    {
        public static string CreateRecenGeographyMediaUrl(string geoId, string clientId, int count = 0, string minId = null)
        {
            var queryString = BuildGeographyUrlQueryString(clientId, count, minId);
            return BuildRecentGeographyMediaUrl(geoId, InstgramAPIUrls.GeographyEndpointsUrl, queryString);
        }
        private static string BuildRecentGeographyMediaUrl(string geoId, string url, object queryString)
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

using System.Web;

namespace InstagramCSharp.Factories
{
    public static class MediaEndpointsUrlsFactory
    {
        public static string CreateSearchMediaUrl(string accessToken, double distance, double lat = 0, double lng = 0)
        {
            var queryString = BuildMediaEndpointsUrlsQueryString(accessToken,distance,lat,lng);
            return BuildSearchMediaUrl(InstagramAPIUrls.MediaEndpointsUrl, queryString);
        }
        public static string CreateMediaInfoUrl(string mediaId, string accessToken)
        {
            var queryString = BuildMediaEndpointsUrlsQueryString(accessToken);
            return BuildMediaInfoUrl(mediaId, InstagramAPIUrls.MediaEndpointsUrl, queryString);
        }
        public static string CreateShortCodeMediaInfoUrl(string shortCode, string accessToken)
        {
            var queryString = BuildMediaEndpointsUrlsQueryString(accessToken);
            return BuildShortCodeMediaInfoUrl(shortCode, InstagramAPIUrls.MediaEndpointsUrl, queryString);
        }

        private static string BuildMediaEndpointsUrlsQueryString(string accessToken, double distance = 0, double lat = 0, double lng = 0)
        {
            var queryString = HttpUtility.ParseQueryString("");
            queryString["access_token"] = accessToken;           
            if (lat != 0)
            {
                queryString["lat"] = lat.ToString();
            }
            if (lng != 0)
            {
                queryString["lng"] = lng.ToString();
            }
            if (distance != 0)
            {
                queryString["distance"] = distance.ToString();
            }
            return queryString.ToString();
        }
        private static string BuildMediaInfoUrl(string mediaId, string url, string queryString)
        {
            url = string.Format(url + "/{0}", mediaId);
            return url + "?" + queryString;
        }
        private static string BuildShortCodeMediaInfoUrl(string shortCode, string url, string queryString)
        {
            url = string.Format(url + "/shortcode/{0}", shortCode);
            return url + "?" + queryString;
        }
        private static string BuildSearchMediaUrl(string url, string queryString)
        {
            url = url + "/search";
            return url + "?" + queryString;
        }

    }
}

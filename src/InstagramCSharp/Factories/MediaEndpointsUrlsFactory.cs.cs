using System;
using System.Web;

namespace InstagramCSharp.Factories
{
    public static class MediaEndpointsUrlsFactory
    {
        public static Uri CreateSearchMediaUrl(string accessToken, double distance, double lat = 0, double lng = 0)
        {
            var queryString = BuildMediaEndpointsUrlsQueryString(accessToken, distance, lat, lng);
            return new Uri(InstagramAPIUrls.BaseAPIUrl + InstagramAPIEndpoints.SearchMediaEndpoint + "?" + queryString); 
        }
        public static Uri CreateMediaInfoUrl(string mediaId, string accessToken)
        {
            var queryString = BuildMediaEndpointsUrlsQueryString(accessToken);
            return new Uri(InstagramAPIUrls.BaseAPIUrl + string.Format(InstagramAPIEndpoints.MediaInfoEndpoint, mediaId) + "?" + queryString); 
        }
        public static Uri CreateShortCodeMediaInfoUrl(string shortCode, string accessToken)
        {
            var queryString = BuildMediaEndpointsUrlsQueryString(accessToken);
            return new Uri(InstagramAPIUrls.BaseAPIUrl + string.Format(InstagramAPIEndpoints.ShortCodeMediaInfoEndpoint, shortCode) + "?" + queryString); 
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

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace InstagramCSharp.Factories
{
    public static class MediaEndpointsUrlsFactory
    {
        public static string CreateSearchMediaUrl(string accessToken, long minTimestamp = 0, long maxTimestamp = 0, string distance = null, double lat = 0, double lng = 0)
        {
            var queryString = BuildMediaEndpointsUrlsQueryString(accessToken, minTimestamp,maxTimestamp,distance,lat,lng);
            return BuildSearchMediaUrl(InstagramAPIUrls.MediaEndpointsUrl, queryString);
        }
        public static string CreateMediaInfoUrl(string mediaId, string accessToken)
        {
            var queryString = BuildMediaEndpointsUrlsQueryString(accessToken);
            return BuildMediaInfoUrl(mediaId, InstagramAPIUrls.MediaEndpointsUrl, queryString);
        }
        public static string CreatePopularMediaUrl(string accessToken)
        {
            var queryString = BuildMediaEndpointsUrlsQueryString(accessToken);
            return BuildPopularMediaUrl(InstagramAPIUrls.MediaEndpointsUrl, queryString);
        }


        private static string BuildMediaEndpointsUrlsQueryString(string accessToken, long minTimestamp = 0, long maxTimestamp = 0, string distance = null, double lat = 0, double lng = 0)
        {
            var queryString = HttpUtility.ParseQueryString("");
            queryString["access_token"] = accessToken;
            if (minTimestamp != 0)
            {
                queryString["min_timestamp"] = minTimestamp.ToString();
            }
            if (maxTimestamp != 0)
            {
                queryString["max_timestamp"] = maxTimestamp.ToString();
            }
            if (lat != 0)
            {
                queryString["lat"] = lat.ToString();
            }
            if (lng != 0)
            {
                queryString["lng"] = lng.ToString();
            }
            if (distance != null)
            {
                queryString["distance"] = distance;
            }
            return queryString.ToString();
        }
        private static string BuildMediaInfoUrl(string mediaId, string url, string queryString)
        {
            url = string.Format(url + "/{0}", mediaId);
            return url + "?" + queryString;
        }


        private static string BuildSearchMediaUrl(string url, string queryString)
        {
            url = url + "/search";
            return url + "?" + queryString;
        }

        private static string BuildPopularMediaUrl(string url, string queryString)
        {
            url = url + "/popular";
            return url + "?" + queryString;
        }


    }
}

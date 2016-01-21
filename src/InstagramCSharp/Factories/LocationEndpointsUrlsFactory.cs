using System;
using System.Web;

namespace InstagramCSharp.Factories
{
    public class LocationEndpointsUrlsFactory
    {
        public static Uri CreateLocationInfoUrl(long locationId, string accessToken)
        {
            var queryString = CreateLocationUrlQueryString(accessToken);
            return new Uri(InstagramAPIUrls.BaseAPIUrl + string.Format(InstagramAPIEndpoints.LocationInfoEndpoint, locationId) + "?" + queryString); 
        }
        public static Uri CreateRecentLocationMediaUrl(long locationId, string accessToken, string minId = null, string maxId = null)
        {
            var queryString = CreateLocationUrlQueryString(accessToken, minId, maxId);
            return new Uri(InstagramAPIUrls.BaseAPIUrl + string.Format(InstagramAPIEndpoints.RecentLocationgedMediaEndpoint, locationId) + "?" + queryString); 
        }
        public static Uri CreateSearchLocationUrl(string accessToken, double distance = 1000, string facebookPlacesId = null, string foursquareId = null, double lat = 0, double lng = 0, string foursquareV2Id = null)
        {
            var queryString = CreateSearchLocationUrlQueryString(accessToken, distance, facebookPlacesId, foursquareId, lat, lng, foursquareV2Id);
            return new Uri(InstagramAPIUrls.BaseAPIUrl + InstagramAPIEndpoints.SearchLocationEndpoint + "?" + queryString); 
        }
        private static string CreateLocationUrlQueryString(string accessToken, string minId = null, string maxId = null)
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
            return queryString.ToString();
        }
        private static string CreateSearchLocationUrlQueryString(string accessToken, double distance, string facebookPlacesId, string foursquareId, double lat, double lng, string foursquareV2Id)
        {
            var queryString = HttpUtility.ParseQueryString("");
            queryString["access_token"] = accessToken;
            queryString["distance"] = distance.ToString();
            if (facebookPlacesId != null)
            {
                queryString["facebook_places_id"] = facebookPlacesId;
            }
            if (foursquareId != null)
            {
                queryString["foursquare_id"] = foursquareId;
            }
            if (lat != 0)
            {
                queryString["lat"] = lat.ToString();
            }
            if (lng != 0)
            {
                queryString["lng"] = lng.ToString();
            }
            if (foursquareV2Id != null)
            {
                queryString["foursquare_v2_id"] = foursquareV2Id;
            }
            return queryString.ToString();
        }       
    }
}

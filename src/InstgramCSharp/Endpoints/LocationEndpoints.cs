using InstgramCSharp.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InstgramCSharp.Endpoints
{
    public static class LocationEndpoints
    {
        /// <summary>
        /// Get information about a location.
        /// </summary>
        /// <param name="accessToken">A valid access token.</param>
        /// <returns>JSON result string.</returns>
        public static async Task<string> GetLocationInfoAsync(ulong locationId, string accessToken)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(LocationEndpointsUrlsFactory.CreateLocationInfoUrl(locationId, accessToken));
                return response;
            }
        }
        /// <summary>
        /// Get a list of recent media objects from a given location. May return a mix of both image and video types.
        /// </summary>
        /// <param name="accessToken">A valid access token.</param>
        /// <param name="minId">Return media before this min_id.</param>
        /// <param name="maxId">Return media after this max_id.</param>
        /// <param name="minTimestamp">Return media after this UNIX timestamp.</param>
        /// <param name="maxTimestamp">Return media before this UNIX timestamp.</param>
        /// <returns>JSON result string.</returns>
        public static async Task<string> GetRecentLocationMediaAsync(ulong locationId, string accessToken, string minId = null, string maxId = null, long minTimestamp = 0, long maxTimestamp = 0)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(LocationEndpointsUrlsFactory.CreateRecentLocationMediaUrl(locationId,accessToken,  minId, maxId,minTimestamp,maxTimestamp));
                return response;
            }
        }

        /// <summary>
        /// Search for a location by geographic coordinate.
        /// </summary>
        /// <param name="accessToken">A valid access token.</param>
        /// <param name="distance">Default is 1000m (distance=1000), max distance is 5000.</param>
        /// <param name="facebookPlacesId">Returns a location mapped off of a Facebook places id. If used, a Foursquare id and lat, lng are not required.</param>
        /// <param name="foursquareId">Returns a location mapped off of a foursquare v1 api location id. If used, you are not required to use lat and lng. Note that this method is deprecated; you should use the new foursquare IDs with V2 of their API.</param>
        /// <param name="lat">Latitude of the center search coordinate. If used, lng is required.</param>
        /// <param name="lng">Longitude of the center search coordinate. If used, lat is required.</param>
        /// <param name="foursquareV2Id">Returns a location mapped off of a foursquare v2 api location id. If used, you are not required to use lat and lng.</param>
        /// <returns>JSON result string.</returns>
        public static async Task<string> SearchLocationAsync(string accessToken, string distance = null, string facebookPlacesId = null, string foursquareId = null, double lat = 0, double lng = 0, string foursquareV2Id = null)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(LocationEndpointsUrlsFactory.CreateSearchLocationUrl(accessToken, distance, facebookPlacesId, foursquareId, lat, lng, foursquareV2Id));
                return response;
            }

        }
    }
}

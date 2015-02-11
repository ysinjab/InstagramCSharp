using InstagramCSharp.Exceptions;
using InstagramCSharp.Factories;
using System.Net.Http;
using System.Threading.Tasks;

namespace InstagramCSharp.Endpoints
{
    public class LocationEndpoints
    {
        private string accessToken;
        public LocationEndpoints(string accessToken)
        {
            this.accessToken = accessToken;
        }
        /// <summary>
        /// Get information about a location.
        /// </summary>
        /// <returns>JSON result string.</returns>
        public async Task<string> GetLocationInfoAsync(long locationId)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(LocationEndpointsUrlsFactory.CreateLocationInfoUrl(locationId, this.accessToken));
                string responseContent = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    return responseContent;
                }
                else
                {
                    throw new InstagramAPIException(responseContent);
                }
            }
        }
        /// <summary>
        /// Get a list of recent media objects from a given location. May return a mix of both image and video types.
        /// </summary>
        /// <param name="minId">Return media before this min_id.</param>
        /// <param name="maxId">Return media after this max_id.</param>
        /// <param name="minTimestamp">Return media after this UNIX timestamp.</param>
        /// <param name="maxTimestamp">Return media before this UNIX timestamp.</param>
        /// <returns>JSON result string.</returns>
        public async Task<string> GetRecentLocationMediaAsync(long locationId, string minId = null, string maxId = null, long minTimestamp = 0, long maxTimestamp = 0)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(LocationEndpointsUrlsFactory.CreateRecentLocationMediaUrl(locationId, this.accessToken, minId, maxId, minTimestamp, maxTimestamp));
                string responseContent = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    return responseContent;
                }
                else
                {
                    throw new InstagramAPIException(responseContent);
                }
            }
        }

        /// <summary>
        /// Search for a location by geographic coordinate.
        /// </summary>
        /// <param name="distance">Default is 1000m (distance=1000), max distance is 5000.</param>
        /// <param name="facebookPlacesId">Returns a location mapped off of a Facebook places id. If used, a Foursquare id and lat, lng are not required.</param>
        /// <param name="foursquareId">Returns a location mapped off of a foursquare v1 api location id. If used, you are not required to use lat and lng. Note that this method is deprecated; you should use the new foursquare IDs with V2 of their API.</param>
        /// <param name="lat">Latitude of the center search coordinate. If used, lng is required.</param>
        /// <param name="lng">Longitude of the center search coordinate. If used, lat is required.</param>
        /// <param name="foursquareV2Id">Returns a location mapped off of a foursquare v2 api location id. If used, you are not required to use lat and lng.</param>
        public async Task<string> SearchLocationAsync(double distance = 1000, string facebookPlacesId = null, string foursquareId = null, double lat = 0, double lng = 0, string foursquareV2Id = null)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(LocationEndpointsUrlsFactory.CreateSearchLocationUrl(this.accessToken, distance, facebookPlacesId, foursquareId, lat, lng, foursquareV2Id));
                string responseContent = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    return responseContent;
                }
                else
                {
                    throw new InstagramAPIException(responseContent);
                }
            }
        }
    }
}

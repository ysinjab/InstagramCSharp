using InstagramCSharp.Exceptions;
using InstagramCSharp.Factories;
using System.Net.Http;
using System.Threading.Tasks;

namespace InstagramCSharp.Endpoints
{
    public class LocationEndpoints
    {

        /// <summary>
        /// Get information about a location.
        /// </summary>
        /// <param name="accessToken" type="string">
        ///     <para>
        ///         A valid access token.
        ///     </para>
        /// </param> 
        /// <returns>JSON result string.</returns>
        public async Task<string> GetLocationInfoAsync(long locationId, string accessToken)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(LocationEndpointsUrlsFactory.CreateLocationInfoUrl(locationId, accessToken));
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
        /// <param name="accessToken" type="string">
        ///     <para>
        ///         A valid access token.
        ///     </para>
        /// </param>
        /// <param name="minId">Return media before this min_id.</param>
        /// <param name="maxId">Return media after this max_id.</param>
        /// <returns>JSON result string.</returns>
        public async Task<string> GetRecentLocationMediaAsync(long locationId, string accessToken, string minId = null, string maxId = null)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(LocationEndpointsUrlsFactory.CreateRecentLocationMediaUrl(locationId, accessToken, minId, maxId));
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
        /// <param name="accessToken" type="string">
        ///     <para>
        ///         A valid access token.
        ///     </para>
        /// </param> 
        /// <param name="distance">Default is 1000m (distance=1000), max distance is 5000.</param>
        /// <param name="facebookPlacesId">Returns a location mapped off of a Facebook places id. If used, a Foursquare id and lat, lng are not required.</param>
        /// <param name="foursquareId">Returns a location mapped off of a foursquare v1 api location id. If used, you are not required to use lat and lng. Note that this method is deprecated; you should use the new foursquare IDs with V2 of their API.</param>
        /// <param name="lat">Latitude of the center search coordinate. If used, lng is required.</param>
        /// <param name="lng">Longitude of the center search coordinate. If used, lat is required.</param>
        /// <param name="foursquareV2Id">Returns a location mapped off of a foursquare v2 api location id. If used, you are not required to use lat and lng.</param>
        public async Task<string> SearchLocationAsync(string accessToken, double distance = 1000, double lat = 0, double lng = 0, string facebookPlacesId = null, string foursquareId = null, string foursquareV2Id = null)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(LocationEndpointsUrlsFactory.CreateSearchLocationUrl(accessToken, distance, facebookPlacesId, foursquareId, lat, lng, foursquareV2Id));
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

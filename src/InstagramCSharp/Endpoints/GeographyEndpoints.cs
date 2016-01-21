using InstagramCSharp.Exceptions;
using InstagramCSharp.Factories;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace InstagramCSharp.Endpoints
{
    [Obsolete("Deprecation of /geographies/media/recent.")]
    public class GeographyEndpoints
    {
        private string clientId;
        public GeographyEndpoints(string clientId)
        {
            this.clientId = clientId;
        }
        /// <summary>
        /// Get recent media from a geography subscription that you created. 
        /// Note: You can only access Geographies that were explicitly created by your OAuth client.
        /// Check the Geography Subscriptions section of the real-time updates page. When you create a subscription to some geography that you define, you will be returned a unique geo-id that can be used in this query.
        /// To backfill photos from the location covered by this geography, use the media search endpoint.
        /// </summary>
        /// <param name="count">Max number of media to return.</param>
        /// <param name="minId">Return media before this min_id.</param>
        /// <returns>JSON result string.</returns>
        public async Task<string> GetRecentGeographyMediaAsync(long geoId, int count = 0, string minId = null)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(GeographyEndpointUrlsFactory.CreateRecentGeographyMediaUrl(geoId, this.clientId, count, minId));
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

using InstagramCSharp.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InstagramCSharp.Endpoints
{
    public static class MediaEndpoints
    {
        /// <summary>
        /// Get information about a media object. The returned type key will allow you to differentiate between image and video media. 
        /// Note: if you authenticate with an OAuth Token, you will receive the user_has_liked key which quickly tells you whether the current user has liked this media item.
        /// </summary>
        /// <param name="accessToken">A valid access token.</param>
        /// <returns>JSON result string.</returns>
        public static async Task<string> GetMediaInfoAsync(string mediaId, string accessToken)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(MediaEndpointsUrlsFactory.CreateMediaInfoUrl(mediaId, accessToken));
                return response;
            }
        }
        /// <summary>
        /// Get a list of what media is most popular at the moment. Can return mix of image and video types.
        /// </summary>
        /// <param name="accessToken">A valid access token.</param>
        /// <returns>JSON result string.</returns>
        public static async Task<string> GetPopularMediaAsync(string accessToken)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(MediaEndpointsUrlsFactory.CreatePopularMediaUrl(accessToken));
                return response;
            }
        }
        /// <summary>
        /// Search for media in a given area. The default time span is set to 5 days. The time span must not exceed 7 days.
        /// Defaults time stamps cover the last 5 days. Can return mix of image and video types.
        /// </summary>
        /// <param name="accessToken">A valid access token.</param>
        /// <param name="minTimestamp">A unix timestamp. All media returned will be taken later than this timestamp.</param>
        /// <param name="maxTimestamp">A unix timestamp. All media returned will be taken earlier than this timestamp.</param>
        /// <param name="distance">Default is 1km (distance=1000), max distance is 5km.</param>
        /// <param name="lat">Latitude of the center search coordinate. If used, lng is required.</param>
        /// <param name="lng">Longitude of the center search coordinate. If used, lat is required.</param>
        /// <returns>JSON result string.</returns>
        public static async Task<string> SearchMediaAsync(string accessToken, long minTimestamp = 0, long maxTimestamp = 0, string distance = null, double lat = 0, double lng = 0)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(MediaEndpointsUrlsFactory.CreateSearchMediaUrl(accessToken, minTimestamp, maxTimestamp, distance, lat, lng));
                return response;
            }

        }
    }
}

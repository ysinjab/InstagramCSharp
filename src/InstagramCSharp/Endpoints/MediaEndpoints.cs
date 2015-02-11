using InstagramCSharp.Exceptions;
using InstagramCSharp.Factories;
using System.Net.Http;
using System.Threading.Tasks;

namespace InstagramCSharp.Endpoints
{
    public class MediaEndpoints
    {
        private string accessToken;
        public MediaEndpoints(string accessToken)
        {
            this.accessToken = accessToken;
        }        
        /// <summary>
        /// Get information about a media object. The returned type key will allow you to differentiate between image and video media. 
        /// Note: if you authenticate with an OAuth Token, you will receive the user_has_liked key which quickly tells you whether the current user has liked this media item.
        /// </summary>
        /// <param name="mediaId">Media Id.</param>
        /// <returns>JSON result string.</returns>
        public async Task<string> GetMediaInfoAsync(string mediaId)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(MediaEndpointsUrlsFactory.CreateMediaInfoUrl(mediaId, this.accessToken));
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
        /// This endpoint returns the same response as GET /media/media-id.
        /// A media object's shortcode can be found in its shortlink URL.
        /// An example shortlink is http://instagram.com/p/D/
        /// Its corresponding shortcode is D.
        /// </summary>
        /// <param name="shortCode">shortCode</param>
        public async Task<string> GetMediaInfoByShortCodeAsync(string shortCode)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(MediaEndpointsUrlsFactory.CreateShortCodeMediaInfoUrl(shortCode, this.accessToken));
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
        /// Get a list of what media is most popular at the moment. Can return mix of image and video types.
        /// </summary>
        /// <returns>JSON result string.</returns>
        public async Task<string> GetPopularMediaAsync()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(MediaEndpointsUrlsFactory.CreatePopularMediaUrl(this.accessToken));
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
        /// Search for media in a given area. The default time span is set to 5 days. The time span must not exceed 7 days.
        /// Defaults time stamps cover the last 5 days. Can return mix of image and video types.
        /// </summary>
        /// <param name="minTimestamp">A unix timestamp. All media returned will be taken later than this timestamp.</param>
        /// <param name="maxTimestamp">A unix timestamp. All media returned will be taken earlier than this timestamp.</param>
        /// <param name="distance">Default is 1km (distance=1000), max distance is 5km.</param>
        /// <param name="lat">Latitude of the center search coordinate. If used, lng is required.</param>
        /// <param name="lng">Longitude of the center search coordinate. If used, lat is required.</param>
        /// <returns>JSON result string.</returns>
        public async Task<string> SearchMediaAsync(long minTimestamp = 0, long maxTimestamp = 0, string distance = null, double lat = 0, double lng = 0)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(MediaEndpointsUrlsFactory.CreateSearchMediaUrl(this.accessToken, minTimestamp, maxTimestamp, distance, lat, lng));
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

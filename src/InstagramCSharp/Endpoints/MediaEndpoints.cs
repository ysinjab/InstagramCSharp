using InstagramCSharp.Exceptions;
using InstagramCSharp.Factories;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace InstagramCSharp.Endpoints
{
    public class MediaEndpoints
    {
        public string ClientSecret { get; private set; }
        public bool EnforceSignedRequests { get; private set; }
        public MediaEndpoints(string clientSecret, bool enforceSignedRequests)
        {
            this.ClientSecret = clientSecret;
            this.EnforceSignedRequests = enforceSignedRequests;
        }

        /// <summary>
        /// Get information about a media object. The returned type key will allow you to differentiate between image and video media. 
        /// Note: if you authenticate with an OAuth Token, you will receive the user_has_liked key which quickly tells you whether the current user has liked this media item.
        /// The public_content permission scope is required to get a media that does not belong to the owner of the access_token.
        /// </summary>
        /// <param name="mediaId">Media Id.</param>
        /// <param name="accessToken" type="string">
        ///     <para>
        ///         A valid access token.
        ///     </para>
        /// </param>
        /// <returns>JSON result string.</returns>
        public async Task<string> GetMediaInfoAsync(string mediaId, string accessToken)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                Uri uri = MediaEndpointsUrlsFactory.CreateMediaInfoUrl(mediaId, accessToken);
                if (this.EnforceSignedRequests)
                {
                    uri = uri.AddParameter("sig", Utilities.GenerateSig(string.Format(InstagramAPIEndpoints.MediaInfoEndpoint, mediaId), this.ClientSecret, uri.Query));
                }
                var response = await httpClient.GetAsync(uri);
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
        /// An example shortlink is http://instagram.com/p/tsxp1hhQTG/. 
        /// Its corresponding shortcode is tsxp1hhQTG.
        /// </summary>
        /// <param name="shortCode">shortCode</param>
        /// <param name="accessToken" type="string">
        ///     <para>
        ///         A valid access token.
        ///     </para>
        /// </param> 
        public async Task<string> GetMediaInfoByShortCodeAsync(string shortCode, string accessToken)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                Uri uri = MediaEndpointsUrlsFactory.CreateShortCodeMediaInfoUrl(shortCode, accessToken);
                if (this.EnforceSignedRequests)
                {
                    uri = uri.AddParameter("sig", Utilities.GenerateSig(string.Format(InstagramAPIEndpoints.ShortCodeMediaInfoEndpoint, shortCode), this.ClientSecret, uri.Query));
                }
                var response = await httpClient.GetAsync(uri);
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
        /// Search for recent media in a given area.
        /// </summary>    
        /// <param name="accessToken" type="string">
        ///     <para>
        ///         A valid access token.
        ///     </para>
        /// </param> 
        /// <param name="distance">Default is 1km (distance=1000), max distance is 5km.</param>
        /// <param name="lat">Latitude of the center search coordinate. If used, lng is required.</param>
        /// <param name="lng">Longitude of the center search coordinate. If used, lat is required.</param>
        /// <returns>JSON result string.</returns>
        public async Task<string> SearchMediaAsync(string accessToken, double distance = 1000, double lat = 0, double lng = 0)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                Uri uri = MediaEndpointsUrlsFactory.CreateSearchMediaUrl(accessToken, distance, lat, lng);
                if (this.EnforceSignedRequests)
                {
                    uri = uri.AddParameter("sig", Utilities.GenerateSig(InstagramAPIEndpoints.SearchMediaEndpoint, this.ClientSecret, uri.Query));
                }
                var response = await httpClient.GetAsync(uri);
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

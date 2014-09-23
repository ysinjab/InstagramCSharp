using InstagramCSharp.Factories;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace InstagramCSharp.Endpoints
{
    public class LikeEndpoints
    {
        private string accessToken;
        public LikeEndpoints(string accessToken)
        {
            this.accessToken = accessToken;
        }
        /// <summary>
        /// Get a list of users who have liked this media.
        /// Required scope: likes
        /// </summary>
        /// <returns>JSON result string.</returns>
        public async Task<string> GetMediaLikesAsync(string mediaId)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(LikeEndpointsUrlsFactory.CreateGETLikeUrl(mediaId, this.accessToken));
                return response;
            }
        }

        /// <summary>
        /// Set a like on this media by the currently authenticated user.
        /// Required scope: likes
        /// </summary>
        /// <returns>HttpResponseMessage Object.</returns>
        public async Task<HttpResponseMessage> PosLikeAsync(string mediaId)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var content = BuildFormUrlEncodedContent(this.accessToken);
                var response = await httpClient.PostAsync(LikeEndpointsUrlsFactory.CreatePOSTLikeUrl(mediaId), content);
                return response;
            }
        }

        /// <summary>
        /// Remove a like on this media by the currently authenticated user.
        /// Required scope: likes
        /// </summary>
        /// <returns>HttpResponseMessage Object.</returns>
        public async Task<HttpResponseMessage> DeleteLikeAsync(string mediaId)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync(LikeEndpointsUrlsFactory.CreateDELETELikeUrl(mediaId, this.accessToken));
                return response;
            }
        }
        private FormUrlEncodedContent BuildFormUrlEncodedContent(string accessToken)
        {
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("access_token", accessToken));
            FormUrlEncodedContent content = new FormUrlEncodedContent(postData);
            return content;
        }
    }
}

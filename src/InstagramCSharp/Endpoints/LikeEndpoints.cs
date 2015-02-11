using InstagramCSharp.Exceptions;
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
                var response = await httpClient.GetAsync(LikeEndpointsUrlsFactory.CreateGETLikeUrl(mediaId, this.accessToken));
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
        /// Set a like on this media by the currently authenticated user.
        /// Required scope: likes
        /// </summary>
        public async Task<string> PosLikeAsync(string mediaId)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var content = BuildFormUrlEncodedContent(this.accessToken);
                var response = await httpClient.PostAsync(LikeEndpointsUrlsFactory.CreatePOSTLikeUrl(mediaId), content);
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
        /// Remove a like on this media by the currently authenticated user.
        /// Required scope: likes
        /// </summary>
        public async Task<string> DeleteLikeAsync(string mediaId)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync(LikeEndpointsUrlsFactory.CreateDELETELikeUrl(mediaId, this.accessToken));
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
        private FormUrlEncodedContent BuildFormUrlEncodedContent(string accessToken)
        {
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("access_token", accessToken));
            FormUrlEncodedContent content = new FormUrlEncodedContent(postData);
            return content;
        }
    }
}

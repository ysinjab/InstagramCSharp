using InstagramCSharp.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InstagramCSharp.Endpoints
{
    public static class LikeEndpoints
    {
        /// <summary>
        /// Get a list of users who have liked this media.
        /// Required scope: likes
        /// </summary>
        /// <param name="accessToken">A valid access token.</param>
        /// <returns>JSON result string.</returns>
        public static async Task<string> GetMediaCommentsAsync(string mediaId, string accessToken)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(LikeEndpointsUrlsFactory.CreateGETLikeUrl(mediaId, accessToken));
                return response;
            }
        }

        /// <summary>
        /// Set a like on this media by the currently authenticated user.
        /// Required scope: likes
        /// </summary>
        /// <param name="accessToken">A valid access token.</param>
        /// <returns>HttpResponseMessage Object.</returns>
        public static async Task<HttpResponseMessage> PostMediaCommentAsync(string mediaId, string accessToken)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var content = BuildFormUrlEncodedContent(accessToken);
                var response = await httpClient.PostAsync(LikeEndpointsUrlsFactory.CreatePOSTLikeUrl(mediaId), content);
                return response;
            }
        }

        /// <summary>
        /// Remove a like on this media by the currently authenticated user.
        /// Required scope: likes
        /// </summary>
        /// <param name="accessToken">A valid access token.</param>
        /// <returns>HttpResponseMessage Object.</returns>
        public static async Task<HttpResponseMessage> DeleteMediaCommentAsync(string mediaId, string accessToken)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync(LikeEndpointsUrlsFactory.CreateDELETELikeUrl(mediaId,accessToken));
                return response;
            }
        }
        private static FormUrlEncodedContent BuildFormUrlEncodedContent(string accessToken)
        {
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("access_token", accessToken));
            FormUrlEncodedContent content = new FormUrlEncodedContent(postData);
            return content;
        }
    }
}

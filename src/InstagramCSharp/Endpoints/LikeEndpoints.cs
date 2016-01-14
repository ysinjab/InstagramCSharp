using InstagramCSharp.Exceptions;
using InstagramCSharp.Factories;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace InstagramCSharp.Endpoints
{
    public class LikeEndpoints
    {
       
        /// <summary>
        /// Get a list of users who have liked this media.
        /// Required scope: likes
        /// </summary>
        /// <param name="accessToken" type="string">
        ///     <para>
        ///         A valid access token.
        ///     </para>
        /// </param> 
        /// <returns>JSON result string.</returns>
        public async Task<string> GetMediaLikesAsync(string mediaId, string accessToken)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(LikeEndpointsUrlsFactory.CreateGETLikeUrl(mediaId, accessToken));
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
        /// <param name="accessToken" type="string">
        ///     <para>
        ///         A valid access token.
        ///     </para>
        /// </param>
        public async Task<string> PosLikeAsync(string mediaId, string accessToken)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var content = BuildFormUrlEncodedContent(accessToken);
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
        /// <param name="accessToken" type="string">
        ///     <para>
        ///         A valid access token.
        ///     </para>
        /// </param> 
        public async Task<string> DeleteLikeAsync(string mediaId, string accessToken)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync(LikeEndpointsUrlsFactory.CreateDELETELikeUrl(mediaId, accessToken));
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

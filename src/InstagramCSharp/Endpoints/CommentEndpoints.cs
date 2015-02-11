using InstagramCSharp.Exceptions;
using InstagramCSharp.Factories;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace InstagramCSharp.Endpoints
{
    public class CommentEndpoints
    {
        private string accessToken;
        public CommentEndpoints(string accessToken)
        {
            this.accessToken = accessToken;
        }
        /// <summary>
        /// Get a full list of comments on a media.
        /// Required scope: comments.
        /// </summary>
        /// <param name="mediaId"></param>
        /// <returns>JSON result string.</returns>
        public async Task<string> GetMediaCommentsAsync(string mediaId)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(CommentEndpointsUrlsFactory.CreateGETCommentUrl(mediaId, this.accessToken));
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
        /// Create a comment on a media. Please email apidevelopers[at]instagram.com for access.
        /// Required scope: comments.
        /// </summary>
        /// <param name="mediaId"></param>
        /// <param name="text">Text to post as a comment on the media as specified in media-id.</param>
        public async Task<string> PostMediaCommentAsync(string mediaId, string text)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var content = BuildFormUrlEncodedContent(this.accessToken, text);
                var response = await httpClient.PostAsync(CommentEndpointsUrlsFactory.CreatePOSTCommentUrl(mediaId), content);
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
        /// Remove a comment either on the authenticated user's media or authored by the authenticated user.
        /// Required scope: comments.
        /// </summary>       
        public async Task<string> DeleteMediaCommentAsync(string mediaId, string commentId)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync(CommentEndpointsUrlsFactory.CreateDELETECommentUrl(mediaId, commentId, this.accessToken));
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
        private FormUrlEncodedContent BuildFormUrlEncodedContent(string accessToken, string text)
        {
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("access_token", accessToken));
            postData.Add(new KeyValuePair<string, string>("text", text));
            FormUrlEncodedContent content = new FormUrlEncodedContent(postData);
            return content;
        }
    }
}

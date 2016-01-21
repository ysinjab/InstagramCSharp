using InstagramCSharp.Exceptions;
using InstagramCSharp.Factories;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace InstagramCSharp.Endpoints
{
    public class CommentEndpoints
    {
        public string ClientSecret { get; private set; }
        public bool EnforceSignedRequests { get; private set; }
        public CommentEndpoints(string clientSecret, bool enforceSignedRequests)
        {
            this.ClientSecret = clientSecret;
            this.EnforceSignedRequests = enforceSignedRequests;
        }

        /// <summary>
        /// Get a list of recent comments on a media object. The public_content permission scope is required to get comments for a media that does not belong to the owner of the access_token.
        /// Required scope: comments.
        /// </summary>
        /// <param name="mediaId"></param>
        /// <param name="accessToken" type="string">
        ///     <para>
        ///         A valid access token.
        ///     </para>
        /// </param> 
        /// <returns>JSON result string.</returns>
        public async Task<string> GetMediaCommentsAsync(string mediaId, string accessToken)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                Uri uri = CommentEndpointsUrlsFactory.CreateGETCommentsUrl(mediaId, accessToken);
                if (this.EnforceSignedRequests)
                {
                    uri = uri.AddParameter("sig", Utilities.GenerateSig(string.Format(InstagramAPIEndpoints.CommentsEndpoint, mediaId), this.ClientSecret, uri.Query));
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
        /// Create a comment on a media. Please email apidevelopers[at]instagram.com for access.
        /// Create a comment on a media object with the following rules:
        /// * The total length of the comment cannot exceed 300 characters.
        /// * The comment cannot contain more than 4 hashtags.
        /// * The comment cannot contain more than 1 URL.
        /// * The comment cannot consist of all capital letters.
        /// Required scope: comments.
        /// </summary>
        /// <param name="mediaId"></param>
        /// <param name="text">Text to post as a comment on the media as specified in media-id.</param>
        /// <param name="accessToken" type="string">
        ///     <para>
        ///         A valid access token.
        ///     </para>
        /// </param> 
        public async Task<string> PostMediaCommentAsync(string mediaId, string text, string accessToken)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var content = BuildFormUrlEncodedContent(accessToken,mediaId, text);
                Uri uri = CommentEndpointsUrlsFactory.CreatePOSTCommentUrl(mediaId);              
                var response = await httpClient.PostAsync(uri, content);
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
        ///  Remove a comment either on the authenticated user's media object or authored by the authenticated user.
        /// </summary>
        /// <param name="accessToken" type="string">
        ///     <para>
        ///         A valid access token.
        ///     </para>
        /// </param>
        public async Task<string> DeleteMediaCommentAsync(string mediaId, string commentId, string accessToken)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                Uri uri = CommentEndpointsUrlsFactory.CreateDELETECommentUrl(mediaId, commentId, accessToken);
                if (this.EnforceSignedRequests)
                {
                    uri = uri.AddParameter("sig", Utilities.GenerateSig(string.Format(InstagramAPIEndpoints.CommentEndpoint, mediaId, commentId), this.ClientSecret, uri.Query));
                }
                var response = await httpClient.DeleteAsync(uri);
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
        private FormUrlEncodedContent BuildFormUrlEncodedContent(string accessToken,string mediaId, string text)
        {
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("access_token", accessToken));
            postData.Add(new KeyValuePair<string, string>("text", text));
            if (this.EnforceSignedRequests)
            {
                 postData.Add(new KeyValuePair<string, string>("sig", 
                     Utilities.GenerateSig(string.Format(InstagramAPIEndpoints.CommentsEndpoint, mediaId), this.ClientSecret, postData)));
            }
            FormUrlEncodedContent content = new FormUrlEncodedContent(postData);
            return content;
        }
    }
}

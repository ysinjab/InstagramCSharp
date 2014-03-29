using InstgramCSharp.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InstgramCSharp.Endpoints
{    
     public static class CommentEndpoints
    {
         /// <summary>
         /// Get a full list of comments on a media.
         /// Required scope: comments.
         /// </summary>
         /// <param name="mediaId"></param>
         /// <param name="accessToken">A valid access token.</param>
         /// <returns>JSON result string.</returns>
         public static async Task<string> GetMediaCommentsAsync(string mediaId, string accessToken)
         {
             using (HttpClient httpClient = new HttpClient())
             {
                 var response = await httpClient.GetStringAsync(CommentEndpointsUrlsFactory.CreateGETCommentUrl(mediaId,accessToken));
                 return response;
             }
         }
         /// <summary>
         /// Create a comment on a media. Please email apidevelopers[at]instagram.com for access.
         /// Required scope: comments.
         /// </summary>
         /// <param name="mediaId"></param>
         /// <param name="accessToken">A valid access token.</param>
         /// <param name="text">Text to post as a comment on the media as specified in media-id.</param>
         /// <returns>HttpResponseMessage Object.</returns>
         public static async Task<HttpResponseMessage> PostMediaCommentAsync(string mediaId, string accessToken, string text)
         {
             using (HttpClient httpClient = new HttpClient())
             {
                 var content = BuildFormUrlEncodedContent(accessToken, text);
                 var response = await httpClient.PostAsync(CommentEndpointsUrlsFactory.CreatePOSTCommentUrl(mediaId), content);
                 return response;
             }
         }
         /// <summary>
         /// Remove a comment either on the authenticated user's media or authored by the authenticated user.
         /// Required scope: comments.
         /// </summary>
         /// <param name="accessToken">A valid access token.</param>
         /// <returns>HttpResponseMessage Object.</returns>
         public static async Task<HttpResponseMessage> DeleteMediaCommentAsync(string mediaId, ulong commentId, string accessToken)
         {
             using (HttpClient httpClient = new HttpClient())
             {
                 var response = await httpClient.DeleteAsync(CommentEndpointsUrlsFactory.CreateDELETECommentUrl(mediaId, commentId, accessToken));
                 return response;
             }
         }
         private static FormUrlEncodedContent BuildFormUrlEncodedContent(string accessToken, string text)
         {
             var postData = new List<KeyValuePair<string, string>>();
             postData.Add(new KeyValuePair<string, string>("access_token", accessToken));
             postData.Add(new KeyValuePair<string, string>("text", text));           
             FormUrlEncodedContent content = new FormUrlEncodedContent(postData);
             return content;
         }
    }
}

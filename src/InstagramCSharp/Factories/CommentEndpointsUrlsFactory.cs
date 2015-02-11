using System.Web;

namespace InstagramCSharp.Factories
{
    public static class CommentEndpointsUrlsFactory
    {
        public static string CreateGETCommentUrl(string mediaId, string accessToken)
        {
            var queryString = BuildCommentEndpointsUrlQueryString(accessToken);
            return BuildCommentUrl(mediaId, InstagramAPIUrls.MediaEndpointsUrl, queryString);
        }
        public static string CreatePOSTCommentUrl(string mediaId)
        {
            return BuildCommentUrl(mediaId, InstagramAPIUrls.MediaEndpointsUrl);
        }
        public static string CreateDELETECommentUrl(string mediaId, string commentId, string accessToken)
        {
            var queryString = BuildCommentEndpointsUrlQueryString(accessToken);
            return BuildCommentUrl(mediaId, InstagramAPIUrls.MediaEndpointsUrl, queryString, commentId);
        }      
        private static string BuildCommentEndpointsUrlQueryString(string accessToken)
        {
            var queryString = HttpUtility.ParseQueryString("");
            queryString["access_token"] = accessToken;
            return queryString.ToString();
        }
        private static string BuildCommentUrl(string mediaId, string url, string queryString = null, string commentId =null)
        {
            if (queryString==null)
            {
                url = string.Format(url + "/{0}/comments", mediaId);
                return url;
            }
            if (commentId != null)
            {
                url = string.Format(url + "/{0}/comments/{1}", mediaId, commentId);
                return url + "?" + queryString;
            }
            else
            {
                url = string.Format(url + "/{0}/comments", mediaId);
                return url + "?" + queryString;
            }
        }
    }
}

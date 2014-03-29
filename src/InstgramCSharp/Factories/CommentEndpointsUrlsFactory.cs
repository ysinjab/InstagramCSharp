using System.Web;

namespace InstgramCSharp.Factories
{
    public static class CommentEndpointsUrlsFactory
    {
        public static string CreateGETCommentUrl(string mediaId, string accessToken)
        {
            var queryString = BuildCommentEndpointsUrlQueryString(accessToken);
            return BuildCommentUrl(mediaId, InstgramAPIUrls.MediaEndpointsUrl, queryString);
        }
        public static string CreatePOSTCommentUrl(string mediaId)
        {
            return BuildCommentUrl(mediaId, InstgramAPIUrls.MediaEndpointsUrl);
        }
        public static string CreateDELETECommentUrl(string mediaId, ulong commentId, string accessToken)
        {
            var queryString = BuildCommentEndpointsUrlQueryString(accessToken);
            return BuildCommentUrl(mediaId, InstgramAPIUrls.MediaEndpointsUrl, queryString, commentId);
        }      
        private static string BuildCommentEndpointsUrlQueryString(string accessToken)
        {
            var queryString = HttpUtility.ParseQueryString("");
            queryString["access_token"] = accessToken;
            return queryString.ToString();
        }
        private static string BuildCommentUrl(string mediaId, string url, string queryString = null, ulong commentId = 0)
        {
            if (queryString==null)
            {
                url = string.Format(url + "/{0}/comments", mediaId);
                return url;
            }
            if (commentId != 0)
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

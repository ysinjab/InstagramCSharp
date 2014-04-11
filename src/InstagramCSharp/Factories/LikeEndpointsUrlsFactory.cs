using System.Web;

namespace InstagramCSharp.Factories
{
    public class LikeEndpointsUrlsFactory
    {
        public static string CreateGETLikeUrl(string mediaId, string accessToken)
        {
            var queryString = BuildLikeEndpointsUrlQueryString(accessToken);
            return BuildLikeUrl(mediaId, InstagramAPIUrls.MediaEndpointsUrl, queryString);
        }
        public static string CreatePOSTLikeUrl(string mediaId)
        {
            return BuildLikeUrl(mediaId, InstagramAPIUrls.MediaEndpointsUrl);
        }
        public static string CreateDELETELikeUrl(string mediaId, string accessToken)
        {
            var queryString = BuildLikeEndpointsUrlQueryString(accessToken);
            return BuildLikeUrl(mediaId, InstagramAPIUrls.MediaEndpointsUrl, queryString);
        }
        private static string BuildLikeEndpointsUrlQueryString(string accessToken)
        {
            var queryString = HttpUtility.ParseQueryString("");
            queryString["access_token"] = accessToken;
            return queryString.ToString();
        }
        private static string BuildLikeUrl(string mediaId, string url, string queryString = null)
        {
            url = string.Format(url + "/{0}/likes", mediaId);
            if (queryString==null)
            {
                return url;
            }
            else
            {
                return url + "?" + queryString;
            }           
        }    
    }
}

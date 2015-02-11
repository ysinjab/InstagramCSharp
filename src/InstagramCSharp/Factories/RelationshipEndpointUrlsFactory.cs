using InstagramCSharp.Enums;
using System.Web;
namespace InstagramCSharp.Factories
{
    public static class RelationshipEndpointUrlsFactory
    {
        public static string CreateUserFollowsUrl(long userId, string accessToken)
        {
            var queryString = BuildRelationshipEndpointUrlsQueryString(accessToken);
            return BuildUserFollowsUrl(userId, InstagramAPIUrls.RelationshipsEndpointsUrl, queryString);
        }
        public static string CreateUserFollowedByUrl(long userId, string accessToken)
        {
            var queryString = BuildRelationshipEndpointUrlsQueryString(accessToken);
            return BuildUserFollowedByUrl(userId, InstagramAPIUrls.RelationshipsEndpointsUrl, queryString);

        }
        public static string CreateRequestedByUrl(string accessToken)
        {
            var queryString = BuildRelationshipEndpointUrlsQueryString(accessToken);
            return BuildRequestedByUrl(InstagramAPIUrls.RelationshipsEndpointsUrl, queryString);
        }
        public static string CreateRelationshipUrl(long userId, string accessToken)
        {
            var queryString = BuildRelationshipEndpointUrlsQueryString(accessToken);
            return BuildRelationshipUrl(userId, InstagramAPIUrls.RelationshipsEndpointsUrl, queryString);
        }
        public static string CreatePOSTRelationshipActionUrl(long userId, string accessToken, RelationshipActions relationshipAction)
        {
            var queryString = BuildPOSTRelationshipActionUrlQueryString(accessToken, relationshipAction);
            return BuildRelationshipUrl(userId, InstagramAPIUrls.RelationshipsEndpointsUrl, queryString);
        }
        private static string BuildRelationshipEndpointUrlsQueryString(string accessToken)
        {
            var queryString = HttpUtility.ParseQueryString("");
            queryString["access_token"] = accessToken;
            return queryString.ToString();
        }
        private static string BuildPOSTRelationshipActionUrlQueryString(string accessToken, RelationshipActions relationshipAction)
        {
            var queryString = HttpUtility.ParseQueryString("");
            queryString["access_token"] = accessToken;
            switch (relationshipAction)
            {
                case RelationshipActions.Follow:
                    queryString["action"] = "follow";
                    break;
                case RelationshipActions.Unfollow:
                    queryString["action"] = "unfollow";
                    break;
                case RelationshipActions.Block:
                    queryString["action"] = "block";
                    break;
                case RelationshipActions.Unblock:
                    queryString["action"] = "unblock";
                    break;
                case RelationshipActions.Approve:
                    queryString["action"] = "approve";
                    break;
                case RelationshipActions.Ignore:
                    queryString["action"] = "ignore";
                    break;
            }
            return queryString.ToString();
        }
        private static string BuildUserFollowsUrl(long userId, string url, string queryString)
        {
            url = string.Format(url + "/{0}/follows", userId);
            return url + "?" + queryString;
        }

        private static string BuildUserFollowedByUrl(long userId, string url, string queryString)
        {
            url = string.Format(url + "/{0}/followed-by", userId);
            return url + "?" + queryString;
        }
        private static string BuildRequestedByUrl(string url, string queryString)
        {
            url = url + "/self/requested-by";
            return url + "?" + queryString;
        }
        private static string BuildRelationshipUrl(long userId, string url, string queryString)
        {
            url = string.Format(url + "/{0}/relationship", userId);
            return url + "?" + queryString;
        }
    }
}

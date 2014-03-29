using InstgramCSharp.Enums;
using System.Web;
namespace InstgramCSharp.Factories
{
    public static class RelationshipEndpointUrlsFactory
    {
        public static string CreateUserFollowsUrl(ulong userId, string accessToken)
        {

            var queryString = BuildRelationshipEndpointUrlsQueryString(accessToken);
            return BuildUserFollowsUrl(userId, InstgramAPIUrls.RelationshipsEndpointsUrl, queryString);
        }
        public static string CreateUserFollowedByUrl(ulong userId, string accessToken)
        {

            var queryString = BuildRelationshipEndpointUrlsQueryString(accessToken);
            return BuildUserFollowedByUrl(userId, InstgramAPIUrls.RelationshipsEndpointsUrl, queryString);

        }
        public static string CreateRequestedByUrl(string accessToken)
        {

            var queryString = BuildRelationshipEndpointUrlsQueryString(accessToken);
            return BuildRequestedByUrl(InstgramAPIUrls.RelationshipsEndpointsUrl, queryString);
        }
        public static string CreateRelationshipUrl(ulong userId, string accessToken)
        {

            var queryString = BuildRelationshipEndpointUrlsQueryString(accessToken);
            return BuildRelationshipUrl(userId, InstgramAPIUrls.RelationshipsEndpointsUrl, queryString);
        }
        public static string CreatePOSTRlationshipActionUrl(ulong userId, string accessToken, RelationshipActions relationshipAction)
        {
            var queryString = BuildPOSTRlationshipActionUrlQueryString(accessToken, relationshipAction);
            return BuildRelationshipUrl(userId, InstgramAPIUrls.RelationshipsEndpointsUrl, queryString);

        }
        private static string BuildRelationshipEndpointUrlsQueryString(string accessToken)
        {
            var queryString = HttpUtility.ParseQueryString("");
            queryString["access_token"] = accessToken;
            return queryString.ToString();
        }
        private static string BuildPOSTRlationshipActionUrlQueryString(string accessToken, RelationshipActions relationshipAction)
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
                case RelationshipActions.Deny:
                    queryString["action"] = "deny";
                    break;
            }
            return queryString.ToString();
        }
        private static string BuildUserFollowsUrl(ulong userId, string url, string queryString)
        {
            url = string.Format(url + "/{0}/follows", userId);
            return url + "?" + queryString;
        }

        private static string BuildUserFollowedByUrl(ulong userId, string url, string queryString)
        {
            url = string.Format(url + "/{0}/followed-by", userId);
            return url + "?" + queryString;
        }
        private static string BuildRequestedByUrl(string url, string queryString)
        {
            url = url + "/self/requested-by";
            return url + "?" + queryString;
        }
        private static string BuildRelationshipUrl(ulong userId, string url, string queryString)
        {
            url = string.Format(url + "/{0}/relationship", userId);
            return url + "?" + queryString;
        }
    }
}

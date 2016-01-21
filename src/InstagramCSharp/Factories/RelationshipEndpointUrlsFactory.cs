using InstagramCSharp.Enums;
using System;
using System.Web;
namespace InstagramCSharp.Factories
{
    public static class RelationshipEndpointUrlsFactory
    {
        public static Uri CreateUserFollowsUrl(string accessToken)
        {
            var queryString = BuildRelationshipEndpointUrlsQueryString(accessToken);
            return new Uri(InstagramAPIUrls.BaseAPIUrl + InstagramAPIEndpoints.UserFollowsEndpoint + "?" + queryString);
        }
        public static Uri CreateUserFollowedByUrl(string accessToken)
        {
            var queryString = BuildRelationshipEndpointUrlsQueryString(accessToken);
            return new Uri(InstagramAPIUrls.BaseAPIUrl + InstagramAPIEndpoints.UserFollowedByEndpoint + "?" + queryString);
        }
        public static Uri CreateRequestedByUrl(string accessToken)
        {
            var queryString = BuildRelationshipEndpointUrlsQueryString(accessToken);
            return new Uri(InstagramAPIUrls.BaseAPIUrl + InstagramAPIEndpoints.RequestedByEndpoint + "?" + queryString);
        }
        public static Uri CreateRelationshipUrl(long userId, string accessToken)
        {
            var queryString = BuildRelationshipEndpointUrlsQueryString(accessToken);
            return new Uri(InstagramAPIUrls.BaseAPIUrl + string.Format(InstagramAPIEndpoints.RelationshipEndpoint, userId) + "?" + queryString);
        }
        public static Uri CreatePOSTRelationshipActionUrl(long userId, string accessToken, RelationshipActions relationshipAction)
        {
            var queryString = BuildPOSTRelationshipActionUrlQueryString(accessToken, relationshipAction);
            return new Uri(InstagramAPIUrls.BaseAPIUrl + string.Format(InstagramAPIEndpoints.RelationshipEndpoint, userId) + "?" + queryString);
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
    }
}

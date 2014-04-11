﻿using InstagramCSharp.Enums;
using InstagramCSharp.Factories;
using System.Net.Http;
using System.Threading.Tasks;

namespace InstagramCSharp.Endpoints
{
    public class RelationshipEndpoints
    {
        private string accessToken;
        public RelationshipEndpoints(string accessToken)
        {
            this.accessToken = accessToken;
        }
        /// <summary>
        /// Get information about a relationship to another user.
        /// Required scope: relationships.
        /// </summary>
        /// <returns>JSON result string.</returns>
        public async Task<string> GetRelationshipInfoAsync(ulong userId)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(RelationshipEndpointUrlsFactory.CreateRelationshipUrl(userId, this.accessToken));
                return response;
            }
        }
        /// <summary>
        /// List the users who have requested this user's permission to follow.
        /// Required scope: relationships.
        /// </summary>
        /// <returns>JSON result string.</returns>
        public async Task<string> GetRequestedByAsync()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(RelationshipEndpointUrlsFactory.CreateRequestedByUrl(this.accessToken));
                return response;
            }
        }
        /// <summary>
        /// Get the list of users this user follows.
        /// Required scope: relationships.
        /// </summary>
        /// <returns>JSON result string.</returns>
        public async Task<string> GetFollowsAsync(ulong userId)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(RelationshipEndpointUrlsFactory.CreateUserFollowedByUrl(userId, this.accessToken));
                return response;
            }
        }
        /// <summary>
        /// Get the list of users this user is followed by.
        /// Required scope: relationships.
        /// </summary>
        /// <returns>JSON result string.</returns>
        public async Task<string> GetFollowedByAsync(ulong userId)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(RelationshipEndpointUrlsFactory.CreateUserFollowsUrl(userId, this.accessToken));
                return response;
            }
        }
        /// <summary>
        /// Modify the relationship between the current user and the target user.
        /// Required scope: relationships.
        /// </summary>
        /// <param name="relationshipAction">One of follow/unfollow/block/unblock/approve/deny.</param>
        /// <returns>HttpResponseMessage Object.</returns>
        public async Task<HttpResponseMessage> PostRelationshipActionAsync(ulong userId, RelationshipActions relationshipAction)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync(RelationshipEndpointUrlsFactory.CreatePOSTRelationshipActionUrl(userId, this.accessToken, relationshipAction), null);
                return response;
            }
        }
    }
}

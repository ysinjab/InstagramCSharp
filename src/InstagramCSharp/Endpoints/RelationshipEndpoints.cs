﻿using InstagramCSharp.Enums;
using InstagramCSharp.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InstagramCSharp.Endpoints
{
    public static class RelationshipEndpoints
    {
        /// <summary>
        /// Get information about a relationship to another user.
        /// Required scope: relationships.
        /// </summary>
        /// <param name="accessToken">A valid access token.</param>
        /// <returns>JSON result string.</returns>
        public static async Task<string> GetRelationshipInfoAsync(ulong userId, string accessToken)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(RelationshipEndpointUrlsFactory.CreateRelationshipUrl(userId, accessToken));
                return response;
            }
        }
        /// <summary>
        /// List the users who have requested this user's permission to follow.
        /// Required scope: relationships.
        /// </summary>
        /// <param name="accessToken">A valid access token.</param>
        /// <returns>JSON result string.</returns>
        public static async Task<string> GetRequestedByAsync(string accessToken)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(RelationshipEndpointUrlsFactory.CreateRequestedByUrl(accessToken));
                return response;
            }
        }
        /// <summary>
        /// Get the list of users this user follows.
        /// Required scope: relationships.
        /// </summary>
        /// <param name="accessToken">A valid access token.</param>
        /// <returns>JSON result string.</returns>
        public static async Task<string> GetFollowsAsync(ulong userId, string accessToken)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(RelationshipEndpointUrlsFactory.CreateUserFollowedByUrl(userId, accessToken));
                return response;
            }
        }
        /// <summary>
        /// Get the list of users this user is followed by.
        /// Required scope: relationships.
        /// </summary>
        /// <param name="accessToken">A valid access token.</param>
        /// <returns>JSON result string.</returns>
        public static async Task<string> GetFollowedByAsync(ulong userId, string accessToken)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(RelationshipEndpointUrlsFactory.CreateUserFollowsUrl(userId, accessToken));
                return response;
            }
        }
        /// <summary>
        /// Modify the relationship between the current user and the target user.
        /// Required scope: relationships.
        /// </summary>
        /// <param name="accessToken">A valid access token.</param>
        /// <param name="relationshipAction">One of follow/unfollow/block/unblock/approve/deny.</param>
        /// <returns>HttpResponseMessage Object.</returns>
        public static async Task<HttpResponseMessage> PostRelationshipActionAsync(ulong userId, string accessToken, RelationshipActions relationshipAction)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync(RelationshipEndpointUrlsFactory.CreatePOSTRelationshipActionUrl(userId, accessToken, relationshipAction), null);
                return response;
            }
        }



    }
}

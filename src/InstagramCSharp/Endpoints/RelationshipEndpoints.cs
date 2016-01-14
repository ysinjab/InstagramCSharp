﻿using InstagramCSharp.Enums;
using InstagramCSharp.Exceptions;
using InstagramCSharp.Factories;
using System.Net.Http;
using System.Threading.Tasks;

namespace InstagramCSharp.Endpoints
{
    public class RelationshipEndpoints
    {       
        /// <summary>
        /// Get information about a relationship to another user.
        /// Required scope: relationships.
        /// </summary>
        /// <returns>JSON result string.</returns>
        public async Task<string> GetRelationshipInfoAsync(long userId, string accessToken)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(RelationshipEndpointUrlsFactory.CreateRelationshipUrl(userId, accessToken));
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
        /// List the users who have requested this user's permission to follow.
        /// Required scope: relationships.
        /// </summary>
        /// <returns>JSON result string.</returns>
        public async Task<string> GetRequestedByAsync(string accessToken)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(RelationshipEndpointUrlsFactory.CreateRequestedByUrl(accessToken));
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
        /// Get the list of users this user follows.
        /// Required scope: relationships.
        /// </summary>
        /// <returns>JSON result string.</returns>
        public async Task<string> GetFollowsAsync(long userId, string accessToken)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(RelationshipEndpointUrlsFactory.CreateUserFollowedByUrl(userId, accessToken));
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
        /// Get the list of users this user is followed by.
        /// Required scope: relationships.
        /// </summary>
        /// <returns>JSON result string.</returns>
        public async Task<string> GetFollowedByAsync(long userId, string accessToken)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(RelationshipEndpointUrlsFactory.CreateUserFollowsUrl(userId, accessToken));
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
        /// Modify the relationship between the current user and the target user.
        /// Required scope: relationships.
        /// </summary>
        /// <param name="relationshipAction">One of follow/unfollow/block/unblock/approve/deny.</param>
        public async Task<string> PostRelationshipActionAsync(long userId, string accessToken, RelationshipActions relationshipAction)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync(RelationshipEndpointUrlsFactory.CreatePOSTRelationshipActionUrl(userId, accessToken, relationshipAction), null);
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
    }
}

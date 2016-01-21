﻿using InstagramCSharp.Enums;
using InstagramCSharp.Exceptions;
using InstagramCSharp.Factories;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace InstagramCSharp.Endpoints
{
    public class RelationshipEndpoints
    {
        public string ClientSecret { get; private set; }
        public bool EnforceSignedRequests { get; private set; }
        public RelationshipEndpoints(string clientSecret, bool enforceSignedRequests)
        {
            this.ClientSecret = clientSecret;
            this.EnforceSignedRequests = enforceSignedRequests;
        }

        /// <summary>
        /// Get information about a relationship to another user.
        /// Required scope: relationships.
        /// </summary>
        /// <returns>JSON result string.</returns>
        public async Task<string> GetRelationshipInfoAsync(long userId, string accessToken)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                Uri uri = RelationshipEndpointUrlsFactory.CreateRelationshipUrl(userId, accessToken);
                if (this.EnforceSignedRequests)
                {
                    uri = uri.AddParameter("sig", Utilities.GenerateSig(string.Format(InstagramAPIEndpoints.RelationshipEndpoint, userId), this.ClientSecret, uri.Query));
                }
                var response = await httpClient.GetAsync(uri);
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
                Uri uri = RelationshipEndpointUrlsFactory.CreateRequestedByUrl(accessToken);
                if (this.EnforceSignedRequests)
                {
                    uri = uri.AddParameter("sig", Utilities.GenerateSig(InstagramAPIEndpoints.RequestedByEndpoint, this.ClientSecret, uri.Query));
                }
                var response = await httpClient.GetAsync(uri);
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
        public async Task<string> GetFollowsAsync(string accessToken)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                Uri uri = RelationshipEndpointUrlsFactory.CreateUserFollowsUrl(accessToken);
                if (this.EnforceSignedRequests)
                {
                    uri = uri.AddParameter("sig", Utilities.GenerateSig(InstagramAPIEndpoints.UserFollowedByEndpoint, this.ClientSecret, uri.Query));
                }
                var response = await httpClient.GetAsync(uri);
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
        public async Task<string> GetFollowedByAsync(string accessToken)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                Uri uri = RelationshipEndpointUrlsFactory.CreateUserFollowedByUrl(accessToken);
                if (this.EnforceSignedRequests)
                {
                    uri = uri.AddParameter("sig", Utilities.GenerateSig(InstagramAPIEndpoints.UserFollowsEndpoint, this.ClientSecret, uri.Query));
                }
                var response = await httpClient.GetAsync(uri);
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
                Uri uri = RelationshipEndpointUrlsFactory.CreatePOSTRelationshipActionUrl(userId, accessToken, relationshipAction);
                if (this.EnforceSignedRequests)
                {
                    uri = uri.AddParameter("sig", Utilities.GenerateSig(string.Format(InstagramAPIEndpoints.RelationshipEndpoint, userId), this.ClientSecret, uri.Query));
                }
                var response = await httpClient.PostAsync(uri, null);
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

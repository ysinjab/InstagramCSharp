using InstgramCSharp.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InstgramCSharp.Endpoints
{
    public static class UserEndpoints
    {
        /// <summary>
        /// Get basic information about a user.
        /// </summary>
        /// <param name="accessToken">A valid access token.</param>
        /// <returns>JSON result string.</returns>
        public static async Task<string> GetUserBasicInfoAsync(ulong userId, string accessToken)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(UserEndpointUrlsFactory.CreateUserBasicInfoUrl(userId, accessToken));
                return response;
            }
        }
        /// <summary>
        /// See the authenticated user's feed. May return a mix of both image and video types.
        /// </summary>
        /// <param name="accessToken">A valid access token.</param>
        /// <param name="count">Count of media to return.</param>
        /// <param name="minId">Return media later than this min_id.</param>
        /// <param name="maxId">Return media earlier than this max_id.</param>
        /// <returns>JSON result string.</returns>
        public static async Task<string> GetUserFeedAsync(string accessToken, int count = 0, string minId = null, string maxId = null)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(UserEndpointUrlsFactory.CreateUserFeedUrl(accessToken, count, minId, maxId));
                return response;
            }
        }

        /// <summary>
        /// Get the most recent media published by a user. May return a mix of both image and video types.
        /// </summary>
        /// <param name="accessToken">A valid access token.</param>
        /// <param name="count">Count of media to return.</param>
        /// <param name="minId">Return media later than this min_id.</param>
        /// <param name="maxId">Return media earlier than this max_id.</param>
        /// <param name="minTimestamp">Return media after this UNIX timestamp.</param>
        /// <param name="maxTimestamp">Return media before this UNIX timestamp.</param>
        /// <returns>JSON result string.</returns>
        public static async Task<string> GetUserRecentMediaByAccessTokenAsync(ulong userId, string accessToken, int count = 0, string minId = null, string maxId = null, long minTimestamp = 0, long maxTimestamp = 0)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(UserEndpointUrlsFactory.CreateUserRecentMediaByAccessTokenUrl(userId, accessToken, count, minId, maxId, minTimestamp, maxTimestamp));
                return response;
            }

        }
        /// <summary>
        /// Get the most recent media published by a user. May return a mix of both image and video types.
        /// </summary>
        /// <param name="clientId">A valid client id.</param>
        /// <param name="count">Count of media to return.</param>
        /// <param name="minId">Return media later than this min_id.</param>
        /// <param name="maxId">Return media earlier than this max_id.</param>
        /// <param name="minTimestamp">Return media after this UNIX timestamp.</param>
        /// <param name="maxTimestamp">Return media before this UNIX timestamp.</param>
        /// <returns>JSON result string.</returns>
        public static async Task<string> GetUserRecentMediaByClientIdAsync(ulong userId, string clientId, int count = 0, string minId = null, string maxId = null, long minTimestamp = 0, long maxTimestamp = 0)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(UserEndpointUrlsFactory.CreateUserRecentMediaByClientIdUrl(userId, clientId, count, minId, maxId, minTimestamp, maxTimestamp));
                return response;
            }
        }

        /// <summary>
        /// See the authenticated user's list of media they've liked. May return a mix of both image and video types. 
        /// Note: This list is ordered by the order in which the user liked the media. Private media is returned as long as the authenticated user has permission to view that media. 
        /// Liked media lists are only available for the currently authenticated user.
        /// </summary>
        /// <param name="accessToken">A valid access token.</param>
        /// <param name="count">Count of media to return.</param>
        /// <param name="maxLikeId">Return media liked before this id.</param>
        /// <returns>JSON result string.</returns>
        public static async Task<string> GetUserLikedMediaAsync(string accessToken, int count = 0, string maxLikeId = null)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(UserEndpointUrlsFactory.CreateUserLikedMediaUrl(accessToken, count, maxLikeId));
                return response;
            }
        }
        /// <summary>
        /// Search for a user by name.
        /// </summary>
        /// <param name="accessToken">A valid access token.</param>
        /// <param name="q">A query string.</param>
        /// <param name="count">Number of users to return.</param>
        /// <returns>JSON result string.</returns>
        public static async Task<string> SearchUsersAsync(string accessToken, string q, int count = 0)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(UserEndpointUrlsFactory.CreateSearchUsersUrl(accessToken, q, count));
                return response;
            }

        }

    }
}

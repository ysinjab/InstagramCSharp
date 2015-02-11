using InstagramCSharp.Exceptions;
using InstagramCSharp.Factories;
using System.Net.Http;
using System.Threading.Tasks;

namespace InstagramCSharp.Endpoints
{
    public class UserEndpoints
    {
        private string clientId;
        private string accessToken;
        public UserEndpoints(string clientId, string accessToken)
        {
            this.clientId = clientId;
            this.accessToken = accessToken;
        }
        /// <summary>
        /// Get basic information about a user.
        /// </summary>
        /// <returns>JSON result string.</returns>
        public async Task<string> GetUserBasicInfoAsync(long userId)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(UserEndpointUrlsFactory.CreateUserBasicInfoUrl(userId, this.accessToken));
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
        /// See the authenticated user's feed. May return a mix of both image and video types.
        /// </summary>
        /// <param name="count">Count of media to return.</param>
        /// <param name="minId">Return media later than this min_id.</param>
        /// <param name="maxId">Return media earlier than this max_id.</param>
        /// <returns>JSON result string.</returns>
        public async Task<string> GetUserFeedAsync(int count = 0, string minId = null, string maxId = null)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(UserEndpointUrlsFactory.CreateUserFeedUrl(this.accessToken, count, minId, maxId));
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
        /// Get the most recent media published by a user. May return a mix of both image and video types.
        /// </summary>
        /// <param name="count">Count of media to return.</param>
        /// <param name="minId">Return media later than this min_id.</param>
        /// <param name="maxId">Return media earlier than this max_id.</param>
        /// <param name="minTimestamp">Return media after this UNIX timestamp.</param>
        /// <param name="maxTimestamp">Return media before this UNIX timestamp.</param>
        /// <returns>JSON result string.</returns>
        public async Task<string> GetUserRecentMediaByAccessTokenAsync(long userId, int count = 0, string minId = null, string maxId = null, long minTimestamp = 0, long maxTimestamp = 0)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(UserEndpointUrlsFactory.CreateUserRecentMediaByAccessTokenUrl(userId, this.accessToken, count, minId, maxId, minTimestamp, maxTimestamp));
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
        /// Get the most recent media published by a user. May return a mix of both image and video types.
        /// </summary>
        /// <param name="count">Count of media to return.</param>
        /// <param name="minId">Return media later than this min_id.</param>
        /// <param name="maxId">Return media earlier than this max_id.</param>
        /// <param name="minTimestamp">Return media after this UNIX timestamp.</param>
        /// <param name="maxTimestamp">Return media before this UNIX timestamp.</param>
        /// <returns>JSON result string.</returns>
        public async Task<string> GetUserRecentMediaByClientIdAsync(long userId, int count = 0, string minId = null, string maxId = null, long minTimestamp = 0, long maxTimestamp = 0)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(UserEndpointUrlsFactory.CreateUserRecentMediaByClientIdUrl(userId, this.clientId, count, minId, maxId, minTimestamp, maxTimestamp));
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
        /// See the authenticated user's list of media they've liked. May return a mix of both image and video types. 
        /// Note: This list is ordered by the order in which the user liked the media. Private media is returned as long as the authenticated user has permission to view that media. 
        /// Liked media lists are only available for the currently authenticated user.
        /// </summary>
        /// <param name="count">Count of media to return.</param>
        /// <param name="maxLikeId">Return media liked before this id.</param>
        /// <returns>JSON result string.</returns>
        public async Task<string> GetUserLikedMediaAsync(int count = 0, string maxLikeId = null)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(UserEndpointUrlsFactory.CreateUserLikedMediaUrl(this.accessToken, count, maxLikeId));
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
        /// Search for a user by name.
        /// </summary>
        /// <param name="q">A query string.</param>
        /// <param name="count">Number of users to return.</param>
        /// <returns>JSON result string.</returns>
        public async Task<string> SearchUsersAsync(string q, int count = 0)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(UserEndpointUrlsFactory.CreateSearchUsersUrl(this.accessToken, q, count));
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

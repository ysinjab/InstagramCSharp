using InstagramCSharp.Exceptions;
using InstagramCSharp.Factories;
using System.Net.Http;
using System.Threading.Tasks;

namespace InstagramCSharp.Endpoints
{
    public class UserEndpoints
    {
        /// <summary>
        ///     Get information about the owner of the accessToken.
        /// </summary>
        /// <param name="accessToken" type="string">
        ///     <para>
        ///         A valid access token.
        ///     </para>
        /// </param>
        /// <returns>
        ///     JSON result string.
        /// </returns>
        public async Task<string> GetSelfInfoAsync(string accessToken)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(UserEndpointUrlsFactory.CreateSelfUserUrl(accessToken));
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
        /// Get basic information about a user.
        /// </summary>
        /// <param name="accessToken">A valid access token.</param>
        /// <returns>JSON result string.</returns>
        public async Task<string> GetUserBasicInfoAsync(long userId, string accessToken)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(UserEndpointUrlsFactory.CreateUserBasicInfoUrl(userId, accessToken));
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
        /// <param name="accessToken">A valid access token.</param>
        /// <param name="count">Count of media to return.</param>
        /// <param name="minId">Return media later than this min_id.</param>
        /// <param name="maxId">Return media earlier than this max_id.</param>
        /// <returns>JSON result string.</returns>
        public async Task<string> GetSelfRecentMediaAsync(string accessToken, int count = 0, string minId = null, string maxId = null)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(UserEndpointUrlsFactory.CreateSelfRecentMediaUrl(accessToken, count, minId, maxId));
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
        /// <param name="accessToken">A valid access token.</param>
        /// <param name="minId">Return media later than this min_id.</param>
        /// <param name="maxId">Return media earlier than this max_id.</param>
        /// <param name="minTimestamp">Return media after this UNIX timestamp.</param>
        /// <param name="maxTimestamp">Return media before this UNIX timestamp.</param>
        /// <returns>JSON result string.</returns>
        public async Task<string> GetUserRecentMediaAsync(long userId, string accessToken = null, int count = 0, string minId = null, string maxId = null, long minTimestamp = 0, long maxTimestamp = 0)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(UserEndpointUrlsFactory.CreateUserRecentMediaUrl(userId, accessToken, count, minId, maxId, minTimestamp, maxTimestamp));
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
        /// <param name="accessToken">A valid access token.</param>
        /// <param name="count">Count of media to return.</param>
        /// <param name="maxLikeId">Return media liked before this id.</param>
        /// <returns>JSON result string.</returns>
        public async Task<string> GetUserLikedMediaAsync(string accessToken, int count = 0, string maxLikeId = null)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(UserEndpointUrlsFactory.CreateUserLikedMediaUrl(accessToken, count, maxLikeId));
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
        /// <param name="accessToken">A valid access token.</param>
        /// <param name="count">Number of users to return.</param>
        /// <returns>JSON result string.</returns>
        public async Task<string> SearchUsersAsync(string q, string accessToken = null, int count = 0)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(UserEndpointUrlsFactory.CreateSearchUsersUrl(accessToken, q, count));
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

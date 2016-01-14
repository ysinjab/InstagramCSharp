using InstagramCSharp.Exceptions;
using InstagramCSharp.Factories;
using System.Net.Http;
using System.Threading.Tasks;

namespace InstagramCSharp.Endpoints
{
    public class TagEndpoints
    {

        /// <summary>
        /// Get information about a tag object.
        /// </summary>
        /// <param name="accessToken" type="string">
        ///     <para>
        ///         A valid access token.
        ///     </para>
        /// </param> 
        /// <returns>JSON result string.</returns>
        public async Task<string> GetTagInfoAsync(string tagName, string accessToken)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(TagEndpointsUrlsFactory.CreateTagInfoUrl(tagName, accessToken));
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
        /// Get a list of recently tagged media. Note that this media is ordered by when the media was tagged with this tag, rather than the order it was posted. Use the max_tag_id and min_tag_id parameters in the pagination response to paginate through these objects. 
        /// Can return a mix of image and video types.
        /// </summary>
        /// <param name="accessToken" type="string">
        ///     <para>
        ///         A valid access token.
        ///     </para>
        /// </param> 
        /// <param name="minId">Return media before this min_id.</param>
        /// <param name="maxId">Return media after this max_id.</param>
        /// <returns>JSON result string.</returns>
        public async Task<string> GetRecentTaggedMediaAsync(string tagName, string accessToken, int count = 0, string minTagId = null, string maxTagId = null)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(TagEndpointsUrlsFactory.CreateRecentTaggedMediaUrl(tagName, accessToken, count, minTagId, maxTagId));
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
        /// Search for tags by name. Results are ordered first as an exact match, then by popularity. 
        /// Short tags will be treated as exact matches.
        /// </summary>
        /// <param name="q">A valid tag name without a leading #. (eg. snowy, nofilter)</param>
        /// <param name="accessToken" type="string">
        ///     <para>
        ///         A valid access token.
        ///     </para>
        /// </param>  
        /// <returns>JSON result string.</returns>
        public async Task<string> SearchTagsAsync(string q, string accessToken)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(TagEndpointsUrlsFactory.CreateSearchTagUrl(q, accessToken));
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

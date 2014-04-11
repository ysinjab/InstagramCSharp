using InstagramCSharp.Factories;
using System.Net.Http;
using System.Threading.Tasks;

namespace InstagramCSharp.Endpoints
{
    public class TagEndpoints
    {
        private string accessToken;
        public TagEndpoints(string accessToken)
        {
            this.accessToken = accessToken;
        }
        /// <summary>
        /// Get information about a tag object.
        /// </summary>
        /// <returns>JSON result string.</returns>
        public async Task<string> GetTagInfoAsync(string tagName)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(TagEndpointsUrlsFactory.CreateTagInfoUrl(tagName, this.accessToken));
                return response;
            }
        }
        /// <summary>
        /// Get a list of recently tagged media. Note that this media is ordered by when the media was tagged with this tag, rather than the order it was posted. Use the max_tag_id and min_tag_id parameters in the pagination response to paginate through these objects. 
        /// Can return a mix of image and video types.
        /// </summary>
        /// <param name="minId">Return media before this min_id.</param>
        /// <param name="maxId">Return media after this max_id.</param>
        /// <returns>JSON result string.</returns>
        public async Task<string> GetRecentTaggedMediaAsync(string tagName, string minId = null, string maxId = null)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(TagEndpointsUrlsFactory.CreateRecentTaggedMediaUrl(tagName, this.accessToken, minId, maxId));
                return response;
            }
        }
        /// <summary>
        /// Search for tags by name. Results are ordered first as an exact match, then by popularity. 
        /// Short tags will be treated as exact matches.
        /// </summary>
        /// <param name="q">A valid tag name without a leading #. (eg. snowy, nofilter)</param>
        /// <returns>JSON result string.</returns>
        public async Task<string> SearchTagsAsync(string q)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(TagEndpointsUrlsFactory.CreateSearchTagUrl(q, this.accessToken));
                return response;
            }

        }
    }
}

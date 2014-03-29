﻿using InstgramCSharp.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InstgramCSharp.Endpoints
{
    public static class TagEndpoints
    {
        /// <summary>
        /// Get information about a tag object.
        /// </summary>
        /// <param name="accessToken">A valid access token.</param>
        /// <returns>JSON result string.</returns>
        public static async Task<string> GetTagInfoAsync(string tagName, string accessToken)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(TagEndpointsUrlsFactory.CreateTagInfoUrl(tagName, accessToken));
                return response;
            }
        }
        /// <summary>
        /// Get a list of recently tagged media. Note that this media is ordered by when the media was tagged with this tag, rather than the order it was posted. Use the max_tag_id and min_tag_id parameters in the pagination response to paginate through these objects. 
        /// Can return a mix of image and video types.
        /// </summary>
        /// <param name="accessToken">A valid access token.</param>
        /// <param name="minId">Return media before this min_id.</param>
        /// <param name="maxId">Return media after this max_id.</param>
        /// <returns>JSON result string.</returns>
        public static async Task<string> GetRecentTaggedMediaAsync(string tagName, string accessToken, string minId = null, string maxId = null)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(TagEndpointsUrlsFactory.CreateRecentTaggedMediaUrl(tagName, accessToken, minId,maxId));
                return response;
            }
        }

        /// <summary>
        /// Search for tags by name. Results are ordered first as an exact match, then by popularity. 
        /// Short tags will be treated as exact matches.
        /// </summary>
        /// <param name="q">A valid tag name without a leading #. (eg. snowy, nofilter)</param>
        /// <param name="accessToken">A valid access token.</param>
        /// <returns>JSON result string.</returns>
        public static async Task<string> SearchTagsAsync(string q, string accessToken)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(TagEndpointsUrlsFactory.CreateSearchTagUrl(q,accessToken));
                return response;
            }

        }
    }
}
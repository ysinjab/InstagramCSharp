using InstagramCSharp.Factories;
using InstagramCSharp.Enums;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace InstagramCSharp.RealTime
{
    public static class InstagramRealTime
    {
        /// <summary>
        /// Create RealTime User Subscription.
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="verifyToken"></param>
        /// <param name="callbackUrl"></param>
        /// <param name="aspect">The aspect of the object you'd like to subscribe to.</param>
        /// <returns></returns>
        public async static Task<HttpResponseMessage> CreateUserSubscriptionAsync(string clientId, string clientSecret, string verifyToken, string callbackUrl, RealTimeAspects aspect)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var postData = BuildFormUrlEncodedContentData(clientId, clientSecret, "user", verifyToken, callbackUrl, aspect);
                FormUrlEncodedContent content = new FormUrlEncodedContent(postData);
                var response = await httpClient.PostAsync(InstagramAPIUrls.RealTimeSubscriptionsUrl, content);
                return response;
            }
        }
        /// <summary>
        /// Create RealTime Tag Subscription.
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="verifyToken"></param>
        /// <param name="callbackUrl"></param>
        /// <param name="objectId"></param>
        /// <param name="aspect">The aspect of the object you'd like to subscribe to.</param>
        /// <returns></returns>
        public async static Task<HttpResponseMessage> CreateTagSubscriptionAsync(string clientId, string clientSecret, string verifyToken, string callbackUrl, string objectId, RealTimeAspects aspect)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var postData = BuildFormUrlEncodedContentData(clientId, clientSecret, "tag", verifyToken, callbackUrl, aspect);
                postData.Add(new KeyValuePair<string, string>("object_id", objectId));
                FormUrlEncodedContent content = new FormUrlEncodedContent(postData);
                var response = await httpClient.PostAsync(InstagramAPIUrls.RealTimeSubscriptionsUrl, content);
                return response;
            }
        }
        /// <summary>
        /// Create RealTime Location Subscription.
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="verifyToken"></param>
        /// <param name="callbackUrl"></param>
        /// <param name="objectId"></param>
        /// <param name="aspect">The aspect of the object you'd like to subscribe to.</param>
        /// <returns></returns>
        public async static Task<HttpResponseMessage> CreateLocationSubscriptionAsync(string clientId, string clientSecret, string verifyToken, string callbackUrl, string objectId, RealTimeAspects aspect)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var postData = BuildFormUrlEncodedContentData(clientId, clientSecret, "location", verifyToken, callbackUrl, aspect);
                postData.Add(new KeyValuePair<string, string>("object_id", objectId));
                FormUrlEncodedContent content = new FormUrlEncodedContent(postData);
                var response = await httpClient.PostAsync(InstagramAPIUrls.RealTimeSubscriptionsUrl, content);
                return response;
            }
        }
        /// <summary>
        /// Create Geography User Subscription.
        /// Note:
        /// To create a subscription to a geography, specify a center latitude and longitude and a radius of the area you'd like to capture around that point (maximum radius is 5000 meters)
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="verifyToken"></param>
        /// <param name="callbackUrl"></param>
        /// <param name="lat">Latitude.</param>
        /// <param name="lng">Longitude.</param>
        /// <param name="radius">Maximum radius is 5000 meters</param>
        /// <param name="aspect">The aspect of the object you'd like to subscribe to.</param>
        /// <returns></returns>
        public async static Task<HttpResponseMessage> CreateGeographySubscriptionAsync(string clientId, string clientSecret, string verifyToken, string callbackUrl, double lat, double lng, double radius, RealTimeAspects aspect)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var postData = BuildFormUrlEncodedContentData(clientId, clientSecret, "geography", verifyToken, callbackUrl, aspect);
                postData.Add(new KeyValuePair<string, string>("lat", lat.ToString()));
                postData.Add(new KeyValuePair<string, string>("lng", lng.ToString()));
                postData.Add(new KeyValuePair<string, string>("radius", radius.ToString()));
                FormUrlEncodedContent content = new FormUrlEncodedContent(postData);
                var response = await httpClient.PostAsync(InstagramAPIUrls.RealTimeSubscriptionsUrl, content);
                return response;
            }
        }
        /// <summary>
        /// List all subscriptions.
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <returns></returns>
        public static async Task<string> GetSubscriptionsAsync(string clientId, string clientSecret)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(RealTimeSubscriptionsUrlsFactory.CreateGETAllSubscriptionsUrl(clientId, clientSecret));
                return response;
            }
        }
        /// <summary>
        /// Delete all subscriptions.
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> DeleteAllSubscriptionsAsync(string clientId, string clientSecret)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync(RealTimeSubscriptionsUrlsFactory.CreateDELETESubscriptionsUrl(clientId, clientSecret, RealTimeObjects.All));
                return response;
            }
        }
        /// <summary>
        ///  Delete all subscriptions of a certain object type.
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> DeleteAllSubscriptionsForObjectAsync(string clientId, string clientSecret, RealTimeObjects obj)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync(RealTimeSubscriptionsUrlsFactory.CreateDELETESubscriptionsUrl(clientId, clientSecret, obj));
                return response;
            }
        }
        /// <summary>
        ///  Delete a specific subscription.
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="id">Subscription id.</param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> DeleteSubscriptionAsync(string clientId, string clientSecret, ulong id)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync(RealTimeSubscriptionsUrlsFactory.CreateDELETESubscriptionsUrl(clientId, clientSecret, id));
                return response;
            }
        }

        private static List<KeyValuePair<string, string>> BuildFormUrlEncodedContentData(string clientId, string clientSecret, string obj, string verifyToken, string callbackUrl, RealTimeAspects aspect)
        {
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("client_id", clientId));
            postData.Add(new KeyValuePair<string, string>("client_secret", clientSecret));
            postData.Add(new KeyValuePair<string, string>("verify_token", verifyToken));
            postData.Add(new KeyValuePair<string, string>("callback_url", callbackUrl));
            postData.Add(new KeyValuePair<string, string>("object", obj));
            postData.Add(new KeyValuePair<string, string>("aspect", GetAspect(aspect)));
            return postData;
        }
        private static string GetAspect(RealTimeAspects aspect)
        {
            switch (aspect)
            {
                case RealTimeAspects.Media:
                    return "media";
                default:
                    return null;

            }
        }
    }
}

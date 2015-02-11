using InstagramCSharp.Enums;
using InstagramCSharp.Exceptions;
using InstagramCSharp.Factories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace InstagramCSharp.Endpoints
{
    public class SubscriptionsEndpoints
    {
        private string clientId;
        private string clientSecret;        
        public SubscriptionsEndpoints(string clientId, string clientSecret)
        {
            this.clientId = clientId;
            this.clientSecret = clientSecret;
        }
        /// <summary>
        /// Create RealTime User Subscription.
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="verifyToken"></param>
        /// <param name="callbackUrl"></param>
        /// <param name="aspect">The aspect of the object you'd like to subscribe to.</param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> CreateUserSubscriptionAsync(string verifyToken, string callbackUrl, RealTimeAspects aspect)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var postData = BuildFormUrlEncodedContentData(this.clientId, this.clientSecret, "user", verifyToken, callbackUrl, aspect);
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
        public async Task<string> CreateTagSubscriptionAsync(string verifyToken, string callbackUrl, string objectId, RealTimeAspects aspect)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var postData = BuildFormUrlEncodedContentData(this.clientId, this.clientSecret, "tag", verifyToken, callbackUrl, aspect);
                postData.Add(new KeyValuePair<string, string>("object_id", objectId));
                FormUrlEncodedContent content = new FormUrlEncodedContent(postData);
                var response = await httpClient.PostAsync(InstagramAPIUrls.RealTimeSubscriptionsUrl, content);
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
        /// Create RealTime Location Subscription.
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="verifyToken"></param>
        /// <param name="callbackUrl"></param>
        /// <param name="objectId"></param>
        /// <param name="aspect">The aspect of the object you'd like to subscribe to.</param>
        /// <returns></returns>
        public async Task<string> CreateLocationSubscriptionAsync(string verifyToken, string callbackUrl, long objectId, RealTimeAspects aspect)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var postData = BuildFormUrlEncodedContentData(this.clientId, this.clientSecret, "location", verifyToken, callbackUrl, aspect);
                postData.Add(new KeyValuePair<string, string>("object_id", objectId.ToString()));
                FormUrlEncodedContent content = new FormUrlEncodedContent(postData);
                var response = await httpClient.PostAsync(InstagramAPIUrls.RealTimeSubscriptionsUrl, content);
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
        public async Task<string> CreateGeographySubscriptionAsync(string verifyToken, string callbackUrl, double lat, double lng, double radius, RealTimeAspects aspect)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var postData = BuildFormUrlEncodedContentData(this.clientId, this.clientSecret, "geography", verifyToken, callbackUrl, aspect);
                postData.Add(new KeyValuePair<string, string>("lat", lat.ToString()));
                postData.Add(new KeyValuePair<string, string>("lng", lng.ToString()));
                postData.Add(new KeyValuePair<string, string>("radius", radius.ToString()));
                FormUrlEncodedContent content = new FormUrlEncodedContent(postData);
                var response = await httpClient.PostAsync(InstagramAPIUrls.RealTimeSubscriptionsUrl, content);
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
        /// List all subscriptions.
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <returns></returns>
        public async Task<string> GetSubscriptionsAsync()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(RealTimeSubscriptionsUrlsFactory.CreateGETAllSubscriptionsUrl(this.clientId, this.clientSecret));
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
        /// Delete all subscriptions.
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <returns></returns>
        public async Task<string> DeleteAllSubscriptionsAsync()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync(RealTimeSubscriptionsUrlsFactory.CreateDELETESubscriptionsUrl(this.clientId, this.clientSecret, RealTimeObjects.All));
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
        ///  Delete all subscriptions of a certain object type.
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task<string> DeleteAllSubscriptionsForObjectAsync(RealTimeObjects obj)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync(RealTimeSubscriptionsUrlsFactory.CreateDELETESubscriptionsUrl(this.clientId, this.clientSecret, obj));
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
        ///  Delete a specific subscription.
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="id">Subscription id.</param>
        /// <returns></returns>
        public async Task<string> DeleteSubscriptionAsync(long id)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync(RealTimeSubscriptionsUrlsFactory.CreateDELETESubscriptionsUrl(this.clientId, this.clientSecret, id));
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
        ///     VerifyGetSubscription
        /// </summary>
        /// <param name="hubMode" type="string">
        ///     <para>
        ///         hub.mode
        ///     </para>
        /// </param>
        /// <param name="verifyToken" type="string">
        ///     <para>
        ///         hub.verify_token
        ///     </para>
        /// </param>
        /// <param name="hubChallenge" type="string">
        ///     <para>
        ///         hub.challenge
        ///     </para>
        /// </param>
        public void VerifyGetSubscription(string verifyToken,string requestHubMode, string requestVerifyToken, string requestHubChallenge)
        {
            if (verifyToken != requestVerifyToken)
            {
                throw new SubscriptionVerifyException("hub.verify_token and verifyToken did not match");
            }           
        }
        /// <summary>
        ///     VerifyPostSubscription
        /// </summary>
        /// <param name="xHubSignature" type="string">
        ///     <para>
        ///         X-HUB-Signature HTTPHeader
        ///     </para>
        /// </param>
        /// <param name="rawResponseData" type="string">
        ///     <para>
        ///         
        ///     </para>
        /// </param>
        public void VerifyPostSubscription(string xHubSignature, string rawResponseData)
        {
            var sha1 = ComputeHash(Encoding.UTF8.GetBytes(rawResponseData), Encoding.UTF8.GetBytes(this.clientSecret));
            if (sha1 != xHubSignature)
            {
                throw new SubscriptionVerifyException("X-Hub-Signature and hmac digest did not match");
            }
        }
        private string ComputeHash(byte[] data, byte[] key)
        {
            HMACSHA1 myhmacsha1 = new HMACSHA1(key);
            MemoryStream stream = new MemoryStream(data);
            return myhmacsha1.ComputeHash(stream).Aggregate("", (s, e) => s + String.Format("{0:x2}", e), s => s);
        }
        private List<KeyValuePair<string, string>> BuildFormUrlEncodedContentData(string clientId, string clientSecret, string obj, string verifyToken, string callbackUrl, RealTimeAspects aspect)
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
        private string GetAspect(RealTimeAspects aspect)
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

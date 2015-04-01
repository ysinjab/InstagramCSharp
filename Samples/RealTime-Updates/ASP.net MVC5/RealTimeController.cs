using InstagramCSharp;
using InstagramCSharp.Exceptions;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Web.Mvc;

namespace InstagramCSharp_WebSample.Controllers
{
    public class RealTimeController : Controller
    {
        [AcceptVerbs("GET", "POST")]
        public string ReceiveUpdate()
        {
            string clientId = "YOUR_CLIENT_ID";
            string clientSecret = "YOUR_CLIENT_SECRET";

            InstagramClient instagramClient = new InstagramClient(clientId, clientSecret, null);

            if (Request.HttpMethod.Equals("GET", StringComparison.OrdinalIgnoreCase))
            {
                string verifyToken = "YOUR_VERIY_TOKEN";

                var hubVeifyTokenParam = Request.Params["hub.verify_token"];
                var hubChallengeParam = Request.Params["hub.challenge"];
                var hubModeParam = Request.Params["hub.mode"];

                try
                {
                    instagramClient.SubscriptionsEndpoints.VerifyGetSubscription(verifyToken, hubModeParam, hubVeifyTokenParam, hubChallengeParam);
                    return hubChallengeParam;
                }
                catch (SubscriptionVerifyException ex)
                {
                    //Log exception
                    return null;
                }
            }
            else
            {
                var xHubSignature = Request.Headers["x-hub-signature"];
                Request.InputStream.Position = 0;
                string realTimeUpdatesJson=null;
                using (var streamReader = new StreamReader(Request.InputStream))
                {
                   realTimeUpdatesJson  = streamReader.ReadToEnd();
                }
                               
                try
                {
                    instagramClient.SubscriptionsEndpoints.VerifyPostSubscription(xHubSignature, realTimeUpdatesJson);

                    //I use Json.NET for parsing the result
                    var realTimeUpdates = JsonConvert.DeserializeObject(realTimeUpdatesJson);

                    //You can deserialize json result to one of the models in InstagramCSharp or to your custom model
                    //var realTimeUpdates = JsonConvert.DeserializeObject<List<RealTimeUpdate>>(realTimeUpdatesJson);     
                }
                catch (SubscriptionVerifyException ex)
                {
                    //Log exception                       
                }               

                return null;
            }


        }
    }
}
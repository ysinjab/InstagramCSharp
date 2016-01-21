using InstagramCSharp;
using InstagramCSharp.Enums;
using InstagramCSharp.Models;
using Newtonsoft.Json;
using System;

namespace InstagramCSharp_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
			//Create RealTime subscription sample		
		
            string clientId = "YOUR_CLIENT_ID";
            string clientSecret = "YOUR_CLIENT_SECRET";
            string callbackUrl = "YOUR_CALLBACK_URI";

            InstagramClient instagramClient = new InstagramClient(clientId, clientSecret);

            try
            {
                var responseString = instagramClient.SubscriptionsEndpoints.CreateUserSubscriptionAsync("YOUR_VERIFY_TOKEN", callbackUrl, RealTimeAspects.Media).Result;
                var newSubscription = JsonConvert.DeserializeObject<Envelope<Subscription>>(responseString);
            }
            catch (Exception ex)
            {
                //Log Exception
            }


        }
    }
}

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

            InstagramClient instagramClient = new InstagramClient(clientId, clientSecret, null);

            try
            {
                var response = instagramClient.SubscriptionsEndpoints.CreateGeographySubscriptionAsync("YOUR_VERIFY_TOKEN", callbackUrl, 52.521706, 13.365218, 5000, RealTimeAspects.Media).Result;

                var newSubscription = JsonConvert.DeserializeObject<CreatedSubscription>(response);
            }
            catch (Exception ex)
            {
                //Log Exception
            }


        }
    }
}

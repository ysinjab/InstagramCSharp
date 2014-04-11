using InstagramCSharp;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace InstagramCSharp_WebSample.Controllers
{
    public class MediaEndpointsController : Controller
    {
        public async Task<object> GetPopularMediaAsync()
        {
            string clientId = "YOUR_CLIENT_ID";
            string accessToken = "A_VALID_ACCESS_TOKEN";

            InstagramClient client = new InstagramClient(clientId, accessToken);

            var popularMedia = await client.MediaEndpoints.GetPopularMediaAsync();

            //I use Json.NET for parsing the result
            var popularMediaJson = JsonConvert.DeserializeObject(popularMedia);

            //You can deserialize json result to one of the models in InstagramCSharp or to your custom model
            //var popularMediaJson = JsonConvert.DeserializeObject<MediaFeed>(popularMedia);

            return popularMediaJson;
        }   
	}
}
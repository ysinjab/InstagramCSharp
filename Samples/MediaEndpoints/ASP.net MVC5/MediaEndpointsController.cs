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
            string ClientId = "YOUR_CLIENT_ID";
            string AccessToken = "A_VALID_ACCESS_TOKEN";

            InstagramClient client = new InstagramClient(ClientId, AccessToken);

            var popularMedia = await client.MediaEndpoints.GetPopularMediaAsync();

            //I user Json.NET for oarsing the result
            var popularMediaJson = JsonConvert.DeserializeObject(popularMedia);

            //You can deserialize json result to one of the models in InstagramCSharp or to your custom model
            //var popularMediaJson = JsonConvert.DeserializeObject<MediaFeed>(popularMedia);

            return popularMediaJson;
        }   
	}
}
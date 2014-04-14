using InstagramCSharp.Enums;
using InstagramCSharp.OAuth;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace InstagramCSharp_WebSample.Controllers
{
    public class InstagramOAuthController : Controller
    {
        public ActionResult BeginAuth()
        {
            string clientId = "YOUR_CLIENT_ID";
            string redirectUri = "YOUR_REDIRECT_URL";

            List<AccessScopes> accessScopes = new List<AccessScopes>();
            accessScopes.Add(AccessScopes.Basic);

            return Redirect(InstagramOAuth.GetAuthorizationUrl(clientId, redirectUri, "code", accessScopes));
        }

        public async Task<ActionResult> CompleteAuth(string code)
        {
            string clientId = "YOUR_CLIENT_ID";
            string clientSecret = "YOUR_CLIENT_SECRET";
            string redirectUri = "YOUR_REDIRECT_URL";

             var responseMessage = await InstagramOAuth.AuthenticateUser(InstagramConfiguration.InstagramClientId, InstagramConfiguration.InstagramClientSecret, "authorization_code", InstagramConfiguration.InstagramRedirectUri, code);
                if (responseMessage.IsSuccessStatusCode)
                {
                    
                    AuthUser result = (AuthUser)JsonConvert.DeserializeObject(responseMessage.Content.ReadAsStringAsync().Result, typeof(AuthUser));
                     //access and use access_token 
                     // result.access_token;
                }
                else
                {
                    //TODO: throw exception
                }
            //TO-DO  : If SUCCESS handle the response , else throw an exception 

            return View();
        }
    }
}

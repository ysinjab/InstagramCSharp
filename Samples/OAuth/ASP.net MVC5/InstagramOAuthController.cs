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

            var result =await InstagramOAuth.AuthenticateUser(clientId, clientSecret, "authorization_code", redirectUri, code);

            //TO-DO  : If SUCCESS handle the response , else throw an exception 

            return View();
        }
    }
}
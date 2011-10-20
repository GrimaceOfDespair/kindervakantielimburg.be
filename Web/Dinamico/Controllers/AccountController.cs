using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dinamico.Models;
using Facebook;
using System.Web.Security;
using MyFacebookSite3434.Models;

namespace Dinamico.Controllers
{
    public class AccountController : Controller
    {
        public IFormsAuthenticationService FormsService { get; set; }
        public IMembershipService MembershipService { get; set; }

        private const string logoffUrl = "http://localhost/Projects/kindervakantielimburg.be/Web/";
        private const string redirectUrl = "http://localhost/Projects/kindervakantielimburg.be/Web/Account/OAuth";

        public AccountController(IFormsAuthenticationService formsService, IMembershipService membershipService)
        {
            FormsService = formsService;
            MembershipService = membershipService;
        }

        //
        // GET: /Account/LogOn/

        public ActionResult LogOn(string returnUrl)
        {
            var oAuthClient = new FacebookOAuthClient(FacebookApplication.Current) {RedirectUri = new Uri(redirectUrl)};
            var loginUri = oAuthClient.GetLoginUrl(new Dictionary<string, object> { { "state", returnUrl } });
            return Redirect(loginUri.AbsoluteUri);
        }

        //
        // GET: /Account/OAuth/

        public ActionResult OAuth(string code, string state)
        {
            FacebookOAuthResult oauthResult;
            if (FacebookOAuthResult.TryParse(Request.Url, out oauthResult))
            {
                if (oauthResult.IsSuccess)
                {
                    var oAuthClient = new FacebookOAuthClient(FacebookApplication.Current)
                                          {RedirectUri = new Uri(redirectUrl)};
                    dynamic tokenResult = oAuthClient.ExchangeCodeForAccessToken(code);
                    string accessToken = tokenResult.access_token;

                    var expiresOn = DateTime.MaxValue;
                    if (tokenResult.ContainsKey("expires"))
                    {
                        expiresOn = DateTimeConvertor.FromUnixTime(tokenResult.expires);
                    }

                    var fbClient = new FacebookClient(accessToken);
                    dynamic me = fbClient.Get("me?fields=id,name");
                    long facebookId;
                    Int64.TryParse(me.id, out facebookId);

                    InMemoryUserStore.Add(new FacebookUser
                    {
                        AccessToken = accessToken,
                        Expires = expiresOn,
                        FacebookId = facebookId,
                        Name = (string)me.name,
                    });

                    FormsAuthentication.SetAuthCookie(facebookId.ToString(), false);

                    // prevent open redirection attack by checking if the url is local.
                    if (Url.IsLocalUrl(state))
                    {
                        return Redirect(state);
                    }
                }
            }

            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/LogOff/

        //public ActionResult LogOff()
        //{
        //    FormsAuthentication.SignOut();
        //    var oAuthClient = new FacebookOAuthClient {RedirectUri = new Uri(logoffUrl)};
        //    var logoutUrl = oAuthClient.GetLogoutUrl();
        //    return Redirect(logoutUrl.AbsoluteUri);
        //}

        //[Authorize]
        //public ActionResult ProfileInfo()
        //{
        //    var facebookId = long.Parse(User.Identity.Name);
        //    var user = InMemoryUserStore.Get(facebookId);
        //    var client = new FacebookClient(user.AccessToken);
        //    dynamic me = client.Get("me");
        //    ViewBag.Name = me.name;
        //    return View();
        //}
    }
}
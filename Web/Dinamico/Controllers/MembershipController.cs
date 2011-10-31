using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Dinamico.Models;
using Facebook;
using KVG.Core.Extensions;
using log4net;
using N2.Security;
using Web.Models;

namespace Dinamico.Controllers
{
	public class MembershipController : Controller
	{
        public ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public MembershipController(IFormsAuthenticationService formsService, IMembershipService membershipService)
		{
			FormsService = formsService;
			MembershipService = membershipService;
		}

		public IFormsAuthenticationService FormsService { get; set; }
		public IMembershipService MembershipService { get; set; }

		// **************************************
		// URL: /Account/LogOn
		// **************************************

		public ActionResult LogOn()
		{
			return View();
		}

		[HttpPost]
		public ActionResult LogOn(LogOnModel model, string returnUrl)
		{
			if (ModelState.IsValid)
			{
				if (MembershipService.ValidateUser(model.UserName, model.Password))
				{
					FormsService.SignIn(model.UserName, model.RememberMe);
					if (Url.IsLocalUrl(returnUrl))
					{
						return Redirect(returnUrl);
					}
					else
					{
						return Redirect(N2.Find.StartPage.Url);
					}
				}
				else
				{
					ModelState.AddModelError("", "The user name or password provided is incorrect.");
				}
			}

			// If we got this far, something failed, redisplay form
			return View(model);
		}

        private FacebookOAuthClient FacebookOAuthClient
        {
            get
            {
                var redirectUrl = Url.Action("FacebookOAuth", "Membership", null, (Request.Url ?? new Uri("http://foo.bar")).Scheme);
                return new FacebookOAuthClient(FacebookApplication.Current) { RedirectUri = new Uri(redirectUrl) };
            }
        }

        public ActionResult FacebookLogOn(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl))
            {
                returnUrl = Url.AbsoluteAction("Logon", "Membership");
            }

            var oauthUrl = Url.AbsoluteAction("FacebookOAuth").ToUri();

            var loginUri = FacebookOAuthClient.GetLoginUrl(FacebookApplication.Current.AppId, oauthUrl, new[] {"email"},
                                                           new Dictionary<string, object> {{"state", returnUrl}});
            return Redirect(loginUri.AbsoluteUri);
        }

	    public ActionResult FacebookOAuth(string code, string state)
        {
            FacebookOAuthResult oauthResult;
            if (FacebookOAuthResult.TryParse(Request.Url, out oauthResult) == false)
            {
                ModelState.AddModelError("Facebook", "Error while parsing Facebook response");
            }
            else if (oauthResult.IsSuccess == false)
            {
                ModelState.AddModelError("Facebook", "Facebook did not grant access");
            }
            else
            {
                try
                {
                    dynamic tokenResult = FacebookOAuthClient.ExchangeCodeForAccessToken(code);

                    var expiresOn = DateTime.MaxValue;
                    if (tokenResult.ContainsKey("expires"))
                    {
                        expiresOn = DateTimeConvertor.FromUnixTime(tokenResult.expires);
                    }

                    string accessToken = tokenResult.access_token;
                    var fbClient = new FacebookClient(accessToken);
                    dynamic me = fbClient.Get("me?fields=id,name,email");
                    long facebookId;
                    Int64.TryParse(me.id, out facebookId);

                    if (string.IsNullOrEmpty(me.email))
                    {
                        ModelState.AddModelError("Facebook", "Facebook did not return your e-mail address. Make sure your privacy settings in Facebook allow this.");
                    }
                    else
                    {
                        var userName = facebookId.ToString();
                        MembershipCreateStatus createUserStatus = MembershipService.CreateUser(userName,
                                                                                               Guid.NewGuid().ToString(),
                                                                                               me.email);

                        if (createUserStatus == MembershipCreateStatus.Success)
                        {
                            var itemBridge = N2.Context.Current.Resolve<ItemBridge>();
                            var user = itemBridge.GetUser(userName) as UserProfile;
                            if (user != null)
                            {
                                user.Title = me.name;
                                itemBridge.Save(user);
                            }
                        }

                        FormsAuthentication.SetAuthCookie(userName, false);

                        // prevent open redirection attack by checking if the url is local.
                        if (Url.IsLocalUrl(state))
                        {
                            return Redirect(state);
                        }
                    }
                }
                catch (FacebookApiException e)
                {
                    if (Log.IsErrorEnabled)
                    {
                        Log.Error("Facebook error while logging in", e);
                    }

                    ModelState.AddModelError("Facebook", "Error while logging in with Facebook: " + e.Message);
                }
            }

            return View("Logon");
        }

		// **************************************
		// URL: /Account/LogOff
		// **************************************

		public ActionResult LogOff()
		{
			FormsService.SignOut();

			return Redirect(N2.Find.StartPage.Url);
		}

		// **************************************
		// URL: /Account/Register
		// **************************************

		public ActionResult Register()
		{
			ViewBag.PasswordLength = MembershipService.MinPasswordLength;
			return View();
		}

		[HttpPost]
		public ActionResult Register(RegisterModel model)
		{
			if (ModelState.IsValid)
			{
				// Attempt to register the user
				MembershipCreateStatus createStatus = MembershipService.CreateUser(model.UserName, model.Password, model.Email);

				if (createStatus == MembershipCreateStatus.Success)
				{
					FormsService.SignIn(model.UserName, false /* createPersistentCookie */);
					return Redirect(N2.Find.StartPage.Url);
				}
				else
				{
					ModelState.AddModelError("", AccountValidation.ErrorCodeToString(createStatus));
				}
			}

			// If we got this far, something failed, redisplay form
			ViewBag.PasswordLength = MembershipService.MinPasswordLength;
			return View(model);
		}

		// **************************************
		// URL: /Account/ChangePassword
		// **************************************

		[Authorize]
		public ActionResult ChangePassword()
		{
			ViewBag.PasswordLength = MembershipService.MinPasswordLength;
			return View();
		}

		[Authorize]
		[HttpPost]
		public ActionResult ChangePassword(ChangePasswordModel model)
		{
			if (ModelState.IsValid)
			{
				if (MembershipService.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword))
				{
					return RedirectToAction("ChangePasswordSuccess");
				}
				else
				{
					ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
				}
			}

			// If we got this far, something failed, redisplay form
			ViewBag.PasswordLength = MembershipService.MinPasswordLength;
			return View(model);
		}

		// **************************************
		// URL: /Account/ChangePasswordSuccess
		// **************************************

		public ActionResult ChangePasswordSuccess()
		{
			return View();
		}

	}
}

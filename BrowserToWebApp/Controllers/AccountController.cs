using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;

namespace BrowserToWebApp.Controllers
{

    public class AccountController : Controller
    {
        // GET: Account
        public void SignIn()
        {
            if(!Request.IsAuthenticated)
            {
                HttpContext.GetOwinContext().Authentication.Challenge(
                     new AuthenticationProperties { RedirectUri = "/" }, OpenIdConnectAuthenticationDefaults.AuthenticationType
                    );
            }
        }

        public void SignOut()
        {
            if(Request.IsAuthenticated)
            {
                HttpContext.GetOwinContext().Authentication.SignOut(
                    OpenIdConnectAuthenticationDefaults.AuthenticationType, CookieAuthenticationDefaults.AuthenticationType
                    );
            }
        }

    }
}
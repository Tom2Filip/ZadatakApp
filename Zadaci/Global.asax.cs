using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Threading;

namespace Zadaci
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
        }

        void Application_BeginRequest(Object sender, EventArgs e)
        {
            // Cookie is deleted when user closes browser if cookie expiry is not set
            string lang = string.Empty; //default to the invariant culture
            HttpCookie cookie = Request.Cookies["CultureInfo"];

            if (cookie != null && cookie.Value != null)
            {
                //lang = Request.Form[cookie.Value];
                lang = cookie.Value;
                Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(lang);
                Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(lang);
            }
        }
    }
}
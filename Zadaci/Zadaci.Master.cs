using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

namespace Zadaci
{
    public partial class Zadaci : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            if (!Page.IsPostBack)
            {
                DrpLanguages.SelectedValue = Thread.CurrentThread.CurrentCulture.Name;
            }
            */
        }

        /*
        protected void DrpLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cookie is deleted when user closes browser if otherwise cookie expiry is not set
            if (DrpLanguages.SelectedValue != null && DrpLanguages.SelectedValue != "0") 
            {
                HttpCookie cookie = new HttpCookie("CultureInfo");
                cookie.Value = DrpLanguages.SelectedValue;
                Response.SetCookie(cookie);
                // Without this line Culture doesn't change (it takes two submites to make a change)
                Response.Redirect(Request.UrlReferrer.AbsoluteUri); // this is for the redirecting to the referrer page
            }            
        }
        */

        protected void flag_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("CultureInfo");
            ImageButton btn = (ImageButton)sender;

            switch (btn.ID)
            {
                case ("imagebuttonEnglish"):                   
                    cookie.Value = "en-GB";
                    Response.SetCookie(cookie);
                    // Without this line Culture doesn't change (it takes two submites to make a change)
                    Response.Redirect(Request.UrlReferrer.AbsoluteUri); // this is for the redirecting to the referrer page
                  break;

                case ("imagebuttonHrvatski"):                    
                    cookie.Value = "hr-HR";
                    Response.SetCookie(cookie);
                    // Without this line Culture doesn't change (it takes two submites to make a change)
                    Response.Redirect(Request.UrlReferrer.AbsoluteUri); // this is for the redirecting to the referrer page
                  break;
            }
        }

     }
}
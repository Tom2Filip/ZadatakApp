
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zadaci
{
    public class BaseClass : System.Web.UI.Page
    {

        protected override void InitializeCulture()
        {
            //base.InitializeCulture();
            string culture = (string)Session["culture2"];

            if (Session["culture2"] != null && (string)Session["culture2"] != "0")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(Session["culture2"].ToString());
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Session["culture2"].ToString());
            }
            base.InitializeCulture();
            
        }

    }
}
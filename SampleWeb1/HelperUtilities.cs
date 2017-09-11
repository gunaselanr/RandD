using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web;
using System.Web.UI;

namespace SampleWeb1
{
    public static class HelperUtilities
    {
        public static void ShowMessage(Page page, string strKey, string message)
        {
            ScriptManager.RegisterStartupScript(page, page.GetType(), "alertMessage",
                "alert('" + message + "');", true);
        }
    }
}
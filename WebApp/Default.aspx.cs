using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class Default : System.Web.UI.Page
    {
        public const string LANGUAGE = "zh-CN";

        protected override void InitializeCulture()
        {
            this.Culture = LANGUAGE;
            this.UICulture = LANGUAGE;
            CultureInfo ci = System.Globalization.CultureInfo.CreateSpecificCulture(LANGUAGE);
            ci.DateTimeFormat.DateSeparator = "|";
            System.Threading.Thread.CurrentThread.CurrentCulture = ci;
            System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
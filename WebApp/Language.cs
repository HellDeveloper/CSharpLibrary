using System;
using System.Globalization;
using System.Web;

namespace WebApp
{
    public class Language : IHttpModule
    {
        public const string LANGUAGE = "zh-CN";

        public void Dispose()
        {
            //此处放置清除代码。
        }

        public void Init(HttpApplication context)
        {
            context.PostAuthenticateRequest += context_PostAuthenticateRequest;
        }

        void context_PostAuthenticateRequest(object sender, EventArgs e)
        {
            var context = HttpContext.Current;
            CultureInfo ci = System.Globalization.CultureInfo.CreateSpecificCulture(LANGUAGE);
            ci.DateTimeFormat.DateSeparator = "|";
            System.Threading.Thread.CurrentThread.CurrentCulture = ci;
            System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
        }

    }
}

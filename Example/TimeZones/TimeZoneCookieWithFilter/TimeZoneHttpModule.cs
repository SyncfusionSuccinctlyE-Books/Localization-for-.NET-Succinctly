using System;
using System.Web;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using TimeZoneCookieWithFilter.Filters;

[assembly:PreApplicationStartMethod(typeof(TimeZoneCookieWithFilter.TimeZoneHttpModule), "RegisterModule")]
namespace TimeZoneCookieWithFilter
{
    public class TimeZoneHttpModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += OnRequest;
        }

        public static void RegisterModule()
        {
            DynamicModuleUtility.RegisterModule(typeof(TimeZoneHttpModule));
        }

        public static void ReadCookie(HttpCookieCollection cookies)
        {
            var timeZoneCookie = cookies["userTimeZone"];

            if (timeZoneCookie == null
                || string.IsNullOrEmpty(timeZoneCookie.Value))
                return;

            UserTimeZone.SetTimeZone(timeZoneCookie.Value);
        }

        private void OnRequest(object sender, EventArgs e)
        {
            var app = (HttpApplication) sender;
            var timeZoneCookie = app.Request.Cookies["userTimeZone"];

            if (timeZoneCookie == null
                || string.IsNullOrEmpty(timeZoneCookie.Value))
                return;

            UserTimeZone.SetTimeZone(timeZoneCookie.Value);
        }

        public void Dispose()
        {
            
        }
    }
}
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TimeZoneCookieWithFilter.Filters
{
    public class TimeZoneFilterAttribute : ActionFilterAttribute
    {
        public static void ReadCookie(HttpCookieCollection cookies)
        {
            var timeZoneCookie = cookies["userTimeZone"];

            if (timeZoneCookie == null
                || string.IsNullOrEmpty(timeZoneCookie.Value))
                return;

            UserTimeZone.SetTimeZone(timeZoneCookie.Value);
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var timeZoneCookie = filterContext.HttpContext
                                                .Request.Cookies["userTimeZone"];

            if (timeZoneCookie == null
                || string.IsNullOrEmpty(timeZoneCookie.Value))
                return;

            UserTimeZone.SetTimeZone(timeZoneCookie.Value);
        }

    }

    public static class UserTimeZone
    {
        [ThreadStatic]
        private static TimeZoneInfo _current;

        static UserTimeZone()
        {
            DefaultTimeZone = TimeZoneInfo.Utc;
        }

        public static TimeZoneInfo DefaultTimeZone { get; set; }

        public static TimeZoneInfo Instance
        {
            get { return _current ?? DefaultTimeZone; }
            private set { _current = value; }
        }

        public static void SetTimeZone(string timeZone)
        {
            // it's up to you to decide how invalid cookies should be handled.
            int hours;
            if (!int.TryParse(timeZone.Substring(4), out hours))
                return;

            var myOffset = TimeSpan.FromHours(hours);
            Instance = (from x in TimeZoneInfo.GetSystemTimeZones()
                        where x.BaseUtcOffset == myOffset
                        select x).First();

        }

        public static DateTime ToUserTime(this DateTime dateTime)
        {
            return dateTime.Add(Instance.BaseUtcOffset);
        }

        public static DateTime FromUserTime(this DateTime dateTime)
        {
            return dateTime.Subtract(Instance.BaseUtcOffset);
        }
    }
}
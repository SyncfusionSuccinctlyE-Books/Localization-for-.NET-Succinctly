using System;
using System.Web.Mvc;
using TimeZoneCookieWithFilter.Filters;
using TimeZoneCookieWithFilter.Models;

namespace TimeZoneCookieWithFilter.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string userTimeZone)
        {
            var cookieTimeZone = Request.Cookies["userTimeZone"];
            var cookieValue = cookieTimeZone == null ? null : cookieTimeZone.Value;
            if (cookieValue != userTimeZone && userTimeZone != null)
            {
                // Cookies are not supported.
            }

            if (userTimeZone == null)
            {
                // No support for scripts.
            }

            // now display the real page.
            return RedirectToAction("Front");
        }

public ActionResult Front()
{
    var christmasNoonUtc = new DateTime(2012, 12, 14, 12, 00, 00);
    var msg = "Hello. When it's christmas noon at UTC, it's {0} at your place.";
    ViewBag.Message = string.Format(msg, christmasNoonUtc.ToUserTime());

    return View();
}

        public ActionResult Post()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Post(PostViewModel model)
        {
            ViewBag.Message = "UTC version of your date: " + model.MyDate.ToString();
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}

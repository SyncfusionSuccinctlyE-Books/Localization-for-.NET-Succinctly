using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TimezoneCookie.Controllers
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
            var cookieTimeZone = Request.Cookies["userTimeZone"];

            // default time zone
            var cookieValue = cookieTimeZone == null ? "UTC" : cookieTimeZone.Value;
            ViewBag.Message = "Hello. Your time zone is: " + cookieValue;
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}

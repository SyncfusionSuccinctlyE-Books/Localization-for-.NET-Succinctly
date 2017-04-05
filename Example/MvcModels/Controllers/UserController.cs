using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcModels.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Create()
        {
            return View();
        }

    }
}

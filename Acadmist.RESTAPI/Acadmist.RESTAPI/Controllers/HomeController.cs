using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Acadmist.RESTAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            int j = 10;
            int i = 0;
            int k = j/i
            ViewBag.Title = "Home Page Name has been Changed";

            return View();
        }
    }
}

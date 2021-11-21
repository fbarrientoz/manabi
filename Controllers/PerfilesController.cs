using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace manabi.Controllers
{
    public class PerfilesController : Controller
    {
        // GET: Perfiles
        public ActionResult Padre()
        {
            return View();
        }

        public ActionResult Kid()
        {
            return View();
        }
    }

}
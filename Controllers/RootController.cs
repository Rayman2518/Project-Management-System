using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers
{
    public class RootController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}
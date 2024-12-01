using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMS.Models;

namespace PMS.Controllers
{
    public class AuthenticationController : Controller
    {
        public ActionResult Login()
        {
            return View("LoginForm");
        }
    }
}

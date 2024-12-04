using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers
{
    public class TeamMemberController : Controller
    {
        public ActionResult Projects()
        {
            return View("Projects");
        }

        public ActionResult Teams()
        {
            return View("Teams");
        }

        public ActionResult Tasks()
        {
            return View("Tasks");
        }

        public ActionResult ProfileManagement()
        {
            return View("ProfileManagement");
        }
    }
}
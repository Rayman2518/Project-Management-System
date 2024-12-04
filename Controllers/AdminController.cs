using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers
{
    public class AdminController : Controller
    {

        public ActionResult Users()
        {
            return View("Users"); 
        }

        
        public ActionResult Departments()
        {
            return View("Departments");  
        }

        public ActionResult Projects()
        {
            return View("Projects");
        }

        public ActionResult Teams()
        {
            return View("Teams");
        }

        public ActionResult Leads()
        {
            return View("Leads");
        }

        
        public ActionResult Tasks()
        {
            return View("Tasks");
        }

        public ActionResult Reports()
        {
            return View("Reports");
        }

        public ActionResult ProfileManagement()
        {
            return View("ProfileManagement");
        }

        



    }
}
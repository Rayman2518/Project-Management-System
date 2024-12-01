using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMS;

namespace PMS.Controllers
{
    public class RootController : Controller
    {
        public ActionResult Index()
        {
            // Create an instance of DatabaseConnection
            DatabaseConnection dbConnection = new DatabaseConnection();

            // Open the connection
            dbConnection.Connect();
            return View();
        }

    }
}
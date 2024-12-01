﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PMS
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Root", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Login",
                url: "{controller}/{action}",
                defaults: new { controller = "Authentication", action = "Login" }
            );

            routes.MapRoute(
                name: "Logout",
                url: "{controller}/{action}",
                defaults: new { controller = "Authentication", action = "Logout" }
            );

            routes.MapRoute(
                name: "HandleLogin",
                url: "{controller}/{action}",
                defaults: new { controller = "Authentication", action = "HandleLogin" }
            );

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace projCNPM
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
          name: "LoginPage",
          url: "login-admin",
          defaults: new { controller = "Login", action = "Index", Areas = "Admin", id = UrlParameter.Optional },
          namespaces: new[] { "DO_AN_WEBCF.Areas.Admin.Controllers" }
          );
        }
    }
}

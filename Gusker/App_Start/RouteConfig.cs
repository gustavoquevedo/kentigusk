using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DynamicRouting.Kentico.MVC;
using Kentico.Web.Mvc;

namespace Gusker
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Maps routes to Kentico HTTP handlers and features enabled in ApplicationConfig.cs
            // Always map the Kentico routes before adding other routes. Issues may occur if Kentico URLs are matched by a general route, for example images might not be displayed on pages
            routes.Kentico().MapRoutes();

            // Redirect to administration site if the path is "admin"
            // Can also replace this with the [Route("Admin")] on your AdminRedirectController's Index Method
            routes.MapRoute(
                name: "Admin",
                url: "admin",
                defaults: new { controller = "AdminRedirect", action = "Index" }
            );

            // If the Page is found, will handle the routing dynamically
            var route = routes.MapRoute(
                name: "DynamicRouting",
                url: "{*url}",
                defaults: new { defaultcontroller = "HttpErrors", defaultaction = "Index" },
                constraints: new { PageFound = new DynamicRouteConstraint() }
            );
            route.RouteHandler = new DynamicRouteHandler();

            // This will again look for matching routes or node alias paths, this time it won't care if the route is priority or not.
            routes.MapRoute(
                 name: "Default",
                 url: "{controller}/{action}/{id}",
                 defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            // Finally, 404
            routes.MapRoute(
                name: "PageNotFound",
                url: "{*url}",
                defaults: new { controller = "HttpErrors", action = "Index" }
                );
        }
    }
}

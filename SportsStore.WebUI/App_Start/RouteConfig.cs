using System.Web.Mvc;
using System.Web.Routing;

namespace SportsStore.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null,
                "",
                new
                {
                    controller = "Product",
                    action = "List",
                    category = (string)null,
                    page = 1
                });

            routes.MapRoute(null,
                "Page{page}",
                new { controller = "Product", action = "List", category = (string)null },
                new { page = @"\d+" });

            routes.MapRoute(null,
                "{category}",
                new { controller = "Product", action = "List", page = 1 });

            routes.MapRoute(null,
                "{category}/Page{page}",
                new { controller = "Product", action = "List" },
                new { page = @"\d+" });

            routes.MapRoute(null, "{controller}/{action}");

            // Add this code to handle non-existing urls
            routes.MapRoute(
                "404-PageNotFound",
                // This will handle any non-existing urls
                "{*url}",
                // "Shared" is the name of your error controller, and "Error" is the action/page
                // that handles all your custom errors
                // note: Application_Error is fired if shared/error is not exist
                new { controller = "Shared", action = "Error" }
            );

        }
    }
}

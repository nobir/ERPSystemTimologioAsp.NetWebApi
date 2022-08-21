using ERPSystem.Controllers.ActionFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ERPSystem
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.EnableCors();
            config.Filters.Add(new ValidationModelAttribute());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

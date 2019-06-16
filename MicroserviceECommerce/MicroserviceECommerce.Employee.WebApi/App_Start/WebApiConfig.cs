using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;

namespace MicroserviceECommerce.Employee.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
    name: "NewRoute",
routeTemplate: "{controller}/{action}/{id}",
defaults: new { controller = "EmployeeLogin", action = "GetEmployee", id = UrlParameter.Optional }
);
        }
    }
}

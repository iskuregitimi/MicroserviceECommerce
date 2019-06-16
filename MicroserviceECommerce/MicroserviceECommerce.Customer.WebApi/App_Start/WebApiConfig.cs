using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;

namespace MicroserviceECommerce.Customer.WebApi
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
     defaults: new { controller = "Login", action = "GetCustomer", id = UrlParameter.Optional }
 );
      

        }
    }
}

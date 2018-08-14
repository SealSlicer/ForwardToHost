using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ForwardToHost
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{*uri}",
                defaults: new
                {
                    controller = "Forwarding",
                    action = "Forward"
                }
            );

          

            //config.Routes.MapHttpRoute(
            //    name: "index",
            //    routeTemplate: "",
            //    defaults: new
            //    {
            //        controller = "Forwarding",
            //        action="Forward"
            //    }
            //);
        }
    }
}

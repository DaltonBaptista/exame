using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DkEventos
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
                name: "TipoEventoes",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "TipoEventoes", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Participantes",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Participantes", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ParticipantesPrincipais",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "ParticipantesPrincipais", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "Eventoes",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Eventoes", action = "Index", id = UrlParameter.Optional }
           );

        }
    }
}

using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace webapiproj
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API konfigurálása és szolgáltatások
            // Web API útvonalak
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
               name: "swagger",
               routeTemplate: "",
               defaults: null,
               constraints: null,
               handler: new RedirectHandler((url => url.RequestUri.ToString()), "swagger")
            );

            // CORS engedélyezése a frontend URL számára
            var cors = new EnableCorsAttribute("http://localhost:3000", "*", "*");
            config.EnableCors(cors);

            // Ha a frontend egy másik URL-ről fut, például http://localhost:3000, módosíthatod a CORS URL-t.
            // var cors = new EnableCorsAttribute("http://localhost:3000", "*", "*");
            // config.EnableCors(cors);
        }
    }
}
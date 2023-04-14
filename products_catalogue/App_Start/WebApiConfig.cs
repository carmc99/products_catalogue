using products_catalogue.Application.Middleware;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace products_catalogue
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de Web API

            // Rutas de Web API
            config.MapHttpAttributeRoutes();

            // Middleware para el manejo de excepciones no controladas
            config.Services.Replace(typeof(IExceptionHandler), new ExceptionHandlingMiddleware());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

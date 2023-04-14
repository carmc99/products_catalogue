using Serilog;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace products_catalogue
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Configura Serilog
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("C:/catalogue_logs.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            UnityConfig.RegisterComponents();
            // Config para ignorar la referencia que apunta de nuevo al objeto, cuando existen
            // relaciones entre tablas.
            HttpConfiguration config = GlobalConfiguration.Configuration;
            config.Formatters.JsonFormatter
            .SerializerSettings
            .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_End()
        {
            Log.CloseAndFlush();
        }
    }
}

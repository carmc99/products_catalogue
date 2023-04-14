using AutoMapper;
using Microsoft.EntityFrameworkCore;
using products_catalogue.App_Start;
using products_catalogue.Controllers;
using products_catalogue.Domain.Profiles;
using products_catalogue.Infrastructure.DbContexts;
using products_catalogue.Infrastructure.Repository;
using products_catalogue.Infrastructure.Repository.Interfaces;
using Serilog;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Unity;
using Unity.WebApi;

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


            var container = new UnityContainer();

            // In memory database config
            //var builder = new DbContextOptionsBuilder<InMemoryContext>();
            //builder.UseInMemoryDatabase("Catalogue");
            //var options = builder.Options;



            //container.RegisterInstance(options);
            container.RegisterSingleton<DbContext, SqlServerContext>();

            // Configurar AutoMapper
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CategoryMapperProfile>();
                cfg.AddProfile<ProductMapperProfile>();
            });
            container.RegisterInstance(mapperConfig.CreateMapper());

            // Registrar handlers y mensajes de MediatR
            // Registrara todos handlers que esten en la misma ubicacion del emsanblado
            // de ProductsController, asi que no es necesario agregar mas referencias.
            MediaTrConfig.AddMediatR(container, typeof(ProductsController).Assembly);


            // Servicios
            container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<ICategoryRepository, CategoryRepository>();


            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

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

using Microsoft.EntityFrameworkCore;
using products_catalogue.App_Start;
using products_catalogue.Controllers;
using products_catalogue.Infrastructure.Context;
using products_catalogue.Infrastructure.Repository;
using products_catalogue.Infrastructure.Repository.Interfaces;
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
            var builder = new DbContextOptionsBuilder<ProductContext>();
            builder.UseInMemoryDatabase("Catalogue");
            var options = builder.Options;

            var container = new UnityContainer();
            container.RegisterInstance(options);
            container.RegisterType<DbContext, ProductContext>();


            // Registrar handlers y mensajes de MediatR
            MediaTrConfig.AddMediatR(container, typeof(ProductsController).Assembly);

            // Registrar instancia de Mediator en el contenedor

            container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<ICategoryRepository, CategoryRepository>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }



    }
}

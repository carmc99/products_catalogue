using AutoMapper;
using Microsoft.EntityFrameworkCore;
using products_catalogue.App_Start;
using products_catalogue.Controllers;
using products_catalogue.Domain.Profiles;
using products_catalogue.Infrastructure.DbContexts;
using products_catalogue.Infrastructure.Repository;
using products_catalogue.Infrastructure.Repository.Interfaces;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace products_catalogue
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // In memory database config
            //var builder = new DbContextOptionsBuilder<InMemoryContext>();
            //builder.UseInMemoryDatabase("Catalogue");
            //var options = builder.Options;

            //container.RegisterInstance(options);


            // register all your components with the container here
            // it is NOT necessary to register your controllers

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
        }
    }
}
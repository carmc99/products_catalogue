using MediatR;
using System.Linq;
using System.Reflection;
using Unity;

namespace products_catalogue.App_Start
{
    public static class MediaTrConfig
    {
        public static void AddMediatR(this IUnityContainer container, params Assembly[] assemblies)
        {
            // Registrar instancia de Mediator en el contenedor
            container.RegisterType<IMediator, Mediator>();
            container.RegisterInstance<ServiceFactory>(t => container.Resolve(t));

            foreach (var assembly in assemblies)
            {
                var requestHandlers = assembly.GetTypes().Where(t => t.GetInterfaces().Any(i => i.IsGenericType && (i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>) || i.GetGenericTypeDefinition() == typeof(IRequestHandler<>))));
                foreach (var handler in requestHandlers)
                {
                    foreach (var @interface in handler.GetInterfaces())
                    {
                        container.RegisterType(@interface, handler);
                    }
                }
            }
        }
    }
}
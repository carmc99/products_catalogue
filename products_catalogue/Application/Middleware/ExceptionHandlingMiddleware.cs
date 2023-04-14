using System.Web.Http.ExceptionHandling;

namespace products_catalogue.Application.Middleware
{
    public class ExceptionHandlingMiddleware : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            context.Result = new InternalServerErrorTextPlainResult(context.Request)
            {
                Content = "Se produjo un error interno del servidor. Por favor, inténtalo de nuevo más tarde."
            };
        }
    }
}
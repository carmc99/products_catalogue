using Newtonsoft.Json;
using products_catalogue.App_Start;
using Serilog;
using System.Web.Http.ExceptionHandling;

namespace products_catalogue.Application.Middleware
{
    public class ExceptionHandlingMiddleware : ExceptionHandler
    {
        private readonly ILogger logger;

        public ExceptionHandlingMiddleware()
        {
            this.logger = ApplicationLogging.Logger;
        }

        public override void Handle(ExceptionHandlerContext context)
        {
            logger.Error(JsonConvert.SerializeObject(context.Exception));
            context.Result = new InternalServerErrorTextPlainResult(context.Request)
            {
                Content = "Se produjo un error interno del servidor. Por favor, inténtalo de nuevo más tarde."
            };
        }
    }
}
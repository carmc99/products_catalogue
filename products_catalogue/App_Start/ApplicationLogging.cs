using Serilog;

namespace products_catalogue.App_Start
{
    public class ApplicationLogging
    {
        public static ILogger Logger { get; } = Log.Logger;
    }
}
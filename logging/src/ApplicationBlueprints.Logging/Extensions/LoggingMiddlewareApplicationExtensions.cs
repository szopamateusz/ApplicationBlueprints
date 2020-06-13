using ApplicationBlueprints.Logging.CorrelatedLogs;
using Microsoft.AspNetCore.Builder;

namespace ApplicationBlueprints.Logging.Extensions
{
    public static class LoggingMiddlewareApplicationExtensions
    {
        public static IApplicationBuilder UseScopedLoggingMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ScopedLoggingMiddleware>();
        }
    }
}

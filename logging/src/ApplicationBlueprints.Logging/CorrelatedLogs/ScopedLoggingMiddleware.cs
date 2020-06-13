using System;
using System.Threading.Tasks;
using ApplicationBlueprints.Correlation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ApplicationBlueprints.Logging.CorrelatedLogs
{
    public class ScopedLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ScopedLoggingMiddleware> _logger;

        public ScopedLoggingMiddleware(RequestDelegate next, ILogger<ScopedLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context, ICorrelationIdStore correlationIdStore)
        {
            if(context == null)
                throw new ArgumentNullException(nameof(context));

            var correlationId = GetOrAddCorrelationHeader(context);
            correlationIdStore.SetCorrelationId(Guid.Parse(correlationId));

            var traceIdentifier = GetOrAddTraceIdentifierHeader(context);

            try
            {
                var loggerAdditionalProperties = new LoggerState
                {
                    [LoggerHeaderKeyNames.CorrelationId] = correlationId,
                    [LoggerHeaderKeyNames.TraceIdentifier] = traceIdentifier
                };

                using (_logger.BeginScope(loggerAdditionalProperties))
                {
                    await _next(context);
                }
            }
            catch (Exception ex) when (LogOnUnexpectedError(ex))
            {
            }
        }

        private string GetOrAddCorrelationHeader(HttpContext context)
        {
            if (string.IsNullOrWhiteSpace(context.Request.Headers[LoggerHeaderKeyNames.CorrelationId]))
                context.Request.Headers[LoggerHeaderKeyNames.CorrelationId] = Guid.NewGuid().ToString();

            return context.Request.Headers[LoggerHeaderKeyNames.CorrelationId];
        }

        private string GetOrAddTraceIdentifierHeader(HttpContext context)
        {
            if (string.IsNullOrWhiteSpace(context.Request.Headers[LoggerHeaderKeyNames.TraceIdentifier]))
                context.Request.Headers[LoggerHeaderKeyNames.TraceIdentifier] = context.Request.HttpContext.TraceIdentifier;

            return context.Request.Headers[LoggerHeaderKeyNames.TraceIdentifier];
        }

        private bool LogOnUnexpectedError(Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occured!");

            return true;
        }
    }
}

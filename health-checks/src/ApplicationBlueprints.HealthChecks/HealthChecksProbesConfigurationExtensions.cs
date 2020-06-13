using System;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace ApplicationBlueprints.HealthChecks
{
    public static class HealthChecksProbesConfigurationExtensions
    {
        public static IApplicationBuilder UseHealthChecksProbes(this IApplicationBuilder app)
        {
            UseLivenessProbe(app);
            UseReadinessProbe(app);

            return app;
        }

        private static void UseLivenessProbe(IApplicationBuilder appBuilder)
        {
            appBuilder.UseHealthChecks("/liveness", new HealthCheckOptions
            {
                Predicate = r => r.Name.Contains("self", StringComparison.CurrentCultureIgnoreCase),
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
        }

        private static void UseReadinessProbe(IApplicationBuilder appBuilder)
        {
            appBuilder.UseHealthChecks("/healthz", new HealthCheckOptions
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
        }
    }
}

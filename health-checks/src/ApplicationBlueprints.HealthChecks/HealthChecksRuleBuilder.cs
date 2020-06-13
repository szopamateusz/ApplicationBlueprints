using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ApplicationBlueprints.HealthChecks
{
    public static class HealthChecksRuleBuilder
    {
        public static IServiceCollection AddInternalServiceHealthCheck(this IServiceCollection services, Uri url, string name)
        {
            var serviceDomain = url.Host;
            var healthCheckUrl = $"{serviceDomain}/healthz";

            services.AddHealthChecks().AddUrlGroup(new Uri(healthCheckUrl), name);

            return services;
        }

        public static IServiceCollection AddExternalServiceHealthChecks(this IServiceCollection services, Uri url, string name)
        {
            services.AddHealthChecks().AddUrlGroup(url, name);

            return services;
        }

        public static IServiceCollection AddSelfServiceHealthCheck(this IServiceCollection services)
        {
            services.AddHealthChecks()
                .AddCheck("self", () => HealthCheckResult.Healthy());

            return services;
        }
    }
}

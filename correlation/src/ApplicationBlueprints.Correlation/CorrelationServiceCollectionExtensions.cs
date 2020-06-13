using Microsoft.Extensions.DependencyInjection;

namespace ApplicationBlueprints.Correlation
{
    public static class CorrelationServiceCollectionExtensions
    {
        public static IServiceCollection AddCorrelationIdStore(this IServiceCollection services)
        {
            services.AddScoped<ICorrelationIdStore, CorrelationIdStore>();

            return services;
        }
    }
}

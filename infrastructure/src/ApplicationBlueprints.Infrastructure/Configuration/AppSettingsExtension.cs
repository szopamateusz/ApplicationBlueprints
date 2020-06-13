using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationBlueprints.Infrastructure.Configuration
{
    public static class AppSettingsExtension
    {
        public static IServiceCollection ConfigureSettings<T>(this IServiceCollection services,
            IConfiguration configuration, string section) where T : class, new()
        {
            services.Configure<T>(configuration.GetSection(section));
            services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<T>>().Value);

            return services;
        }

        public static IServiceCollection ConfigureArraySettings<T>(this IServiceCollection services,
            IConfiguration configuration, string section) where T : class, new()
        {
            services.Configure<T>(options => configuration.GetSection(section).Bind(options));
            services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<T>>().Value);

            return services;
        }
    }
}

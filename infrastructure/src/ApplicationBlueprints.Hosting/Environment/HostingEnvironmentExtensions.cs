using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ApplicationBlueprints.Hosting.Environment
{
    public static class HostingEnvironmentExtensions
    {
        public static bool IsLocal(this IHostEnvironment env)
        {
            return env.IsEnvironment(EnvironmentNameConstants.Local);
        }

        public static bool IsDevelopment(this IHostEnvironment env)
        {
            return env.IsEnvironment(EnvironmentNameConstants.Development);
        }

        public static bool IsTest(this IHostEnvironment env)
        {
            return env.IsEnvironment(EnvironmentNameConstants.Test);
        }

        public static bool IsUAT(this IHostEnvironment env)
        {
            return env.IsEnvironment(EnvironmentNameConstants.UAT);
        }

        public static bool IsProduction(this IHostEnvironment env)
        {
            return env.IsEnvironment(EnvironmentNameConstants.Production);
        }

        public static IWebHostBuilder SetScopeValidation(this IWebHostBuilder webHostBuilder, string environmentName)
        {
            return environmentName.IsLocal()
                ? webHostBuilder.UseDefaultServiceProvider(options => options.ValidateScopes = true)
                : webHostBuilder;
        }
    }
}

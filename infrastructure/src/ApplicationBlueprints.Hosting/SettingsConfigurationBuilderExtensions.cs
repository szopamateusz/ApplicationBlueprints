using Microsoft.Extensions.Configuration;

namespace ApplicationBlueprints.Hosting
{
    public static class SettingsConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder AddBasicSettings(
            this IConfigurationBuilder builder,
            string environmentName,
            string currentDirectory)
        {
            return builder
                .SetBasePath(currentDirectory)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{environmentName}.json", true, true)
                .AddEnvironmentVariables();
        }
    }
}

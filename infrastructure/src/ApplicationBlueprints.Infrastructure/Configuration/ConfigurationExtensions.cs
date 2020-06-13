using Microsoft.Extensions.Configuration;

namespace ApplicationBlueprints.Infrastructure.Configuration
{
    public static class ConfigurationExtensions
    {
        public static TConfigurationDto GetSection<TConfigurationDto>(this IConfiguration configuration,
            string sectionPath) where TConfigurationDto : new()
        {
            var section = new TConfigurationDto();
            configuration.GetSection(sectionPath).Bind(section);

            return section;
        }
    }
}

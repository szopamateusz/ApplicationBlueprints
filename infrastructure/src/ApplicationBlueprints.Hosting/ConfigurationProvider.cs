using Microsoft.Extensions.Configuration;

namespace ApplicationBlueprints.Hosting
{
    public class ConfigurationProvider
    {
        public IConfigurationRoot CreateBasicConfiguration(string environmentName, string currentDirectory)
        {
            return new ConfigurationBuilder().AddBasicSettings(environmentName, currentDirectory).Build();
        }
    }
}

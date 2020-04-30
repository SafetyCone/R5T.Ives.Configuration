using System;

using Microsoft.Extensions.Configuration;


namespace R5T.Ives.Configuration
{
    /// <summary>
    /// Provides the configuration name value drawn directly from the <see cref="IConfiguration"/> instance.
    /// This is useful during two-stage application startup DI-container configuration. The initial stage can add the default appsettings.json file, in which is contained the name of the configuration that should be run.
    /// The configuration name specified in the default appsettings.json file can be used to add the appsettings.{configuration name}.json file to the configuration for the second-stage.
    /// </summary>
    public class DirectConfigurationBasedConfigurationNameProvider : IConfigurationNameProvider
    {
        public const string ConfigurationNameConfigurationKey = "ConfigurationName";


        private IConfiguration Configuration { get; }


        public DirectConfigurationBasedConfigurationNameProvider(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public string GetConfigurationName()
        {
            string configurationName = this.Configuration[DirectConfigurationBasedConfigurationNameProvider.ConfigurationNameConfigurationKey];
            return configurationName;
        }
    }
}

using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;


namespace R5T.Ives.Configuration
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="DirectConfigurationBasedConfigurationNameProvider"/> implementation of <see cref="IConfigurationNameProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddDirectConfigurationBasedConfigurationNameProvider(this IServiceCollection services,
            IServiceAction<IConfiguration> configurationAction)
        {
            services
                .AddSingleton<IConfigurationNameProvider, DirectConfigurationBasedConfigurationNameProvider>()
                .Run(configurationAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="DirectConfigurationBasedConfigurationNameProvider"/> implementation of <see cref="IConfigurationNameProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IConfigurationNameProvider> AddDirectConfigurationBasedConfigurationNameProviderAction(this IServiceCollection services,
            IServiceAction<IConfiguration> configurationAction)
        {
            var serviceAction = ServiceAction<IConfigurationNameProvider>.New(() => services.AddDirectConfigurationBasedConfigurationNameProvider(
                configurationAction));

            return serviceAction;
        }
    }
}

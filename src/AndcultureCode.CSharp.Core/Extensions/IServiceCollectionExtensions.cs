using AndcultureCode.CSharp.Business.Core.Models.Configuration;
using AndcultureCode.CSharp.Core.Constants;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AndcultureCode.CSharp.Core.Extensions
{
    /// <summary>
    /// Convenience extensions for registering/configuring core actors
    /// /// </summary>
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Configure application to support data seeding
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddSeeding(this IServiceCollection services, IConfigurationRoot configuration)
        {
            var seedsConfig = configuration.GetSection(CoreConfiguration.SEEDS).Get<SeedsConfiguration>();

            services.AddSingleton((sp) => seedsConfig);

            return services;
        }
    }
}

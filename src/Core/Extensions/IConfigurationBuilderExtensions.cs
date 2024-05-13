using Microsoft.Extensions.Configuration;
using RSM.HCD.CSharp.Core.Utilities.Configuration;

namespace RSM.HCD.CSharp.Core.Extensions
{
    /// <summary>
    /// TODO https://github.com/rsm-hcd/RSM.HCD.CSharp.Core/issues/37
    /// </summary>
    public static class IConfigurationBuilderExtensions
    {
        /// <summary>
        /// Configures dotnet IConfigurationBuilder to read Amazon Elastic Beanstalk instance environment variables
        /// </summary>
        /// <param name="configurationBuilder"></param>
        /// <returns></returns>
        /// <example>
        /// <code>
        /// new ConfigurationBuilder()
        ///     .AddJsonFile("appsettings.json")
        ///     .AddAmazonElasticBeanstalk()
        ///     .AddEnvironmentVariables();
        /// </code>
        /// </example>
        public static IConfigurationBuilder AddAmazonElasticBeanstalk(this IConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Add(new AmazonEBConfigurationSource());
            return configurationBuilder;
        }
    }
}

using AndcultureCode.CSharp.Core.Constants;
using AndcultureCode.CSharp.Core.Extensions;
using Microsoft.Extensions.Configuration;

namespace AndcultureCode.CSharp.Core.Utilities.Configuration
{
    /// <summary>
    /// Static utility class to aid in configuration
    /// </summary>
    public static class ConfigurationUtils
    {
        #region Properties

        private static IConfigurationBuilder _builder;
        private static IConfigurationRoot _configurationRoot;
        private static string _connectionString;

        /// <summary>
        /// Returns current instance of configuration builder
        /// </summary>
        public static IConfigurationBuilder Builder
        {
            get
            {
                if (_builder == null)
                {
                    _builder = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json")
                        .AddAmazonElasticBeanstalk()
                        .AddEnvironmentVariables();
                }

                return _builder;
            }
        }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Retrieve current instance of IConfigurationRoot
        /// </summary>
        /// <returns></returns>
        public static IConfigurationRoot GetConfiguration() => _configurationRoot ?? (_configurationRoot = Builder.Build());

        /// <summary>
        /// Retrieve currently configured connection string
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetConnectionString(string name = ApplicationConstants.API_DATABASE_CONFIGURATION_KEY)
        {
            if (!string.IsNullOrWhiteSpace(_connectionString))
            {
                return _connectionString;
            }

            // Note: Using colon vs underscore results in only the appsettings file being read and not the environment variable
            return GetConfiguration().GetSection("ConnectionStrings").GetValue<string>(name);
        }

        /// <summary>
        /// Assign new instance of IConfigurationRoot
        /// </summary>
        /// <param name="configuration"></param>
        public static void SetConfiguration(IConfigurationRoot configuration) => _configurationRoot = configuration;

        /// <summary>
        /// Explicitly set connection string at runtime. When set at runtime, this superceeds
        /// values from the loaded configurationRoot object.
        /// </summary>
        /// <param name="connectionString"></param>
        public static void SetConnectionString(string connectionString) => _connectionString = connectionString;

        #endregion Public Methods
    }
}

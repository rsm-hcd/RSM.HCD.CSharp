using Microsoft.Extensions.Configuration;

namespace AndcultureCode.CSharp.Extensions
{
    /// <summary>
    /// Extension methods for IConfigurationRoot
    /// </summary>
    public static class IConfigurationRootExtensions
    {
        #region Constants

        /// <summary>
        /// Version value when application is run in development environment
        /// </summary>
        public const string CONFIGURATION_VERSION_DEVELOPMENT_VALUE = "dev";

        /// <summary>
        /// Template string replaced with current version number
        /// </summary>
        /// <value></value>
        public const string CONFIGURATION_VERSION_TEMPLATE = "{BUILD_NUMBER}";

        /// <summary>
        /// Key value for build version number
        /// </summary>
        public const string CONFIGURATION_VERSION_KEY = "Version";

        /// <summary>
        /// Default connection string database key
        /// </summary>
        public const string DEFAULT_DATABASE_KEY = "Api";

        #endregion Constants

        #region Public Methods

        /// <summary>
        /// Retrieves web application's primary database connection string
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="databaseKey"></param>
        public static string GetDatabaseConnectionString(this IConfigurationRoot configuration, string databaseKey = DEFAULT_DATABASE_KEY)
            // Note: Using colon vs underscore results in only the appsettings file being read and not the environment variable
            => configuration?.GetSection("ConnectionStrings")?.GetValue<string>(databaseKey);

        /// <summary>
        /// Retrieves the database name of the primary database connection string
        /// </summary>
        /// <param name="configuration"></param>
        public static string GetDatabaseName(this IConfigurationRoot configuration)
        {
            var connectionString = configuration.GetDatabaseConnectionString();
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                return null;
            }

            var settings = connectionString.Split(';');

            foreach (var setting in settings)
            {
                if (!setting.ToLower().TrimStart().StartsWith("database")
                    && !setting.ToLower().TrimStart().StartsWith("initial catalog"))
                {
                    continue;
                }

                return setting.Split('=')[1];
            }

            return null;
        }

        /// <summary>
        /// Loads and conditionally updates the Version number based upon environment
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="isDevelopment"></param>
        /// <returns></returns>
        public static string GetVersion(this IConfigurationRoot configuration, bool isDevelopment = false)
        {
            if (configuration == null)
            {
                return null;
            }

            var version = configuration.GetValue<string>(CONFIGURATION_VERSION_KEY);

            if (isDevelopment)
            {
                return version.Replace(CONFIGURATION_VERSION_TEMPLATE, CONFIGURATION_VERSION_DEVELOPMENT_VALUE);
            }

            return version;
        }

        #endregion Public Methods
    }
}

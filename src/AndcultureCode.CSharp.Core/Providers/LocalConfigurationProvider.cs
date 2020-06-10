using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace AndcultureCode.CSharp.Core.Providers.Configuration
{
    /// <summary>
    /// Centralized location for loading configuration settings
    /// </summary>
    public class LocalConfigurationProvider
    {
        #region Private Properties

        private readonly string _basePath = Directory.GetCurrentDirectory();

        #endregion Private Properties

        #region Public Methods

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="basePath"></param>
        public LocalConfigurationProvider(string basePath = null)
        {
            if (!string.IsNullOrWhiteSpace(basePath))
            {
                _basePath = basePath;
            }
        }

        /// <summary>
        /// Constructs configuration object
        /// </summary>
        public IConfiguration GetConfiguration()
            => new ConfigurationBuilder()
                    .SetBasePath(this._basePath)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                    .AddEnvironmentVariables()
                    .Build();

        #endregion Public Methods
    }
}
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AndcultureCode.CSharp.Core.Utilities.Configuration
{
    /// <summary>
    /// Adds support to read environment variables from an Amazon Elastic Beanstalk EC2 instance
    ///
    /// At this time AWS stores these environment variables in its own proprietary configuration
    /// that we are forced to read and pipe to the application.
    /// </summary>
    public class AmazonEBConfigurationProvider : ConfigurationProvider
    {
        #region Constants

        /// <summary>
        /// Absolute path to the AWS Elastic Beanstalk windows instance configuration file
        /// </summary>
        private const string CONFIGURATION_FILE_PATH = @"C:\Program Files\Amazon\ElasticBeanstalk\config\containerconfiguration";

        #endregion Constants


        #region Properties

        private bool StdoutEnabled { get; set; }

        #endregion Properties


        #region Constructors

        public AmazonEBConfigurationProvider() {}
        public AmazonEBConfigurationProvider(bool stdoutEnabled = false)
        {
            StdoutEnabled = stdoutEnabled;
        }

        #endregion Constructors


        #region Properties

        public static IDictionary<string, string> CachedConfiguration { get; set; }

        #endregion Properties


        #region Public Methods

        public virtual string Get(string key) => Has(key) ? ReadConfiguration()[key] : null;

        public virtual bool Has(string key) => ReadConfiguration().ContainsKey(key);

        public virtual IDictionary<string, string> ReadConfiguration()
        {
            if (CachedConfiguration != null)
            {
                return CachedConfiguration;
            }

            var result = new Dictionary<string, string>();

            if (!File.Exists(CONFIGURATION_FILE_PATH))
            {
                LogIfEnabled($"File '{CONFIGURATION_FILE_PATH}' does not exist");
                return result;
            }

            string configJson;
            try
            {
                configJson = File.ReadAllText(CONFIGURATION_FILE_PATH);
            }
            catch(Exception ex)
            {
                LogIfEnabled($"Failed to read file contents '{CONFIGURATION_FILE_PATH}' - {ex.Message}");
                return result;
            }

            var config = JObject.Parse(configJson);
            var env    = (JArray)config["iis"]["env"];

            if (env.Count == 0)
            {
                LogIfEnabled("No environment variables found");
                return result;
            }

            foreach (var item in env.Select(i => (string)i))
            {
                int eqIndex = item.IndexOf('=');
                var key     = item.Substring(0, eqIndex);
                var value   = item.Substring(eqIndex + 1);
                key         = key.Replace("__", ":"); // Need to translate so inheritance is respected (addition to fix the gist in github)
                result[key] = value;
            }

            CachedConfiguration = result;

            return result;
        }

        /// <summary>
        /// Load the configuration into the inherited 'Data' dictionary for use by ConfigurationRoot/Builder
        /// </summary>
        public override void Load()
        {
            foreach (var entry in ReadConfiguration())
            {
                Data[entry.Key] = entry.Value;
            }
        }

        #endregion Public Methods


        #region Private Methods

        private void LogIfEnabled(string message)
        {
            if (!StdoutEnabled)
            {
                return;
            }

            Console.WriteLine($"[AmazonEBConfigurationProvider] {message}");
        }

        #endregion Private Methods
    }
}
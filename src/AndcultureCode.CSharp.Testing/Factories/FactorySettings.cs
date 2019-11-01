using System;

namespace AndcultureCode.CSharp.Testing.Factories
{
    /// <summary>
    /// Singleton test-suite wide for configuring test factory related settings
    /// </summary>
    public class FactorySettings
    {
        #region Private Properties

        private static readonly Lazy<FactorySettings> _lazyInstance = new Lazy<FactorySettings>(() => new FactorySettings());

        #endregion Private Properties


        #region Public Properties

        /// <summary>
        /// When enabled, factory related debug output will be written to standard out
        /// for troubleshooting purposes. Otherwise, by default it will only output
        /// for actual exceptional cases.
        /// </summary>
        public bool Debug { get; }

        /// <summary>
        /// Lazy-loaded singleton instance used to alter factory settings
        /// Ie. FactorySettings.Instance.Debug = true;
        /// </summary>
        /// <value></value>
        public static FactorySettings Instance { get => _lazyInstance.Value; }

        #endregion Public Properties


        #region Constructors

        private FactorySettings() {}

        #endregion Constructors
    }
}
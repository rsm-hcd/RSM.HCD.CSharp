namespace AndcultureCode.CSharp.Business.Core.Models.Configuration
{
    /// <summary>
    /// Describes common configuration for OAuth providers
    /// </summary>
    public class OAuthAccountConfiguration
    {
        /// <summary>
        /// Application's uniquely assigned Id
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Application's uniquely assigned Secret
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Is this integration disabled?
        /// </summary>
        public bool IsDisabled { get => !IsEnabled; }

        /// <summary>
        /// Is this integration enabled?
        /// </summary>
        public bool IsEnabled { get; set; }
    }
}

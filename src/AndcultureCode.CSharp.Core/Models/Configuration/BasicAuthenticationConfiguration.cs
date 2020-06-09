namespace AndcultureCode.CSharp.Core.Models.Configuration
{
    /// <summary>
    /// Configuration properties available when setting up Basic HTTP authentication
    /// </summary>
    public class BasicAuthenticationConfiguration
    {
        /// <summary>
        /// Is basic auth enabled for this environment?
        /// </summary>
        /// <value></value>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// Password for users to use when authenticating
        /// </summary>
        /// <value></value>
        public string Password { get; set; }

        /// <summary>
        /// Username for users to use when authenticating
        /// </summary>
        /// <value></value>
        public string UserName { get; set; }
    }
}
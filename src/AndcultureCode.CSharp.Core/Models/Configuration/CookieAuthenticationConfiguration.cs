namespace AndcultureCode.CSharp.Business.Core.Models.Configuration
{
    /// <summary>
    /// Cookie authentication settings
    /// </summary>
    public class CookieAuthenticationConfiguration
    {
        /// <summary>
        /// Where to redirect user when access is denied.
        /// Only applies to traditional web view auth flows.
        /// </summary>
        public string AccessDeniedPath { get; set; }

        /// <summary>
        /// Authentication scheme identifier
        /// </summary>
        public string AuthenticationScheme { get; set; }

        /// <summary>
        /// Cookie identifier
        /// </summary>
        public string CookieName { get; set; }

        /// <summary>
        /// Is cookie authentication currently enabled?
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// Where to redirect the user when they are required to login.
        /// Only applies to traditional web view auth flows.
        /// </summary>
        public string LoginPath { get; set; }
    }
}

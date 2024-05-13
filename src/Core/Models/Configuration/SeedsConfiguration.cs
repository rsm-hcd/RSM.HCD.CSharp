namespace RSM.HCD.CSharp.Business.Core.Models.Configuration
{
    /// <summary>
    /// Configuration values around data seeding
    /// </summary>
    public class SeedsConfiguration
    {
        /// <summary>
        /// Password to use when new development/test users are seeded
        /// </summary>
        /// <value></value>
        public string DefaultUserPassword { get; set; }
    }
}

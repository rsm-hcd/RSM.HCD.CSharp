namespace AndcultureCode.CSharp.Core.Interfaces.Entity
{
    /// <summary>
    /// Descriptor of individual person's in the system
    /// </summary>
    public interface IUser : IEntity
    {
        /// <summary>
        /// Email address
        /// </summary>
        string Email { get; set; }

        /// <summary>
        /// First name
        /// </summary>
        string FirstName { get; set; }

        /// <summary>
        /// Highest level user permission.
        /// Has access to all capabilities in the system.
        /// </summary>
        bool IsSuperAdmin { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        string LastName { get; set; }

        /// <summary>
        /// Encrypted base64 password
        /// </summary>
        string PasswordHash { get; set; }

        /// <summary>
        /// Base64 salt
        /// </summary>
        string Salt { get; set; }

        /// <summary>
        /// Idenitifer used to compare changes to this "identity".
        /// Can take on many forms depending upon the application (ie. datetime, guid)
        /// </summary>
        string SecurityStamp { get; set; }

        /// <summary>
        /// Alias/handle in the system
        /// </summary>
        string UserName { get; set; }
    }
}

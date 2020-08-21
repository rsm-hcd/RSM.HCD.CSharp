namespace AndcultureCode.CSharp.Core.Interfaces.Authentication
{
    /// <summary>
    /// Base information used to integration OAuth provider users
    /// </summary>
    public interface IOAuthUser
    {
        /// <summary>
        /// Email address
        /// </summary>
        string Email { get; }

        /// <summary>
        /// Given name / First name
        /// </summary>
        string FirstName { get; }

        /// <summary>
        /// Uniquely assigned identifier from external oauth provider
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Surname / Lastname
        /// </summary>
        string LastName { get; }

        /// <summary>
        /// Which UserMetadata.Name is associated for this OAuth User type
        /// </summary>
        string UserMetadataName { get; }

        /// <summary>
        /// Handle/Alias unique to this user in our system
        /// </summary>
        /// <value></value>
        string UserName { get; }
    }
}

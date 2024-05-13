namespace RSM.HCD.CSharp.Core.Interfaces.Entity
{
    /// <summary>
    /// Captures a given user's attempts at both
    /// successfully and unsuccessfully log into the system.
    /// </summary>
    public interface IUserLogin : IEntity
    {
        #region Properties

        /// <summary>
        /// Number of consecutive failed attempts at logging in
        /// </summary>
        int FailedAttemptCount { get; set; }

        /// <summary>
        /// IP address of requests to authenticate this user
        /// </summary>
        string Ip { get; set; }

        /// <summary>
        /// Is this a successful login request?
        /// </summary>
        bool IsSuccessful { get; set; }

        /// <summary>
        /// Unique identifier of associated IRole
        /// </summary>
        long? RoleId { get; set; }

        /// <summary>
        /// Identifier (hopefully unique) of server handling the request
        /// </summary>
        string ServerName { get; set; }

        /// <summary>
        /// Requesting party's user-agent
        /// </summary>
        string UserAgent { get; set; }

        /// <summary>
        /// Unique identifier of associated IUser
        /// </summary>
        /// <value></value>
        long? UserId { get; set; }

        /// <summary>
        /// Handle/Alias used to login (or attempt to login) this user
        /// </summary>
        /// <value></value>
        string UserName { get; set; }

        #endregion Properties

        #region Navigation Properties

        /// <summary>
        /// Reference to IRole that has Id equal to RoleId
        /// </summary>
        IRole Role { get; }

        /// <summary>
        /// Reference to IUser that has an Id equal to UserId
        /// </summary>
        IUser User { get; }

        #endregion Navigation Properties
    }
}

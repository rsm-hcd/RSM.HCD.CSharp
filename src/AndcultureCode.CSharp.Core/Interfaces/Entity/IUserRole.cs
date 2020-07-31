namespace AndcultureCode.CSharp.Core.Interfaces.Entity
{
    /// <summary>
    /// Associates a role to a user
    /// </summary>
    public interface IUserRole
    {
        #region Properties

        /// <summary>
        /// Reference to IRole that has Id equal to RoleId
        /// </summary>
        IRole Role { get; set; }

        /// <summary>
        /// Unique identifier of associated IRole
        /// </summary>
        long RoleId { get; set; }

        /// <summary>
        /// Reference to IUser that has an Id equal to UserId
        /// </summary>
        IUser User { get; set; }

        /// <summary>
        /// Unique identifier of associated IUser
        /// </summary>
        /// <value></value>
        long UserId { get; set; }

        #endregion Properties
    }
}

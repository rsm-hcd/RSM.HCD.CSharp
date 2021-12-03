namespace AndcultureCode.CSharp.Core.Interfaces.Entity
{
    /// <summary>
    /// Describes an individual user/role setting
    /// </summary>
    public interface IUserMetadata : IEntity
    {
        #region Properties

        /// <summary>
        /// Can the name of this object be changed? (if not, system likely relies on it)
        /// </summary>
        bool IsNameEditable { get; set; }

        /// <summary>
        /// Name for metadata
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Unique identifier of associated IRole
        /// </summary>
        long? RoleId { get; set; }

        /// <summary>
        /// Type classification for metadata
        /// </summary>
        string Type { get; set; }

        /// <summary>
        /// Unique identifier of associated IUser
        /// </summary>
        /// <value></value>
        long UserId { get; set; }

        /// <summary>
        /// User's value for this setting
        /// </summary>
        string Value { get; set; }

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

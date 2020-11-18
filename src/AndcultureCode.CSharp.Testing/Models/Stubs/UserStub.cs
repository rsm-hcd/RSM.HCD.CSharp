using AndcultureCode.CSharp.Core.Models;

namespace AndcultureCode.CSharp.Testing.Models.Stubs
{
    /// <summary>
    /// Stub entity representing a User
    /// </summary>
    public class UserStub : Auditable
    {
        #region Public Properties

        /// <summary>
        /// Email address of the stub user
        /// </summary>
        /// <value></value>
        public string EmailAddress { get; set; }

        /// <summary>
        /// First name of the stub user
        /// </summary>
        /// <value></value>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of the stub user
        /// </summary>
        /// <value></value>
        public string LastName { get; set; }

        /// <summary>
        /// Id of a related stub user
        /// </summary>
        /// <value></value>
        public long? RelatedUserStubId { get; set; }

        #endregion Public Properties

        #region Navigation Properties

        /// <summary>
        /// Related stub user for testing navigation properties
        /// </summary>
        /// <value></value>
        public UserStub RelatedUserStub { get; set; }

        #endregion Navigation Properties
    }
}

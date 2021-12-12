namespace AndcultureCode.CSharp.Core.Constants
{
    /// <summary>
    /// Commonly used Claim types for APIs
    /// </summary>
    public class ApiClaimTypes
    {
        /// <summary>
        /// Is the current user elevated to super admin
        /// </summary>
        public const string IS_SUPER_ADMIN = "IsSuperAdmin";

        /// <summary>
        /// Active Role Id
        /// </summary>
        public const string ROLE_ID = "RoleId";

        /// <summary>
        /// Available Role Ids
        /// </summary>
        public const string ROLE_IDS = "RoleIds";

        /// <summary>
        /// Active Role Type
        /// </summary>
        public const string ROLE_TYPE = "RoleType";

        /// <summary>
        /// Current User Id
        /// </summary>
        public const string USER_ID = "UserId";

        /// <summary>
        /// Current User Login Id
        /// </summary>
        public const string USER_LOGIN_ID = "UserLoginId";
    }
}
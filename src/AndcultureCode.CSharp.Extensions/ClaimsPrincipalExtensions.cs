using System;
using System.Linq;
using System.Security.Claims;
using AndcultureCode.CSharp.Core.Constants;

namespace AndcultureCode.CSharp.Extensions
{
    /// <summary>
    /// Extension methods for ClaimsPrincipal
    /// </summary>
    public static class ClaimsPrincipalExtensions
    {
        /// <summary>
        /// Whether the current user is authenticated
        /// </summary>
        /// <param name="principal"></param>
        /// <returns></returns>
        public static bool IsAuthenticated(this ClaimsPrincipal principal)
        {
            if (principal?.Identity == null)
            {
                return false;
            }

            return principal.Identity.IsAuthenticated;
        }

        /// <summary>
        /// Retrieves whether the user is a super admin by way of their identity claims
        /// </summary>
        /// <param name="principal"></param>
        /// <returns></returns>
        public static bool IsSuperAdmin(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentNullException(nameof(principal));
            }

            if (principal.IsUnauthenticated())
            {
                return false;
            }

            return principal.HasClaim(ApiClaimTypes.IS_SUPER_ADMIN, "true");
        }

        /// <summary>
        /// Whether the current user is unauthenticated
        /// </summary>
        /// <param name="principal"></param>
        /// <returns></returns>
        public static bool IsUnauthenticated(this ClaimsPrincipal principal) => !principal.IsAuthenticated();

        /// <summary>
        /// Retrieves user's current role id by way of their identity claims
        /// </summary>
        /// <param name="principal"></param>
        /// <returns></returns>
        public static long? RoleId(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentNullException(nameof(principal));
            }

            if (principal.IsUnauthenticated())
            {
                return null;
            }

            var roleIdClaim = principal.Claims?.FirstOrDefault(c => c.Type == ApiClaimTypes.ROLE_ID);
            if (string.IsNullOrWhiteSpace(roleIdClaim?.Value))
            {
                return null;
            }

            return Convert.ToInt64(roleIdClaim.Value);
        }

        /// <summary>
        /// Retrieves user's role ids by way of their identity claims
        /// </summary>
        /// <param name="principal"></param>
        /// <returns></returns>
        public static string[] RoleIds(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentNullException(nameof(principal));
            }

            if (principal.IsUnauthenticated())
            {
                return new string[0];
            }

            return (principal.Claims?.FirstOrDefault(c => c.Type == ApiClaimTypes.ROLE_IDS)?.Value ?? "").Split(',');
        }

        /// <summary>
        /// Retrieves user's id by way of identity claims
        /// </summary>
        /// <param name="principal"></param>
        /// <returns></returns>
        public static long? UserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentNullException(nameof(principal));
            }

            if (principal.IsUnauthenticated())
            {
                return null;
            }

            var userIdClaim = principal.Claims?.FirstOrDefault(c => c.Type == ApiClaimTypes.USER_ID);
            if (string.IsNullOrWhiteSpace(userIdClaim?.Value))
            {
                return null;
            }

            return Convert.ToInt64(userIdClaim.Value);
        }

        /// <summary>
        /// Retrieves user's UserLoginId from identity claims.
        /// </summary>
        /// <param name="principal"></param>
        /// <returns></returns>
        public static long? UserLoginId(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentNullException(nameof(principal));
            }

            if (principal.IsUnauthenticated())
            {
                return null;
            }

            var userLoginIdClaim = principal.Claims?.FirstOrDefault(c => c.Type == ApiClaimTypes.USER_LOGIN_ID);
            if (string.IsNullOrWhiteSpace(userLoginIdClaim?.Value))
            {
                return null;
            }

            return Convert.ToInt64(userLoginIdClaim.Value);
        }
    }
}

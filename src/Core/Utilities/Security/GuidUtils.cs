using System;

namespace AndcultureCode.CSharp.Core.Utilities.Security
{
    /// <summary>
    /// Guid related helper functions
    /// </summary>
    public class GuidUtils
    {
        /// <summary>
        /// Is the supplied string an invalid GUID?
        /// </summary>
        public static bool IsInvalid(string guidString) => !IsValid(guidString);

        /// <summary>
        /// Is the supplied string an valid GUID?
        /// </summary>
        public static bool IsValid(string guidString)
        {
            try
            {
                new Guid(guidString);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

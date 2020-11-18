using AndcultureCode.CSharp.Core.Models.Errors;
using AndcultureCode.CSharp.Testing.Constants;
using CoreErrorConstants = AndcultureCode.CSharp.Core.Constants.ErrorConstants;

namespace AndcultureCode.CSharp.Testing.Factories
{
    /// <summary>
    /// Factory for building out configurations of the `Error` class
    /// </summary>
    public class ErrorFactory : Factory
    {
        #region Constants

        /// <summary>
        /// Represents a basic error for testing.
        /// </summary>
        public const string BASIC_ERROR = "BASIC_ERROR";

        /// <summary>
        /// Represents a 'RESOURCE_NOT_FOUND' error using the Core error key.
        /// </summary>
        public const string RESOURCE_NOT_FOUND_ERROR = CoreErrorConstants.ERROR_RESOURCE_NOT_FOUND_KEY;

        #endregion Constants

        #region Public Methods

        /// <inheritdoc />
        public override void Define()
        {
            this.DefineFactory(() => new Error
            {
                Key = $"ErrorKey{UniqueNumber}",
                Message = Random.Words()
            });

            this.DefineFactory(BASIC_ERROR, () => new Error
            {
                Key = ErrorConstants.BASIC_ERROR_KEY,
                Message = ErrorConstants.BASIC_ERROR_MESSAGE
            });

            this.DefineFactory(RESOURCE_NOT_FOUND_ERROR, () => new Error
            {
                Key = CoreErrorConstants.ERROR_RESOURCE_NOT_FOUND_KEY,
                Message = Random.Words()
            });
        }

        #endregion Public Methods
    }
}

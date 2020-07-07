using AndcultureCode.CSharp.Core.Models;
using AndcultureCode.CSharp.Testing.Constants;
using CoreErrorConstants = AndcultureCode.CSharp.Core.Constants.ErrorConstants;

namespace AndcultureCode.CSharp.Testing.Factories
{
    public class ErrorFactory : Factory
    {
        #region Constants

        public const string BASIC_ERROR = "BASIC_ERROR";
        public const string RESOURCE_NOT_FOUND_ERROR = CoreErrorConstants.ERROR_RESOURCE_NOT_FOUND_KEY;

        #endregion Constants

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
    }
}

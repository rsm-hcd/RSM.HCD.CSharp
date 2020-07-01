using AndcultureCode.CSharp.Core.Models;
using AndcultureCode.CSharp.Testing.Constants;

namespace AndcultureCode.CSharp.Testing.Factories
{
    public class ErrorFactory : Factory
    {
        #region Constants

        public const string BASIC_ERROR = "BASIC_ERROR";

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
        }
    }
}

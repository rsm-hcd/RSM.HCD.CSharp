using AndcultureCode.CSharp.Testing.Factories;
using AndcultureCode.CSharp.Core.Models.Errors;
using AndcultureCode.CSharp.Testing.Constants;
using CoreErrorConstants = AndcultureCode.CSharp.Core.Constants.ErrorConstants;

namespace AndcultureCode.CSharp.Conductors.Tests
{

    /// <summary>
    /// [TODO]: move to "AndcultureCode.CSharp.Testing/src/AndcultureCode.CSharp.Testing/Factories/" ?
    /// like https://github.com/AndcultureCode/AndcultureCode.CSharp.Testing/blob/87637ca7b71c72ec8bd989f637b70bc512c4d6f4/src/AndcultureCode.CSharp.Testing/Factories/ErrorFactory.cs
    /// </summary>
    public class TestEntityFactory : Factory
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

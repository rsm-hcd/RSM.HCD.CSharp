using System.Collections.Generic;
using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Core.Models;
using AndcultureCode.CSharp.Testing.Constants;
using Moq.Language.Flow;

namespace AndcultureCode.CSharp.Testing.Extensions.Mocks
{
    public static class IResultReturnExtensions
    {
        public static IReturnsResult<T> ReturnsBasicErrorResult<T, TResult>(this ISetup<T, IResult<TResult>> setup,
            TResult resultObject = default(TResult)
        ) where T: class
        {
            return setup
                .Returns(new Result<TResult> {
                    Errors = new List<IError> {
                        ErrorConstants.BasicError
                    },
                    ResultObject = resultObject
                });
        }
    }
}
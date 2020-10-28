using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Core.Models;
using AndcultureCode.CSharp.Core.Models.Errors;
using AndcultureCode.CSharp.Testing.Constants;
using Moq.Language;
using Moq.Language.Flow;
using System.Collections.Generic;

namespace AndcultureCode.CSharp.Testing.Extensions.Mocks
{
    public static class IResultReturnExtensions
    {
        /// <summary>
        /// Returns basic error result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static IReturnsResult<T> ReturnsBasicErrorResult<T, TResult>(this ISetup<T, IResult<TResult>> setup,
            TResult resultObject = default(TResult)
        ) where T : class
        {
            return setup
                .Returns(new Result<TResult>
                {
                    Errors = new List<IError> {
                        ErrorConstants.BasicError
                    },
                    ResultObject = resultObject
                });
        }

        public static ISetupSequentialResult<IResult<TResult>> ReturnsBasicErrorSequentialResult<TResult>(this ISetupSequentialResult<IResult<TResult>> setup,
           TResult resultObject = default(TResult)
       )
        {
            return setup
                .Returns(new Result<TResult>
                {
                    Errors = new List<IError> {
                        ErrorConstants.BasicError
                    },
                    ResultObject = resultObject
                });
        }

        public static IReturnsResult<T> ReturnsGivenResult<T, TResult>(this ISetup<T, IResult<TResult>> setup,
            TResult resultObject = default(TResult)
        ) where T : class
        {
            return setup
                .Returns(new Result<TResult>
                {
                    Errors = new List<IError>(),
                    ResultObject = resultObject
                });
        }

    }
}

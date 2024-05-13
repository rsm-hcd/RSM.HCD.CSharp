using RSM.HCD.CSharp.Core.Interfaces;
using RSM.HCD.CSharp.Core.Models;
using RSM.HCD.CSharp.Core.Models.Entities;
using RSM.HCD.CSharp.Core.Models.Errors;
using RSM.HCD.CSharp.Testing.Constants;
using Moq.Language;
using Moq.Language.Flow;
using System.Collections.Generic;
using System.Linq;

namespace RSM.HCD.CSharp.Testing.Extensions
{
    /// <summary>
    /// Setup extension methods.
    /// </summary>
    public static class ISetupExtensions
    {
        /// <summary>
        /// Returns basic error result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static IReturnsResult<T> ReturnsBasicErrorResult<T, TResult>(
            this ISetup<T, IResult<TResult>> setup,
            TResult resultObject = default(TResult)
        ) where T : class
        {
            return setup
                .Returns(new Result<TResult>
                {
                    Errors = new List<IError>
                    {
                        ErrorConstants.BasicError
                    },
                    ResultObject = resultObject
                });
        }

        /// <summary>
        /// Returns basic error sequential result.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static ISetupSequentialResult<IResult<TResult>> ReturnsBasicErrorSequentialResult<TResult>(
            this ISetupSequentialResult<IResult<TResult>> setup,
            TResult resultObject = default(TResult)
        )
        {
            return setup
                .Returns(new Result<TResult>
                {
                    Errors = new List<IError>
                    {
                        ErrorConstants.BasicError
                    },
                    ResultObject = resultObject
                });
        }

        /// <summary>
        /// Returns given result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static IReturnsResult<T> ReturnsGivenResult<T, TResult>(
            this ISetup<T, IResult<TResult>> setup,
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

        /// <summary>
        /// Returns given result in sequence of the setup.
        /// </summary>
        /// <param name="setup"></param>
        /// <param name="resultObject"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static ISetupSequentialResult<IResult<TResult>> ReturnsGivenSequentialResult<TResult>(
            this ISetupSequentialResult<IResult<TResult>> setup,
            TResult resultObject = default(TResult)
        )
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

using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Core.Interfaces.Conductors;
using AndcultureCode.CSharp.Core.Models.Errors;
using AndcultureCode.CSharp.Core.Models.Entities;
using AndcultureCode.CSharp.Testing.Constants;
using Moq;
using Moq.Language;
using Moq.Language.Flow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AndcultureCode.CSharp.Testing.Extensions
{
    /// <summary>
    /// Extension methods for mocking methods of the `IRepositoryReadConductor` interface
    /// </summary>
    public static class IRepositoryReadConductorMockExtensions
    {
        #region FindAll

        #region Setup

        /// <summary>
        /// Sets up the FindAll method on a repository read conductor.
        /// NOTE: There is a known issue when trying to allow the filter and orderBy to be supplied
        /// via parameters. There seems to be an issue around Moq and c# "Expressions". See
        /// https://andculture.atlassian.net/browse/CCALMS2-599
        /// </summary>
        /// <param name="mock">The read repository conductor being mocked.</param>
        /// <param name="includeProperties">The value for includeProperties to be setup (optional)</param>
        /// <param name="skip">The value for skip to be setup (optional)</param>
        /// <param name="take">The value for take to be setup (optional)</param>
        /// <param name="ignoreQueryFilters">The value for ignoreQueryFilters to be setup (optional)</param>
        /// <param name="asNoTracking">The value for asNoTracking to be setup (optional)</param>
        /// <typeparam name="T">The model type applied to the repository read conductor.</typeparam>
        /// <returns>A setup FindAll method on the supplied mocked conductor.</returns>
        public static ISetup<IRepositoryReadConductor<T>, IResult<IQueryable<T>>> SetupFindAll<T>(this Mock<IRepositoryReadConductor<T>> mock,
            string includeProperties = null,
            int? skip = null,
            int? take = null,
            bool? ignoreQueryFilters = false,
            bool? asNoTracking = false
        ) where T : Entity
        {
            var includePropertiesParam = includeProperties != null ? includeProperties : It.IsAny<string>();
            var skipParam = skip.HasValue ? skip : It.IsAny<int?>();
            var takeParam = take.HasValue ? take : It.IsAny<int?>();
            var ignoreQueryFiltersParam = ignoreQueryFilters.HasValue ? ignoreQueryFilters : It.IsAny<bool?>();
            var asNoTrackingParam = asNoTracking.HasValue ? asNoTracking.Value : It.IsAny<bool>();

            return mock
                .Setup(e => e.FindAll(
                        It.IsAny<Expression<Func<T, bool>>>(),
                        It.IsAny<Func<IQueryable<T>, IOrderedQueryable<T>>>(),
                        includePropertiesParam,
                        skipParam,
                        takeParam,
                        ignoreQueryFiltersParam,
                        asNoTrackingParam)
                );
        }

        public static Mock<IRepositoryReadConductor<T>> SetupFindAllReturnsBasicErrorResult<T>(this Mock<IRepositoryReadConductor<T>> mock,
            string includeProperties = null,
            int? skip = null,
            int? take = null,
            bool? ignoreQueryFilters = false,
            bool? asNoTracking = false
        ) where T : Entity
        {
            mock
                .SetupFindAll(includeProperties, skip, take, ignoreQueryFilters, asNoTracking)
                .ReturnsBasicErrorResult();
            return mock;
        }

        public static Mock<IRepositoryReadConductor<T>> SetupFindAllReturnsGivenResult<T>(this Mock<IRepositoryReadConductor<T>> mock,
            string includeProperties = null,
            int? skip = null,
            int? take = null,
            bool? ignoreQueryFilters = false,
            IQueryable<T> resultObject = null
        ) where T : Entity
        {
            mock
                .SetupFindAll(includeProperties, skip, take, ignoreQueryFilters)
                .ReturnsGivenResult(resultObject);
            return mock;
        }

        public static ISetupSequentialResult<IResult<IQueryable<T>>> SetupFindAllSequence<T>(this Mock<IRepositoryReadConductor<T>> mockRepository,
            string includeProperties = null,
            int? skip = null,
            int? take = null,
            bool? ignoreQueryFilters = false,
            bool? asNoTracking = false
        ) where T : Entity
        {
            var includePropertiesParam = includeProperties != null ? includeProperties : It.IsAny<string>();
            var skipParam = skip.HasValue ? skip : It.IsAny<int?>();
            var takeParam = take.HasValue ? take : It.IsAny<int?>();
            var ignoreQueryFiltersParam = ignoreQueryFilters.HasValue ? ignoreQueryFilters : It.IsAny<bool?>();
            var asNoTrackingParam = asNoTracking.HasValue ? asNoTracking.Value : It.IsAny<bool>();

            return mockRepository
                .SetupSequence(m => m.FindAll(
                    It.IsAny<Expression<Func<T, bool>>>(),
                    It.IsAny<Func<IQueryable<T>, IOrderedQueryable<T>>>(),
                    includePropertiesParam,
                    skipParam,
                    takeParam,
                    ignoreQueryFiltersParam,
                    asNoTrackingParam)
                );
        }

        public static ISetupSequentialResult<IResult<IQueryable<T>>> ReturnsGivenSequentialResult<T>(
            this ISetupSequentialResult<IResult<IQueryable<T>>> setupSequence,
            bool success,
            IEnumerable<T> entityCollection
        ) where T : Entity
        {
            return setupSequence.Returns(new Result<IQueryable<T>>
            {
                Errors = success ? null : new List<IError> { new Error { Key = "ERROR_KEY" } },
                ResultObject = success ? entityCollection.AsQueryable() : null
            });
        }

        #endregion Setup

        #region Verify

        public static Mock<IRepositoryReadConductor<T>> VerifyFindAll<T>(this Mock<IRepositoryReadConductor<T>> mock,
            Func<Times> times,
            string includeProperties = null,
            int? skip = null,
            int? take = null,
            bool? ignoreQueryFilters = false,
            bool? asNoTracking = false
        ) where T : Entity
        {
            var includePropertiesParam = includeProperties != null ? includeProperties : It.IsAny<string>();
            var skipParam = skip.HasValue ? skip : It.IsAny<int?>();
            var takeParam = take.HasValue ? take : It.IsAny<int?>();
            var ignoreQueryFiltersParam = ignoreQueryFilters.HasValue ? ignoreQueryFilters : It.IsAny<bool?>();
            var asNoTrackingParam = asNoTracking.HasValue ? asNoTracking.Value : It.IsAny<bool>();

            mock.Verify(e => e.FindAll(
                It.IsAny<Expression<System.Func<T, bool>>>(),
                It.IsAny<Func<IQueryable<T>, IOrderedQueryable<T>>>(),
                includePropertiesParam,
                skipParam,
                takeParam,
                ignoreQueryFiltersParam,
                asNoTrackingParam
            ), times);

            return mock;
        }

        #endregion Verify

        #endregion FindAll

        #region FindAllCommitted

        #region Setup

        /// <summary>
        /// Sets up the FindAllCommitted method on a repository read conductor.
        /// NOTE: There is a known issue when trying to allow the filter and orderBy to be supplied
        /// via parameters. There seems to be an issue around Moq and c# "Expressions". See
        /// https://andculture.atlassian.net/browse/CCALMS2-599
        /// </summary>
        /// <param name="mock">The read repository conductor being mocked.</param>
        /// <param name="includeProperties">The value for includeProperties to be setup (optional)</param>
        /// <param name="skip">The value for skip to be setup (optional)</param>
        /// <param name="take">The value for take to be setup (optional)</param>
        /// <param name="ignoreQueryFilters">The value for ignoreQueryFilters to be setup (optional)</param>
        /// <typeparam name="T">The model type applied to the repository read conductor.</typeparam>
        /// <returns>A setup FindAllCommitted method on the supplied mocked conductor.</returns>
        public static ISetup<IRepositoryReadConductor<T>, IResult<IList<T>>> SetupFindAllCommitted<T>(this Mock<IRepositoryReadConductor<T>> mock,
            string includeProperties = null,
            int? skip = null,
            int? take = null,
            bool? ignoreQueryFilters = false
        ) where T : Entity
        {
            var includePropertiesParam = includeProperties != null ? includeProperties : It.IsAny<string>();
            var skipParam = skip.HasValue ? skip : It.IsAny<int?>();
            var takeParam = take.HasValue ? take : It.IsAny<int?>();
            var ignoreQueryFiltersParam = ignoreQueryFilters.HasValue ? ignoreQueryFilters : It.IsAny<bool?>();

            return mock
                .Setup(e => e.FindAllCommitted(
                        It.IsAny<Expression<Func<T, bool>>>(),
                        It.IsAny<Func<IQueryable<T>, IOrderedQueryable<T>>>(),
                        includePropertiesParam,
                        skipParam,
                        takeParam,
                        ignoreQueryFiltersParam)
                );
        }

        public static Mock<IRepositoryReadConductor<T>> SetupFindAllCommittedReturnsBasicErrorResult<T>(this Mock<IRepositoryReadConductor<T>> mock,
            string includeProperties = null,
            int? skip = null,
            int? take = null,
            bool? ignoreQueryFilters = false
        ) where T : Entity
        {
            mock
                .SetupFindAllCommitted(includeProperties, skip, take, ignoreQueryFilters)
                .ReturnsBasicErrorResult();
            return mock;
        }

        public static Mock<IRepositoryReadConductor<T>> SetupFindAllCommittedReturnsGivenResult<T>(this Mock<IRepositoryReadConductor<T>> mock,
            string includeProperties = null,
            int? skip = null,
            int? take = null,
            bool? ignoreQueryFilters = false,
            IList<T> resultObject = null
        ) where T : Entity
        {
            mock
                .SetupFindAllCommitted(includeProperties, skip, take, ignoreQueryFilters)
                .ReturnsGivenResult(resultObject);
            return mock;
        }

        #endregion Setup

        #region Verify

        public static Mock<IRepositoryReadConductor<T>> VerifyFindAllCommitted<T>(this Mock<IRepositoryReadConductor<T>> mock,
            Func<Times> times,
            string includeProperties = null,
            int? skip = null,
            int? take = null,
            bool? ignoreQueryFilters = false
        ) where T : Entity
        {
            var includePropertiesParam = includeProperties != null ? includeProperties : It.IsAny<string>();
            var skipParam = skip.HasValue ? skip : It.IsAny<int?>();
            var takeParam = take.HasValue ? take : It.IsAny<int?>();
            var ignoreQueryFiltersParam = ignoreQueryFilters.HasValue ? ignoreQueryFilters : It.IsAny<bool?>();

            mock.Verify(e => e.FindAllCommitted(
                It.IsAny<Expression<System.Func<T, bool>>>(),
                It.IsAny<Func<IQueryable<T>, IOrderedQueryable<T>>>(),
                includePropertiesParam,
                skipParam,
                takeParam,
                ignoreQueryFiltersParam
            ), times);

            return mock;
        }

        #endregion Verify

        #endregion FindAllCommitted


        #region FindById(long id)

        public static ISetup<IRepositoryReadConductor<T>, IResult<T>> SetupFindById<T>(this Mock<IRepositoryReadConductor<T>> mock,
            long? id = null
        ) where T : Entity
        {
            return mock
                .Setup(e => e.FindById(
                    id.HasValue ? id.Value : It.IsAny<long>())
                );
        }

        public static Mock<IRepositoryReadConductor<T>> SetupFindByIdReturnsBasicErrorResult<T>(this Mock<IRepositoryReadConductor<T>> mock,
            long? id = null
        ) where T : Entity
        {
            mock
                .SetupFindById(id)
                .ReturnsBasicErrorResult();
            return mock;
        }

        public static Mock<IRepositoryReadConductor<T>> SetupFindByIdReturnsGivenResult<T>(this Mock<IRepositoryReadConductor<T>> mock,
            long? id = null,
            T resultObject = null
        ) where T : Entity
        {
            mock
                .SetupFindById(id)
                .ReturnsGivenResult(resultObject);
            return mock;
        }

        #endregion FindById(long id)


        #region FindById(long id, params string[] includeProperties)

        public static ISetup<IRepositoryReadConductor<T>, IResult<T>> SetupFindById<T>(this Mock<IRepositoryReadConductor<T>> mock,
            long? id = null,
            params string[] includeProperties
        ) where T : Entity
        {
            return mock
                .Setup(e => e.FindById(
                    id.HasValue ? id.Value : It.IsAny<long>(),
                    includeProperties != null ? includeProperties : It.IsAny<string[]>())
                );
        }

        public static Mock<IRepositoryReadConductor<T>> SetupFindByIdReturnsBasicErrorResult<T>(this Mock<IRepositoryReadConductor<T>> mock,
            long? id = null,
            params string[] includeProperties
        ) where T : Entity
        {
            mock
                .SetupFindById(id, includeProperties)
                .ReturnsBasicErrorResult();
            return mock;
        }

        public static Mock<IRepositoryReadConductor<T>> SetupFindByIdReturnsGivenResult<T>(this Mock<IRepositoryReadConductor<T>> mock,
            long? id = null,
            string[] includeProperties = null,
            T resultObject = null
        ) where T : Entity
        {
            mock
                .SetupFindById(id, includeProperties)
                .ReturnsGivenResult(resultObject);
            return mock;
        }

        #endregion FindById(long id, params string[] includeProperties)


        #region Returns

        public static ISetupSequentialResult<IResult<TResult>> ReturnsGivenSequentialResult<TResult>(this ISetupSequentialResult<IResult<TResult>> setup,
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

        #endregion Returns
    }
}

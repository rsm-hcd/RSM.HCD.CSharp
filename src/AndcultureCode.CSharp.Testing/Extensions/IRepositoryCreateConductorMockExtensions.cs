using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Core.Interfaces.Conductors;
using AndcultureCode.CSharp.Core.Models.Entities;
using Moq;
using Moq.Language.Flow;
using System.Collections.Generic;
using System.Linq;

namespace AndcultureCode.CSharp.Testing.Extensions
{
    /// <summary>
    /// Extension methods for mocking methods of the `IRepositoryCreateConductor` interface
    /// </summary>
    public static class IRepositoryCreateConductorMockExtensions
    {
        #region Create(T item, createdById = null)

        public static ISetup<IRepositoryCreateConductor<T>, IResult<T>> SetupCreate<T>(this Mock<IRepositoryCreateConductor<T>> mock,
            T item = null,
            long? createdById = null
            ) where T : Entity
        {
            var createdByIdParam = createdById.HasValue ? createdById.Value : It.IsAny<long?>();

            // Avoid use of null colaesce with item ?? It.IsAny<T>()
            // it does not evaluate correctly when the Mock is prepared using complex objects
            // Appears to work properly for primitives
            if (item == null)
            {
                return mock.Setup(e => e.Create(It.IsAny<T>(), createdByIdParam));
            }

            return mock.Setup(e => e.Create(item, createdByIdParam));
        }

        public static Mock<IRepositoryCreateConductor<T>> SetupCreateReturnsBasicErrorResult<T>(this Mock<IRepositoryCreateConductor<T>> mock,
            T item = null,
            long? createdById = null
            ) where T : Entity
        {
            mock
                .SetupCreate(item, createdById)
                .ReturnsBasicErrorResult();
            return mock;
        }

        /// <summary>
        /// Mock a IRepositoryCreateConductor<T> with a successful Create() method call.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mock"></param>
        /// <param name="item">Parameter passed to the Create() method, if null, uses It.IsAny (useful if you don't want a reference)</param>
        /// <param name="createdById">Parameter passed to the Create() method, if null, uses It.IsAny</param>
        /// <param name="returned">Desired object to return in ResultObject, if null uses item, otherwise null</param>
        /// <returns></returns>
        public static Mock<IRepositoryCreateConductor<T>> SetupCreateReturnsGivenResult<T>(this Mock<IRepositoryCreateConductor<T>> mock,
            T item = null,
            long? createdById = null,
            T returned = null
            ) where T : Entity
        {
            mock
                .SetupCreate(item, createdById)
                .ReturnsGivenResult(returned ?? item ?? null);
            return mock;
        }

        #endregion Create(T item, createdById = null)

        #region Create(IEnumerable<T> item, createdById = null)

        public static ISetup<IRepositoryCreateConductor<T>, IResult<List<T>>> SetupCreate<T>(this Mock<IRepositoryCreateConductor<T>> mock,
            IEnumerable<T> items,
            long? createdById = null
            ) where T : Entity
        {
            var createdByIdParam = createdById.HasValue ? createdById.Value : It.IsAny<long?>();
            return mock.Setup(e => e.Create(items, createdByIdParam));
        }

        public static Mock<IRepositoryCreateConductor<T>> SetupCreateReturnsBasicErrorResult<T>(this Mock<IRepositoryCreateConductor<T>> mock,
            IEnumerable<T> items,
            long? createdById = null
            ) where T : Entity
        {
            mock
                .SetupCreate(items, createdById)
                .ReturnsBasicErrorResult();
            return mock;
        }

        public static Mock<IRepositoryCreateConductor<T>> SetupCreateReturnsGivenResult<T>(this Mock<IRepositoryCreateConductor<T>> mock,
            IEnumerable<T> items,
            long? createdById = null
            ) where T : Entity
        {
            mock
                .SetupCreate(items, createdById)
                .ReturnsGivenResult(items.ToList());
            return mock;
        }

        #endregion Create(IEnumerable<T> item, createdById = null)
    }
}
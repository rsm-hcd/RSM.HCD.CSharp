using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Core.Interfaces.Conductors;
using AndcultureCode.CSharp.Core.Models.Entities;
using Moq;
using Moq.Language.Flow;

namespace AndcultureCode.CSharp.Testing.Extensions.Mocks.Conductors
{
    public static class IRepositoryDeleteConductorMockExtensions
    {
        #region Delete(long id, long? deletedById = null, bool soft = true)

        public static ISetup<IRepositoryDeleteConductor<T>, IResult<bool>> SetupDelete<T>(this Mock<IRepositoryDeleteConductor<T>> mock,
            long  id,
            long? deletedById = null,
            bool  soft        = true
        ) where T : Entity
        {
            var deletedByIdParam  = deletedById.HasValue ? deletedById.Value : It.IsAny<long?>();
            return mock.Setup(e => e.Delete(id, deletedByIdParam, soft));
        }

        public static Mock<IRepositoryDeleteConductor<T>> SetupDeleteReturnsBasicErrorResult<T>(this Mock<IRepositoryDeleteConductor<T>> mock,
            long  id,
            long? deletedById = null,
            bool  soft        = true
        ) where T : Entity
        {
            mock
                .SetupDelete(id, deletedById, soft)
                .ReturnsBasicErrorResult();
            return mock;
        }

        public static Mock<IRepositoryDeleteConductor<T>> SetupDeleteReturnsGivenResult<T>(this Mock<IRepositoryDeleteConductor<T>> mock,
            long  id,
            long? deletedById  = null,
            bool  soft         = true,
            bool  resultObject = default(bool)
        ) where T : Entity
        {
            mock
                .SetupDelete(id, deletedById, soft)
                .ReturnsGivenResult(resultObject);
            return mock;
        }

        #endregion Delete(long id, long? deletedById = null, bool soft = true)


        #region Delete(T o, long? deletedById = null, bool soft = true);

        public static ISetup<IRepositoryDeleteConductor<T>, IResult<bool>> SetupDelete<T>(this Mock<IRepositoryDeleteConductor<T>> mock,
            T     o,
            long? deletedById = null,
            bool  soft        = true
        ) where T : Entity
        {
            var deletedByIdParam  = deletedById.HasValue ? deletedById.Value : It.IsAny<long?>();
            return mock.Setup(e => e.Delete(o, deletedByIdParam, soft));
        }

        public static Mock<IRepositoryDeleteConductor<T>> SetupDeleteReturnsBasicErrorResult<T>(this Mock<IRepositoryDeleteConductor<T>> mock,
            T     o,
            long? deletedById = null,
            bool  soft        = true
        ) where T : Entity
        {
            mock
                .SetupDelete(o, deletedById, soft)
                .ReturnsBasicErrorResult();
            return mock;
        }

        public static Mock<IRepositoryDeleteConductor<T>> SetupDeleteReturnsGivenResult<T>(this Mock<IRepositoryDeleteConductor<T>> mock,
            T     o,
            long? deletedById  = null,
            bool  soft         = true,
            bool  resultObject = default(bool)
        ) where T : Entity
        {
            mock
                .SetupDelete(o, deletedById, soft)
                .ReturnsGivenResult(resultObject);
            return mock;
        }

        #endregion Delete(T o, long? deletedById = null, bool soft = true);
    }
}
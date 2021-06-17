using Shouldly;
using AndcultureCode.CSharp.Core.Interfaces.Entity;
using AndcultureCode.CSharp.Testing.Constants;

namespace AndcultureCode.CSharp.Testing.Extensions
{
    /// <summary>
    /// Extension methods for asserting expected states of the `IUpdatable` interface
    /// </summary>
    public static class IUpdatableMatcherExtensions
    {
        /// <summary>
        /// Assert that the `IUpdatable` has a `UpdatedOn` value
        /// </summary>
        /// <param name="entity">Entity under test</param>
        public static void ShouldBeUpdated<TUpdatable>(this TUpdatable entity)
            where TUpdatable : IUpdatable
        {
            entity.ShouldNotBeNull();
            entity.UpdatedOn.ShouldNotBeNull();
        }

        /// <summary>
        /// Assert that the `IUpdatable` has the expected `UpdatedById`
        /// </summary>
        /// <param name="entity">Entity under test</param>
        /// <param name="updatedById">Expected id of the record's deletor</param>
        public static void ShouldBeUpdatedBy<TUpdatable>(this TUpdatable entity, long updatedById)
            where TUpdatable : IUpdatable
        {
            entity.ShouldNotBeNull();
            entity.UpdatedById.ShouldBe(updatedById);
        }

        /// <summary>
        /// Assert that the `IUpdatable` has the expected `UpdatedById`
        /// </summary>
        /// <param name="entity">Entity under test</param>
        /// <param name="updatedBy">Expected record's deletor</param>
        public static void ShouldBeUpdatedBy<TUpdatable>(this TUpdatable entity, IEntity updatedBy)
            where TUpdatable : IUpdatable
        {
            updatedBy.ShouldNotBeNull(ErrorConstants.ERROR_EXPECTED_ENTITY_IS_NULL_MESSAGE);
            entity.ShouldNotBeNull();
            entity.ShouldBeUpdatedBy(updatedBy.Id);
        }
    }
}

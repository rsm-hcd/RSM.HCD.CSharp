using Shouldly;
using AndcultureCode.CSharp.Core.Interfaces.Entity;
using AndcultureCode.CSharp.Testing.Constants;

namespace AndcultureCode.CSharp.Testing.Extensions
{
    /// <summary>
    /// Extension methods for asserting expected states of the `ICreatable` interface
    /// </summary>
    public static class ICreatableMatcherExtensions
    {
        /// <summary>
        /// Assert that the `ICreatable` has a `CreatedOn` value
        /// </summary>
        /// <param name="entity">Entity under test</param>
        public static void ShouldBeCreated<TCreatable>(this TCreatable entity)
            where TCreatable : ICreatable
        {
            entity.ShouldNotBeNull();
            entity.CreatedOn.ShouldNotBeNull();
        }

        /// <summary>
        /// Assert that the `ICreatable` has the expected `CreatedById`
        /// </summary>
        /// <param name="entity">Entity under test</param>
        /// <param name="createdById">Expected id of the record's creator</param>
        public static void ShouldBeCreatedBy<TCreatable>(this TCreatable entity, long createdById)
            where TCreatable : ICreatable
        {
            entity.ShouldNotBeNull();
            entity.CreatedById.ShouldBe(createdById);
        }

        /// <summary>
        /// Assert that the `ICreatable` has the expected `CreatedById`
        /// </summary>
        /// <param name="entity">Entity under test</param>
        /// <param name="createdBy">Expected record's creator</param>
        public static void ShouldBeCreatedBy<TCreatable>(this TCreatable entity, IEntity createdBy)
            where TCreatable : ICreatable
        {
            createdBy.ShouldNotBeNull(ErrorConstants.ERROR_EXPECTED_ENTITY_IS_NULL_MESSAGE);
            entity.ShouldNotBeNull();
            entity.ShouldBeCreatedBy(createdBy.Id);
        }
    }
}

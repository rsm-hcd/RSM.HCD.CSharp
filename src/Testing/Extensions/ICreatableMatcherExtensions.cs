using RSM.HCD.CSharp.Core.Interfaces.Entity;
using RSM.HCD.CSharp.Testing.Constants;
using Shouldly;

namespace RSM.HCD.CSharp.Testing.Extensions
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
            where TCreatable : class, ICreatable
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
            where TCreatable : class, ICreatable
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
            where TCreatable : class, ICreatable
        {
            createdBy.ShouldNotBeNull(ErrorConstants.ERROR_EXPECTED_ENTITY_IS_NULL_MESSAGE);
            entity.ShouldNotBeNull();
            entity.ShouldBeCreatedBy(createdBy.Id);
        }

        /// <summary>
        /// Assert that the `ICreatable` has a null `CreatedOn` value
        /// </summary>
        /// <param name="entity">Entity under test</param>
        public static void ShouldNotBeCreated<TCreatable>(this TCreatable entity)
            where TCreatable : class, ICreatable
        {
            entity.ShouldNotBeNull();
            entity.CreatedOn.ShouldBeNull();
        }

        /// <summary>
        /// Assert that the `ICreatable` does not match the provided `CreatedById`
        /// </summary>
        /// <param name="entity">Entity under test</param>
        /// <param name="createdById">Unexpected id of the record's creator</param>
        public static void ShouldNotBeCreatedBy<TCreatable>(
            this TCreatable entity,
            long createdById
        )
            where TCreatable : class, ICreatable
        {
            entity.ShouldNotBeNull();
            entity.CreatedById.ShouldNotBe(createdById);
        }

        /// <summary>
        /// Assert that the `ICreatable` does not match the provided `CreatedById`
        /// </summary>
        /// <param name="entity">Entity under test</param>
        /// <param name="createdBy">Unexpected record's creator</param>
        public static void ShouldNotBeCreatedBy<TCreatable>(
            this TCreatable entity,
            IEntity createdBy
        )
            where TCreatable : class, ICreatable
        {
            createdBy.ShouldNotBeNull(ErrorConstants.ERROR_EXPECTED_ENTITY_IS_NULL_MESSAGE);
            entity.ShouldNotBeNull();
            entity.ShouldNotBeCreatedBy(createdBy.Id);
        }
    }
}

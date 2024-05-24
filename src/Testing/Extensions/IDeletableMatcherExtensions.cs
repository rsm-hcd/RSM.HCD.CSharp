using RSM.HCD.CSharp.Core.Interfaces.Entity;
using RSM.HCD.CSharp.Testing.Constants;
using Shouldly;

namespace RSM.HCD.CSharp.Testing.Extensions
{
    /// <summary>
    /// Extension methods for asserting expected states of the `IDeletable` interface
    /// </summary>
    public static class IDeletableMatcherExtensions
    {
        /// <summary>
        /// Assert that the `IDeletable` has a `DeletedOn` value
        /// </summary>
        /// <param name="entity">Entity under test</param>
        public static void ShouldBeDeleted<TDeletable>(this TDeletable entity)
            where TDeletable : class, IDeletable
        {
            entity.ShouldNotBeNull();
            entity.DeletedOn.ShouldNotBeNull();
        }

        /// <summary>
        /// Assert that the `IDeletable` has the expected `DeletedById`
        /// </summary>
        /// <param name="entity">Entity under test</param>
        /// <param name="deletedById">Expected id of the record's deletor</param>
        public static void ShouldBeDeletedBy<TDeletable>(this TDeletable entity, long deletedById)
            where TDeletable : class, IDeletable
        {
            entity.ShouldNotBeNull();
            entity.DeletedById.ShouldBe(deletedById);
        }

        /// <summary>
        /// Assert that the `IDeletable` has the expected `DeletedById`
        /// </summary>
        /// <param name="entity">Entity under test</param>
        /// <param name="deletedBy">Expected record's deletor</param>
        public static void ShouldBeDeletedBy<TDeletable>(this TDeletable entity, IEntity deletedBy)
            where TDeletable : class, IDeletable
        {
            deletedBy.ShouldNotBeNull(ErrorConstants.ERROR_EXPECTED_ENTITY_IS_NULL_MESSAGE);
            entity.ShouldNotBeNull();
            entity.ShouldBeDeletedBy(deletedBy.Id);
        }

        /// <summary>
        /// Assert that the `IDeletable` has a null `DeletedOn` value
        /// </summary>
        /// <param name="entity">Entity under test</param>
        public static void ShouldNotBeDeleted<TDeletable>(this TDeletable entity)
            where TDeletable : class, IDeletable
        {
            entity.ShouldNotBeNull();
            entity.DeletedOn.ShouldBeNull();
        }

        /// <summary>
        /// Assert that the `IDeletable` does not match the provided `DeletedById`
        /// </summary>
        /// <param name="entity">Entity under test</param>
        /// <param name="deletedById">Unexpected id of the record's deletor</param>
        public static void ShouldNotBeDeletedBy<TDeletable>(
            this TDeletable entity,
            long deletedById
        )
            where TDeletable : class, IDeletable
        {
            entity.ShouldNotBeNull();
            entity.DeletedById.ShouldNotBe(deletedById);
        }

        /// <summary>
        /// Assert that the `IDeletable` does not match the provided `DeletedById`
        /// </summary>
        /// <param name="entity">Entity under test</param>
        /// <param name="deletedBy">Unexpected record's deletor</param>
        public static void ShouldNotBeDeletedBy<TDeletable>(
            this TDeletable entity,
            IEntity deletedBy
        )
            where TDeletable : class, IDeletable
        {
            deletedBy.ShouldNotBeNull(ErrorConstants.ERROR_EXPECTED_ENTITY_IS_NULL_MESSAGE);
            entity.ShouldNotBeNull();
            entity.ShouldNotBeDeletedBy(deletedBy.Id);
        }
    }
}

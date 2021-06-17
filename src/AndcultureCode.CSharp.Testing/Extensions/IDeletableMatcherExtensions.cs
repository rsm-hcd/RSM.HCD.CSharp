using Shouldly;
using AndcultureCode.CSharp.Core.Interfaces.Entity;
using AndcultureCode.CSharp.Testing.Constants;

namespace AndcultureCode.CSharp.Testing.Extensions
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
            where TDeletable : IDeletable
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
            where TDeletable : IDeletable
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
            where TDeletable : IDeletable
        {
            deletedBy.ShouldNotBeNull(ErrorConstants.ERROR_EXPECTED_ENTITY_IS_NULL_MESSAGE);
            entity.ShouldNotBeNull();
            entity.ShouldBeDeletedBy(deletedBy.Id);
        }
    }
}

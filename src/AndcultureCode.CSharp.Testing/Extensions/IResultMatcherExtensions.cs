using System.Linq;
using AndcultureCode.CSharp.Core.Extensions;
using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Testing.Constants;
using Shouldly;
using CoreErrorConstants = AndcultureCode.CSharp.Core.Constants.ErrorConstants;
using AndcultureCode.CSharp.Core.Interfaces.Entity;
using System.Collections.Generic;

namespace AndcultureCode.CSharp.Testing.Extensions
{
    /// <summary>
    /// Extension methods for asserting expected states of the `IResult` interface
    /// </summary>
    public static class IResultMatcherExtensions
    {

        #region Public Methods

        #region IResult<bool> Extensions

        /// <summary>
        /// Assert that the result has at least one error
        /// </summary>
        /// <param name="result">Result under test</param>
        /// <param name="exactCount">When supplied, asserts the result has this exact number of errors</param>
        public static void ShouldHaveErrors(this IResult<bool> result, int? exactCount = null)
        {
            result.ShouldHaveErrors<bool>(exactCount);
            result.ResultObject.ShouldBeFalse();
        }

        #endregion IResult<bool> Extensions

        #region IResult<ICreatable> Extensions

        /// <summary>
        /// Assert that the `ResultObject` has a `CreatedOn` value
        /// </summary>
        /// <param name="result">Result under test</param>
        public static void ShouldBeCreated<TCreatable>(this IResult<TCreatable> result) where TCreatable : ICreatable
        {
            result.ShouldHaveResultObject();
            result.ResultObject.ShouldBeCreated();
        }

        /// <summary>
        /// Assert that the `ResultObject` has the expected `CreatedById`
        /// </summary>
        /// <param name="result">Result under test</param>
        /// <param name="createdById">Expected id of the record's creator</param>
        public static void ShouldBeCreatedBy<TCreatable>(this IResult<TCreatable> result, long createdById)
            where TCreatable : ICreatable
        {
            result.ShouldHaveResultObject();
            result.ResultObject.ShouldBeCreatedBy(createdById);
        }

        /// <summary>
        /// Assert that the `ResultObject` has the expected `CreatedById`
        /// </summary>
        /// <param name="result">Result under test</param>
        /// <param name="createdBy">Expected record's creator</param>
        public static void ShouldBeCreatedBy<TCreatable>(this IResult<TCreatable> result, IEntity createdBy)
            where TCreatable : ICreatable
        {
            result.ShouldHaveResultObject();
            result.ResultObject.ShouldBeCreatedBy(createdBy);
        }

        #endregion IResult<ICreatable> Extensions

        #region IResult<IDeletable> Extensions

        /// <summary>
        /// Assert that the `ResultObject` has a `DeletedOn` value
        /// </summary>
        /// <param name="result">Result under test</param>
        public static void ShouldBeDeleted<TDeletable>(this IResult<TDeletable> result) where TDeletable : IDeletable
        {
            result.ShouldHaveResultObject();
            result.ResultObject.ShouldBeDeleted();
        }

        /// <summary>
        /// Assert that the `ResultObject` has the expected `DeletedById`
        /// </summary>
        /// <param name="result">Result under test</param>
        /// <param name="deletedById">Expected id of the record's deletor</param>
        public static void ShouldBeDeletedBy<TDeletable>(this IResult<TDeletable> result, long deletedById)
            where TDeletable : IDeletable
        {
            result.ShouldHaveResultObject();
            result.ResultObject.ShouldBeDeletedBy(deletedById);
        }

        /// <summary>
        /// Assert that the `ResultObject` has the expected `DeletedById`
        /// </summary>
        /// <param name="result">Result under test</param>
        /// <param name="deletedBy">Expected record's deletor</param>
        public static void ShouldBeDeletedBy<TDeletable>(this IResult<TDeletable> result, IEntity deletedBy)
            where TDeletable : IDeletable
        {
            result.ShouldHaveResultObject();
            result.ResultObject.ShouldBeDeletedBy(deletedBy);
        }

        #endregion IResult<IDeletable> Extensions

        #region IResult<IUpdatable> Extensions

        /// <summary>
        /// Assert that the `ResultObject` has an `UpdatedOn` value
        /// </summary>
        /// <param name="result">Result under test</param>
        public static void ShouldBeUpdated<TUpdatable>(this IResult<TUpdatable> result) where TUpdatable : IUpdatable
        {
            result.ShouldHaveResultObject();
            result.ResultObject.ShouldBeUpdated();
        }

        /// <summary>
        /// Assert that the `ResultObject` has the expected `UpdatedById`
        /// </summary>
        /// <param name="result">Result under test</param>
        /// <param name="updatedById">Expected id of the record's updater</param>
        public static void ShouldBeUpdatedBy<TUpdatable>(this IResult<TUpdatable> result, long updatedById)
            where TUpdatable : IUpdatable
        {
            result.ShouldHaveResultObject();
            result.ResultObject.ShouldBeUpdatedBy(updatedById);
        }

        /// <summary>
        /// Assert that the `ResultObject` has the expected `UpdatedById`
        /// </summary>
        /// <param name="result">Result under test</param>
        /// <param name="updatedBy">Expected record's updater</param>
        public static void ShouldBeUpdatedBy<TUpdatable>(this IResult<TUpdatable> result, IEntity updatedBy)
            where TUpdatable : IUpdatable
        {
            result.ShouldHaveResultObject();
            result.ResultObject.ShouldBeUpdatedBy(updatedBy);
        }

        #endregion IResult<IUpdatable> Extensions

        #region IResult<T> Extensions

        /// <summary>
        /// Assert result has error for `BASIC_ERROR_KEY`
        /// </summary>
        /// <param name="result">Result under test</param>
        public static void ShouldHaveBasicError<T>(this IResult<T> result) => result.ShouldHaveErrorsFor(ErrorConstants.BASIC_ERROR_KEY);

        /// <summary>
        /// Assert that the result has at least one error
        /// </summary>
        /// <param name="result">Result under test</param>
        /// <param name="exactCount">When supplied, asserts the result has this exact number of errors</param>
        public static void ShouldHaveErrors<T>(this IResult<T> result, int? exactCount = null)
        {
            result.ShouldNotBeNull();
            result.Errors.ShouldNotBeNull(ErrorConstants.ERROR_ERRORS_LIST_IS_NULL_MESSAGE);
            result.Errors.Count.ShouldBeGreaterThan(0);
            result.ErrorCount.ShouldBeGreaterThan(0);
            result.HasErrors.ShouldBeTrue();

            if (exactCount != null)
            {
                result.ErrorCount.ShouldBe((int)exactCount);
                result.Errors.ShouldBeOfSize((int)exactCount);
            }
        }

        /// <summary>
        /// Assert that there are errors for the supplied property
        /// </summary>
        /// <param name="result">Result under test</param>
        /// <param name="property">Key of the error to be asserted against</param>
        /// <param name="exactCount">When supplied, asserts the exact number of errors with the property. NOT total number of errors</param>
        /// <param name="containedInMessage">When supplied, asserts that the property's error message contains this string</param>
        public static void ShouldHaveErrorsFor<T>(this IResult<T> result, string property, int? exactCount = null, string containedInMessage = null)
        {
            result.ShouldHaveErrors<T>();
            result.Errors.ShouldContain(
                elementPredicate: (e) => e.Key == property,
                customMessage: $"Expected error '{property}' but did not: {result.ListErrors()}"
            );

            if (!string.IsNullOrWhiteSpace(containedInMessage))
            {
                containedInMessage = containedInMessage.ToLower();

                result.Errors.ShouldContain(
                    elementPredicate: (e) => e.Key == property && e.Message.ToLower().Contains(containedInMessage),
                    customMessage: $"Expected error '{property}' to contain '{containedInMessage}' in message, but did not: {result.ListErrors()}"
                );
            }

            if (exactCount != null)
            {
                result.Errors.Where((e) => e.Key == property).ShouldBeOfSize((int)exactCount);
            }
        }

        /// <summary>
        /// Assert error exists for `ERROR_RESOURCE_NOT_FOUND_KEY`
        /// </summary>
        /// <param name="result">Result under test</param>
        public static void ShouldHaveResourceNotFoundError<T>(this IResult<T> result) =>
            result.ShouldHaveErrorsFor(CoreErrorConstants.ERROR_RESOURCE_NOT_FOUND_KEY);

        /// <summary>
        /// Assert that `ResultObject` is not null
        /// </summary>
        /// <param name="result">Result under test</param>
        public static void ShouldHaveResultObject<T>(this IResult<T> result)
        {
            result.ShouldNotBeNull();
            result.ResultObject.ShouldNotBeNull($"Expected {nameof(IResult<T>.ResultObject)} to have a value, but it was null.");
        }

        /// <summary>
        /// Assert that an IEnumerable `ResultObject` has values
        /// </summary>
        /// <param name="result">Result under test</param>
        /// <param name="exactCount">When supplied, asserts that the collection has exactly this number of elements</param>
        public static void ShouldHaveResultObjects<T>(this IResult<IEnumerable<T>> result, int? exactCount = null)
        {
            result.ShouldHaveResultObject();
            if (exactCount != null)
            {
                result.ResultObject.ShouldBeOfSize((int)exactCount);
                return;
            }

            result.ResultObject.ShouldNotBeEmpty();
        }

        /// <summary>
        /// Assert that there are no errors for the given result
        /// </summary>
        /// <param name="result">Result under test</param>
        public static void ShouldNotHaveErrors<T>(this IResult<T> result)
        {
            result.Errors?.Count.ShouldBe(0, $"Unexpected errors: {result.ListErrors()}");
            result.ErrorCount.ShouldBe(0);
            result.HasErrors.ShouldBeFalse($"Unexpected errors: {result.ListErrors()}");
        }

        /// <summary>
        /// Assert that there weren't any errors for the supplied property
        /// </summary>
        /// <param name="result">Result under test</param>
        /// <param name="property">Key of the error to be asserted against</param>
        public static void ShouldNotHaveErrorsFor<T>(this IResult<T> result, string property)
        {
            if (result.Errors == null || result.Errors.Count == 0)
            {
                return;
            }

            result.Errors.ShouldNotContain(
                elementPredicate: (e) => e.Key == property,
                customMessage: $"Expected not to have an error with key '{property}' but found: {result.ListErrors()}"
            );
        }

        #endregion IResult<T> Extensions

        #endregion Public Methods
    }
}

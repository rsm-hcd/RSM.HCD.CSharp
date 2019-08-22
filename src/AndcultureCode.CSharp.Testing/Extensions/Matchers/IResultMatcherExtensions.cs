using System.Linq;
using AndcultureCode.CSharp.Core.Extensions;
using AndcultureCode.CSharp.Core.Interfaces;
using Shouldly;

namespace AndcultureCode.CSharp.Testing.Extensions
{
    public static class IResultMatcherExtensions
    {
        public static void ShouldHaveErrors<T>(this IResult<T> result, int? exactCount = null)
        {
            result.Errors.ShouldNotBeNull("Expected result to have errors, but instead Errors is 'null'");
            result.Errors.Count.ShouldBeGreaterThan(0);
            result.ErrorCount.ShouldBeGreaterThan(0);
            result.HasErrors.ShouldBeTrue(result.ListErrors());

            if (exactCount != null)
            {
                result.ErrorCount.ShouldBe((int)exactCount);
                result.Errors.Count.ShouldBe((int)exactCount);
            }
        }

        public static void ShouldHaveErrors(this IResult<bool> result, int? exactCount = null)
        {
            result.ShouldNotBeNull();
            result.Errors.ShouldNotBeNull("Result Errors property was unexpectedly null");
            result.Errors.Count.ShouldBeGreaterThan(0);
            result.ErrorCount.ShouldBeGreaterThan(0);
            result.HasErrors.ShouldBeTrue(result.ListErrors());
            result.ResultObject.ShouldBeFalse();

            if (exactCount != null)
            {
                result.ErrorCount.ShouldBe((int)exactCount);
                result.Errors.Count.ShouldBe((int)exactCount);
            }
        }

        /// <summary>
        /// Assert that there are errors for the supplied property
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <param name="property"></param>
        /// <param name="exactCount">Exact number of errors with the property. NOT total number of errors</param>
        /// <param name="containedInMessage">Whens supplied, asserts that the property's error message contains this string</param>
        public static void ShouldHaveErrorsFor<T>(this IResult<T> result, string property, int? exactCount = null, string containedInMessage = null)
        {
            result.Errors.ShouldContain(e => e.Key == property, result.ListErrors());
            result.ErrorCount.ShouldBeGreaterThan(0);
            result.HasErrors.ShouldBeTrue();

            if (!string.IsNullOrWhiteSpace(containedInMessage))
            {
                containedInMessage = containedInMessage.ToLower();

                result.Errors.ShouldContain(e => e.Key == property && e.Message.ToLower().Contains(containedInMessage), result.ListErrors());
            }

            if (exactCount != null)
            {
                result.Errors.Where(e => e.Key == property).Count().ShouldBe((int)exactCount);
            }
        }

        public static void ShouldNotHaveErrors<T>(this IResult<T> result)
        {
            result.Errors?.Count.ShouldBe(0, $"Unexpected errors: {result.ListErrors()}");
            result.ErrorCount.ShouldBe(0);
            result.HasErrors.ShouldBeFalse($"Unexpected errors: {result.ListErrors()}");
        }

        /// <summary>
        /// Assert that there weren't any errors for the supplied property
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <param name="property"></param>
        public static void ShouldNotHaveErrorsFor<T>(this IResult<T> result, string property)
        {
            if (result.Errors == null || result.Errors.Count == 0)
            {
                return;
            }

            result.Errors.ShouldNotContain(e => e.Key == property);
        }
    }
}

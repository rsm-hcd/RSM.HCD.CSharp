using System.Collections.Generic;
using Shouldly;

namespace AndcultureCode.CSharp.Testing.Extensions
{
    public static class IEnumerableMatcherExtensions
    {
        /// <summary>
        /// Asserts if a collection contains the exact values in the supplied collection
        /// </summary>
        /// <param name="Expression<Func<T"></param>
        /// <param name="actual"></param>
        /// <typeparam name="T"></typeparam>
        public static void ShouldContain<T>(this IEnumerable<T> actual, IEnumerable<T> expected)
        {
            actual.ShouldNotBeNull();
            expected.ShouldNotBeNull();

            foreach (var expectedItem in expected)
            {
                actual.ShouldContain(expectedItem);
            }
        }
    }
}
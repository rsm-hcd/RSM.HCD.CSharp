using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shouldly;

namespace RSM.HCD.CSharp.Testing.Extensions
{
    /// <summary>
    /// Extension methods for asserting expected states of `IEnumerable` types
    /// </summary>
    public static class IEnumerableMatcherExtensions
    {
        /// <summary>
        /// Assert that an IEnumerable{T} has a certain length.
        /// </summary>
        /// <param name="items"></param>
        /// <param name="expectedSize"></param>
        /// <typeparam name="T"></typeparam>
        /// <exception cref="ShouldAssertException"></exception>
        public static void ShouldBeOfSize<T>(this IEnumerable<T> items, int expectedSize)
        {
            var actualSize = items.Count();
            if (actualSize != expectedSize)
            {
                throw new ShouldAssertException(
                    $"IEnumerable should have size {expectedSize} but actual size was {actualSize}."
                );
            }
        }

        /// <summary>
        /// Assert that a list of T is ordered (ascending) by property of type V.
        /// </summary>
        /// <param name="items"></param>
        /// <param name="keySelector"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <exception cref="ShouldAssertException"></exception>
        public static void ShouldBeOrderedBy<T, TValue>(
            this IEnumerable<T> items,
            Func<T, TValue> keySelector
        ) where TValue : IComparable<TValue>
        {
            for (var i = 0; i < items.Count(); i++)
            {
                // we're on the last one, just continue
                if (i == items.Count() - 1)
                {
                    continue;
                }

                // otherwise, compare it to the one ahead of it
                var currentItem = keySelector(items.ElementAt(i));
                var nextItem = keySelector(items.ElementAt(i + 1));

                if (currentItem.CompareTo(nextItem) > 0)
                {
                    var message = new StringBuilder("Items should be ordered ascending but are not.");
                    message.AppendLine($"\nSelected key for elements[{i}]: {currentItem}");
                    message.AppendLine($"Selected key for elements[{i + 1}]: {nextItem}");
                    throw new ShouldAssertException(message.ToString());
                }
            }
        }

        /// <summary>
        /// Assert that a list of T is ordered (descending) by property of type V.
        /// </summary>
        /// <param name="items"></param>
        /// <param name="keySelector"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <exception cref="ShouldAssertException"></exception>
        public static void ShouldBeOrderedByDescending<T, TValue>(
            this IEnumerable<T> items,
            Func<T, TValue> keySelector
        ) where TValue : IComparable<TValue>
        {
            for (var i = 0; i < items.Count(); i++)
            {
                // we're on the last one, just continue
                if (i == items.Count() - 1)
                {
                    continue;
                }

                // otherwise, compare it to the one ahead of it
                var currentItem = keySelector(items.ElementAt(i));
                var nextItem = keySelector(items.ElementAt(i + 1));

                if (currentItem.CompareTo(nextItem) < 0)
                {
                    var message = new StringBuilder("Items should be ordered descending but are not.");
                    message.AppendLine($"\nSelected key for elements[{i}]: {currentItem}");
                    message.AppendLine($"Selected key for elements[{i + 1}]: {nextItem}");
                    throw new ShouldAssertException(message.ToString());
                }
            }
        }

        /// <summary>
        /// Asserts if a collection contains the exact values in the supplied collection
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
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

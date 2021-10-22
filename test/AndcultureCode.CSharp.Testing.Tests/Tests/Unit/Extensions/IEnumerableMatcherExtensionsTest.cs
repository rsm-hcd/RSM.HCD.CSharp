using System.Collections.Generic;
using System.Linq;
using AndcultureCode.CSharp.Testing.Extensions;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace AndcultureCode.CSharp.Testing.Tests.Unit.Extensions
{
    public class IEnumerableMatcherExtensionsTest : BaseUnitTest
    {
        #region Constructor

        public IEnumerableMatcherExtensionsTest(ITestOutputHelper output) : base(output)
        {
        }

        #endregion Constructor

        #region ShouldBeOfSize

        [Fact]
        public void ShouldBeOfSize_When_ExpectedSize_NotEqual_ActualSize_Then_Throws_ShouldAssertException()
        {
            // Arrange
            // simple trick to get a List<char> of random size
            var items = Random.String().ToList();
            var expectedSize = items.Count;
            var incorrectSize = expectedSize + Random.Int(2, 5);

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => items.ShouldBeOfSize(incorrectSize));
        }

        [Fact]
        public void ShouldBeOfSize_When_ExpectedSize_Is_ActualSize_Then_Does_Not_Throw_ShouldAssertException()
        {
            // Arrange
            // simple trick to get a List<char> of random size
            var items = Random.String().ToList();
            var expectedSize = items.Count;

            // Act & Assert
            items.ShouldBeOfSize(expectedSize);
        }

        #endregion ShouldBeOfSize

        #region ShouldBeOrderedBy

        [Fact]
        public void ShouldBeOrderedBy_When_Not_Ordered_Then_Throws_ShouldAssertException()
        {
            // Arrange
            var items = new List<int>();
            var n = Random.Int(5, 25);
            for (var i = 0; i < n; i++)
            {
                items.Add(Random.Int());
            }

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => items.ShouldBeOrderedBy(e => e));
        }

        [Fact]
        public void ShouldBeOrderedBy_When_Ordered_Then_Does_Not_Throw_ShouldAssertException()
        {
            // Arrange
            var items = new List<int>();
            var n = Random.Int(5, 25);
            for (var i = 0; i < n; i++)
            {
                items.Add(i);
            }

            // Act & Assert
            items.ShouldBeOrderedBy(e => e);
        }

        #endregion ShouldBeOrderedBy

        #region ShouldBeOrderedByDescending

        [Fact]
        public void ShouldBeOrderedByDescending_When_Not_Ordered_Then_Throws_ShouldAssertException()
        {
            // Arrange
            var items = new List<int>();
            var n = Random.Int(5, 25);
            for (var i = 0; i < n; i++)
            {
                items.Add(Random.Int());
            }

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => items.ShouldBeOrderedByDescending(e => e));
        }

        [Fact]
        public void ShouldBeOrderedByDescending_When_Ordered_Then_Does_Not_Throw_ShouldAssertException()
        {
            // Arrange
            var items = new List<int>();
            var n = Random.Int(5, 25);
            for (var i = n; i > 0; i--)
            {
                items.Add(i);
            }

            // Act & Assert
            items.ShouldBeOrderedByDescending(e => e);
        }

        #endregion ShouldBeOrderedByDescending
    }
}

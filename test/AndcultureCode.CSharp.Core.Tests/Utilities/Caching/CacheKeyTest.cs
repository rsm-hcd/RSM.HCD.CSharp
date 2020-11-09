using Xunit.Abstractions;
using Xunit;
using Shouldly;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using AndcultureCode.CSharp.Core.Utilities.Caching;
using AndcultureCode.CSharp.Core.Tests.Unit.Stubs;

namespace AndcultureCode.CSharp.Core.Tests.Unit.Utilities.Caching
{
    public class CacheKeyAttributeTest : CoreUnitTest
    {
        #region Setup

        public CacheKeyAttributeTest(ITestOutputHelper output) : base(output) { }

        #endregion Setup

        #region GetKey

        [Fact]
        public void GetKey_When_Id_Set_Returns_Key_Containing_Type()
        {
            CacheKeys.GetKey<CultureStub>(id: Random.Long()).ShouldContain(typeof(CultureStub).Name);
        }

        [Fact]
        public void GetKey_When_Id_Set_Returns_Key_Containing_Id()
        {
            // Arrange
            var expected = Random.Long();

            // Act & Assert
            CacheKeys.GetKey<CultureStub>(id: expected).ShouldContain(expected.ToString());
        }

        [Fact]
        public void GetKey_When_Include_Properties_Set_Returns_Key_Containing_Sorted_Properties()
        {
            // Arrange
            var delimiter = "-";
            var includeProperties = new List<Expression<Func<CultureStub, object>>>
            {
                e => e.IsDefault, // <--- intentionally out of sort order
                e => e.Code
            };

            // Act
            var result = CacheKeys.GetKey<CultureStub>(
                id: Random.Long(),
                delimiter: delimiter,
                includeProperties: includeProperties
            );

            // Assert
            result.ShouldContain($"Code{delimiter}IsDefault");
        }

        #endregion GetKey
    }
}

using System;
using AndcultureCode.CSharp.Core.Models;
using AndcultureCode.CSharp.Core.Tests.Stubs;
using AndcultureCode.CSharp.Core.Tests.Unit;
using AndcultureCode.CSharp.Testing;
using AndcultureCode.CSharp.Testing.Tests;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace AndcultureCode.CSharp.Core.Tests.Models.Entities
{
    public class ConnectionTest : CoreUnitTest
    {
        #region Setup

        public ConnectionTest(ITestOutputHelper output) : base(output)
        {
        }

        #endregion Setup

        #region ToString

        [Fact]
        public void ToString_Given_No_Parameters_When_Property_Null_Returns_Without_Property()
        {
            // Arrange
            var sut = Build<Connection>(e => e.Database = null);

            // Act
            var result = sut.ToString();

            // Assert
            result.ShouldNotBeEmpty();
            result.ToLower().ShouldNotContain("database");
        }

        [Fact]
        public void ToString_Given_No_Parameters_When_Property_EmptyString_Returns_Without_Property()
        {
            // Arrange
            var sut = Build<Connection>(e => e.Database = " ");

            // Act
            var result = sut.ToString();

            // Assert
            result.ShouldNotBeEmpty();
            result.ToLower().ShouldNotContain("database");
        }

        [Fact]
        public void ToString_Given_No_Parameters_Returns_SemiColon_Delimited_List()
        {
            // Arrange
            var sut = Build<Connection>();

            // Act
            var result = sut.ToString();

            // Assert
            result.ShouldNotBeEmpty();
            result.ShouldContain(";");
            result.ShouldContain(sut.AdditionalParameters);
            result.ShouldContain(sut.Database);
            result.ShouldContain(sut.Datasource);
            result.ShouldContain(sut.Password);
            result.ShouldContain(sut.UserId);
        }

        [Fact]
        public void ToString_Given_Delimiter_Returns_Custom_Delimited_List()
        {
            // Arrange
            var expected = Random.String(1);
            var sut = Build<Connection>();

            // Act
            var result = sut.ToString(delimiter: expected);

            // Assert
            result.ShouldNotBeEmpty();
            result.ShouldContain(expected);
            result.ShouldContain(sut.AdditionalParameters);
            result.ShouldContain(sut.Database);
            result.ShouldContain(sut.Datasource);
            result.ShouldContain(sut.Password);
            result.ShouldContain(sut.UserId);
        }

        #endregion ToString
    }
}

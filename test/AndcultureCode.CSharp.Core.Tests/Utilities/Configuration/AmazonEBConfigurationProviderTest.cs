using Shouldly;
using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;
using AndcultureCode.CSharp.Testing;
using AndcultureCode.CSharp.Testing.Extensions;
using AndcultureCode.CSharp.Core.Models;
using AndcultureCode.CSharp.Core.Extensions;
using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Core.Enumerations;
using AndcultureCode.CSharp.Core.Utilities.Configuration;
using Moq;

namespace AndcultureCode.CSharp.Core.Tests.Unit.Utilities.Configuration
{
    public class AndcultureEBConfigurationProviderTest : UnitTestBase
    {
        #region Setup

        public AndcultureEBConfigurationProviderTest(ITestOutputHelper output) : base(output) {}

        #endregion Setup


        #region Get

        [Fact]
        public void Get_When_Key_DoesNotExist_Returns_Null()
        {
            // Arrange
            var sut = new AmazonEBConfigurationProvider();

            // Act
            var result = sut.Get("notfound");

            // Assert
            result.ShouldBeNull();
        }

        [Fact]
        public void Get_When_Key_DoesExist_Returns_ExpectedValue()
        {
            // Arrange
            var expectedKey   = Random.String();
            var expectedValue = Random.String();
            var sutMock       = new Mock<AmazonEBConfigurationProvider>() { CallBase = true };
            var sut           = sutMock.Object;

            sutMock.Setup(e => e.ReadConfiguration()).Returns(new Dictionary<string, string> { { expectedKey, expectedValue }});

            // Act
            var result = sut.Get(expectedKey);

            // Assert
            result.ShouldBe(expectedValue);
        }

        #endregion Get


        #region Has

        [Fact]
        public void Has_When_Key_DoesNotExist_Returns_False()
        {
            // Arrange
            var sut = new AmazonEBConfigurationProvider();

            // Act
            var result = sut.Has("notfound");

            // Assert
            result.ShouldBeFalse();
        }

        [Fact]
        public void Has_When_Key_DoesExist_Returns_True()
        {
            // Arrange
            var expectedKey   = Random.String();
            var expectedValue = Random.String();
            var sutMock       = new Mock<AmazonEBConfigurationProvider>() { CallBase = true };
            var sut           = sutMock.Object;

            sutMock.Setup(e => e.ReadConfiguration()).Returns(new Dictionary<string, string> { { expectedKey, expectedValue }});

            // Act
            var result = sut.Has(expectedKey);

            // Assert
            result.ShouldBeTrue();
        }

        #endregion Has


        #region Load

        [Fact(Skip = "TODO: NFPA-84")]
        public void Load_When_NoConfigurationData_Returns_With_Data_NotNull()
        {
            // // Arrange
            // var sut = new AmazonEBConfigurationProvider();

            // // Act
            // sut.Load();

            // // Assert
            // sut.Data.ShouldNotBeNull();
        }

        #endregion Load


        #region ReadConfiguration

        [Fact(Skip = "TODO: NFPA-84")]
        public void ReadConfiguration_Write_Tests()
        {
            true.ShouldBeFalse();
        }

        #endregion ReadConfiguration
    }
}
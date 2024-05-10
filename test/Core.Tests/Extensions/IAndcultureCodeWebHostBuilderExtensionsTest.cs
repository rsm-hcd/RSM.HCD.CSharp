using Shouldly;
using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;
using RSM.HCD.CSharp.Testing;
using RSM.HCD.CSharp.Testing.Extensions;
using RSM.HCD.CSharp.Core.Models;
using RSM.HCD.CSharp.Core.Extensions;
using RSM.HCD.CSharp.Core.Interfaces;
using RSM.HCD.CSharp.Core.Enumerations;
using RSM.HCD.CSharp.Core.Interfaces.Hosting;
using RSM.HCD.CSharp.Core.Utilities.Configuration;
using Moq;
using RSM.HCD.CSharp.Testing.Tests;

namespace RSM.HCD.CSharp.Core.Tests.Unit.Extensions
{
    public class IRSMWebHostBuilderExtensionsTest : CoreUnitTest
    {
        #region Setup

        public IRSMWebHostBuilderExtensionsTest(ITestOutputHelper output) : base(output) { }

        #endregion Setup


        #region PreloadAmazonElasticBeanstalk

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void PreloadAmazonElasticBeanstalk_With_Default_Arguments_Returns_Builder(bool stdoutEnabled)
        {
            // Arrange
            var mockBuilder = new Mock<IRSMWebHostBuilder>();

            // Act
            var result = IRSMWebHostBuilderExtensions.PreloadAmazonElasticBeanstalk(mockBuilder.Object, stdoutEnabled);

            // Assert
            result.ShouldBe(mockBuilder.Object);
        }

        [Fact]
        public void PreloadAmazonElasticBeanstalk_When_Contains_AspNetCore_Environment_Sets_Global_EnvironmentVariable()
        {
            // Arrange
            var expected = $"testValue{Random.Int()}";
            var mockBuilder = new Mock<IRSMWebHostBuilder>();
            var mockProvider = new Mock<AmazonEBConfigurationProvider>();
            mockProvider.Setup(e => e.Has(IRSMWebHostBuilderExtensions.ASPNETCORE_ENVIRONMENT)).Returns(true);
            mockProvider.Setup(e => e.Get(IRSMWebHostBuilderExtensions.ASPNETCORE_ENVIRONMENT)).Returns(expected);

            // Act
            var result = IRSMWebHostBuilderExtensions.PreloadAmazonElasticBeanstalk(
                builder: mockBuilder.Object,
                stdoutEnabled: false,
                configurationProvider: mockProvider.Object
            );

            // Assert
            result.ShouldNotBeNull();
            Environment.GetEnvironmentVariable(IRSMWebHostBuilderExtensions.ASPNETCORE_ENVIRONMENT).ShouldBe(expected);
        }

        #endregion PreloadAmazonElasticBeanstalk
    }
}

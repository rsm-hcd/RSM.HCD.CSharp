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
using Microsoft.Extensions.Configuration;
using Moq;
using RSM.HCD.CSharp.Testing.Tests;

namespace RSM.HCD.CSharp.Core.Tests.Unit.Extensions
{
    public class IConfigurationBuilderExtensionsTest : CoreUnitTest
    {
        #region Setup

        public IConfigurationBuilderExtensionsTest(ITestOutputHelper output) : base(output) { }

        #endregion Setup


        #region AddAmazonElasticBeanstalk

        [Fact]
        public void AddAmazonElasticBeanstalk_Returns_Original_Builder()
        {
            // Arrange
            var mockBuilder = new Mock<IConfigurationBuilder>();

            // Act
            var result = IConfigurationBuilderExtensions.AddAmazonElasticBeanstalk(mockBuilder.Object);

            // Assert
            result.ShouldBe(mockBuilder.Object);
        }

        [Fact]
        public void AddAmazonElasticBeanstalk_Appends_New_ConfigurationSource()
        {
            // Arrange
            var mockBuilder = new Mock<IConfigurationBuilder>();

            // Act
            var result = IConfigurationBuilderExtensions.AddAmazonElasticBeanstalk(mockBuilder.Object);

            // Assert
            mockBuilder.Verify(e => e.Add(It.IsAny<IConfigurationSource>()), Times.Once);
        }

        #endregion AddAmazonElasticBeanstalk
    }
}

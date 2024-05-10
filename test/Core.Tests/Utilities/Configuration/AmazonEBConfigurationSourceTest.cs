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
using RSM.HCD.CSharp.Core.Utilities.Configuration;
using Moq;
using Microsoft.Extensions.Configuration;
using RSM.HCD.CSharp.Testing.Tests;

namespace RSM.HCD.CSharp.Core.Tests.Unit.Utilities.Configuration
{
    public class RSMEBConfigurationSourceTest : CoreUnitTest
    {
        #region Setup

        public RSMEBConfigurationSourceTest(ITestOutputHelper output) : base(output) { }

        #endregion Setup


        #region Build

        [Fact]
        public void Build_When_Null_Returns_Provider()
        {
            new AmazonEBConfigurationSource().Build(builder: null).ShouldNotBeNull();
        }

        [Fact]
        public void Build_When_NotNull_Returns_Provider()
        {
            new AmazonEBConfigurationSource()                             // Arrange
                .Build(builder: new Mock<IConfigurationBuilder>().Object) // Act
                    .ShouldNotBeNull();                                   // Assert
        }

        #endregion Build
    }
}

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
using RSM.HCD.CSharp.Core.Models.Hosting;
using RSM.HCD.CSharp.Testing.Tests;

namespace RSM.HCD.CSharp.Core.Tests.Unit.Models.Hosting
{
    public class RSMWebHostBuilderTest : CoreUnitTest
    {
        #region Setup

        public RSMWebHostBuilderTest(ITestOutputHelper output) : base(output) { }

        #endregion Setup


        #region Constructor (string[] args)

        [Fact]
        public void Constructor_Overload_With_Args_Null_Sets_Args_Null()
        {
            new RSMWebHostBuilder(args: null).Args.ShouldBeNull();
        }

        [Fact]
        public void Constructor_Overload_With_Args_NotNull_Sets_Args_To_Provided_Value()
        {
            // Arrange
            var expected = new string[] { Random.String() };

            // Act
            var sut = new RSMWebHostBuilder(args: expected);

            // Assert
            sut.Args.ShouldBe(expected);
        }

        #endregion Constructor (string[] args)


        #region CreateDefaultBuilder

        [Fact]
        public void CreateDefaultBuilder_Returns_Builder()
        {
            new RSMWebHostBuilder().CreateDefaultBuilder().ShouldNotBeNull();
        }

        #endregion CreateDefaultBuilder
    }
}

using System;
using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Core.Utilities.Security;
using AndcultureCode.CSharp.Testing;
using AndcultureCode.CSharp.Testing.Tests;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace AndcultureCode.CSharp.Core.Tests.Unit.Utilities.Security
{
    public class DoTest : CoreUnitTest
    {
        #region Setup

        public DoTest(ITestOutputHelper output) : base(output) { }

        #endregion Setup

        #region Constructor

        [Fact]
        public void Constructor_When_Workload_Null_Sets_Result()
        {
            new Do<bool>(workload: null).Result.ShouldNotBeNull();
        }

        [Fact]
        public void Constructor_When_Workload_Null_Sets_Workload_Null()
        {
            new Do<bool>(workload: null).Workload.ShouldBeNull();
        }

        [Fact]
        public void Constructor_When_Workload_Provided_Sets_Result()
        {
            new Do<bool>(workload: (r) => true).Result.ShouldNotBeNull();
        }

        [Fact]
        public void Constructor_When_Workload_Provided_Sets_Workload_To_Provided_Delegate()
        {
            // Arrange
            Func<IResult<bool>, bool> workload = (r) => true;

            // Act & Assert
            new Do<bool>(workload).Workload.ShouldBe(workload);
        }

        #endregion Constructor

        #region Then


        #endregion Then
    }
}

using System;
using AndcultureCode.CSharp.Core.Extensions;
using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Testing;
using AndcultureCode.CSharp.Testing.Extensions;
using AndcultureCode.CSharp.Testing.Tests;
using Moq;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace AndcultureCode.CSharp.Core.Tests.Unit
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

        [Fact]
        public void Then_When_Workload_Null_Returns_With_ExceptionError()
        {
            // Arrange
            var sut = new Do<bool>(workload: (r) => true);

            // Act
            var doInstance = sut.Then(workload: null);

            // Assert
            doInstance.Exception.ShouldNotBeNull();
            doInstance.Result.ShouldHaveErrors(1);
        }

        [Fact]
        public void Then_When_Workload_Throws_Exception_Returns_With_Error()
        {
            // Arrange
            var sut = new Do<bool>(workload: (r) => true);
            var exceptionMessage = Random.Words();
            var exception = new Exception(exceptionMessage);

            // Act
            var doInstance = sut.Then((r) => throw exception);

            // Assert
            doInstance.Result.ShouldHaveErrors(1);
            doInstance.Result.Errors[0].Message.ShouldContain(exceptionMessage);
        }

        [Fact]
        public void Then_When_Workload_DoesNotThrow_Exception_Returns_Forwarded_Value()
        {
            // Arrange
            var expected = Random.Words();
            Func<IResult<string>, string> workload = (r) => expected;
            var sut = new Do<string>(workload: (r) => $"not {expected}");

            // Act
            var doInstance = sut.Then(workload);

            // Assert
            doInstance.Result.ShouldNotHaveErrors();
            doInstance.Result.ResultObject.ShouldBe(expected);
        }

        [Fact]
        public void Then_Given_Instance_HasErrors_When_SkipIfErrors_True_Returns_Without_Invoking_Then()
        {
            // Arrange
            var sut = new Do<bool>(workload: (r) => true);
            sut.Result.AddError(Random.String(), Random.String());
            var isCalled = false;

            // Act
            sut.Then(
                (r) => isCalled = true, // <---- should NOT be executed
                skipIfErrors: true      // <---- because we are skipping when there are errors
            );

            // Assert
            isCalled.ShouldBeFalse();
        }

        [Fact]
        public void Then_Given_Instance_HasErrors_When_SkipIfErrors_False_Returns_Invokes_Then()
        {
            // Arrange
            var sut = new Do<bool>(workload: (r) => true);
            sut.Result.AddError(Random.String(), Random.String());
            var isCalled = false;

            // Act
            sut.Then(
                (r) => isCalled = true, // <---- should be executed
                skipIfErrors: false     // <---- because we are NOT skipping when there are errors
            );

            // Assert
            isCalled.ShouldBeTrue();
        }

        #endregion Then
    }
}

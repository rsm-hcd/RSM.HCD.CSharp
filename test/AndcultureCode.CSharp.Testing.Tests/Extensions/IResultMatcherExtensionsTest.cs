using AndcultureCode.CSharp.Core.Models;
using Shouldly;
using Xunit;
using Xunit.Abstractions;
using AndcultureCode.CSharp.Testing.Extensions;
using AndcultureCode.CSharp.Testing.Constants;
using System.Collections.Generic;
using AndcultureCode.CSharp.Core.Interfaces;

namespace AndcultureCode.CSharp.Testing.Tests.Extensions
{
    public class IResultMatcherExtensionsTest : BaseUnitTest
    {
        #region Setup

        public IResultMatcherExtensionsTest(ITestOutputHelper output) : base(output)
        {

        }

        #endregion Setup

        #region ShouldHaveBasicError

        [Fact]
        public void ShouldHaveBasicError_When_Errors_Null_Fails_Assertion()
        {
            // Arrange
            var result = BuildResult<object>((e) => e.Errors = null);

            // Act
            var ex = Record.Exception(() =>
            {
                result.ShouldHaveBasicError();
            });

            // Assert
            ex.ShouldNotBeNull();
            ex.Message.ShouldContain(IResultMatcherExtensions.ERROR_ERRORS_LIST_IS_NULL_MESSAGE);
        }

        [Fact]
        public void ShouldHaveBasicError_When_Errors_Empty_Fails_Assertion()
        {
            // Arrange
            var result = BuildResult<object>((e) => e.Errors = new List<IError>());

            // Act
            var ex = Record.Exception(() =>
            {
                result.ShouldHaveBasicError();
            });

            // Assert
            ex.ShouldNotBeNull();
        }

        [Fact]
        public void ShouldHaveBasicError_When_Errors_Contains_Other_Keys_Fails_Assertion()
        {
            // Arrange
            var result = BuildResult<object>((e) => e.Errors = new List<IError>
            {
                new Error
                {
                    Key = "Advanced Error Key",
                },
            });

            // Act
            var ex = Record.Exception(() =>
            {
                result.ShouldHaveBasicError();
            });

            // Assert
            ex.ShouldNotBeNull();
        }

        [Fact]
        public void ShouldHaveBasicError_When_Errors_Contains_BasicErrorKey_Passes_Assertion()
        {
            // Arrange
            var result = BuildResult<object>((e) => e.Errors = new List<IError>
            {
                ErrorConstants.BasicError,
            });

            // Act
            var ex = Record.Exception(() =>
            {
                result.ShouldHaveBasicError();
            });

            // Assert
            ex.ShouldBeNull();
        }

        #endregion ShouldHaveBasicError

        #region ShouldHaveErrors<T>

        [Fact]
        public void ShouldHaveErrors_T_When_Errors_Null_Fails_Assertion()
        {
            // Arrange
            var result = BuildResult<object>((e) => e.Errors = null);

            // Act
            var ex = Record.Exception(() =>
            {
                result.ShouldHaveErrors();
            });

            // Assert
            ex.ShouldNotBeNull();
            ex.Message.ShouldContain(IResultMatcherExtensions.ERROR_ERRORS_LIST_IS_NULL_MESSAGE);
        }

        [Fact]
        public void ShouldHaveErrors_T_When_Errors_Empty_Fails_Assertion()
        {
            // Arrange
            var result = BuildResult<object>((e) => e.Errors = new List<IError>());

            // Act
            var ex = Record.Exception(() =>
            {
                result.ShouldHaveErrors();
            });

            // Assert
            ex.ShouldNotBeNull();
        }

        [Fact]
        public void ShouldHaveErrors_T_When_Errors_HasValues_Passes_Assertion()
        {
            // Arrange
            var result = BuildResult<object>((e) => e.Errors = new List<IError>
            {
                ErrorConstants.BasicError,
            });

            // Act
            var ex = Record.Exception(() =>
            {
                result.ShouldHaveErrors();
            });

            // Assert
            ex.ShouldBeNull();
        }

        #endregion ShouldHaveErrors<T>

        #region ShouldHaveErrors<bool>

        [Fact]
        public void ShouldHaveErrors_Bool_When_Errors_Null_Fails_Assertion()
        {
            // Arrange
            var result = BuildResult<bool>((e) => e.Errors = null);

            // Act
            var ex = Record.Exception(() =>
            {
                result.ShouldHaveErrors();
            });

            // Assert
            ex.ShouldNotBeNull();
            ex.Message.ShouldContain(IResultMatcherExtensions.ERROR_ERRORS_LIST_IS_NULL_MESSAGE);
        }

        [Fact]
        public void ShouldHaveErrors_Bool_When_Errors_Empty_Fails_Assertion()
        {
            // Arrange
            var result = BuildResult<bool>((e) => e.Errors = new List<IError>());

            // Act
            var ex = Record.Exception(() =>
            {
                result.ShouldHaveErrors();
            });

            // Assert
            ex.ShouldNotBeNull();
        }

        [Fact]
        public void ShouldHaveErrors_Bool_When_ResultObject_True_Fails_Assertion()
        {
            // Arrange
            var errors = new List<IError>
            {
                ErrorConstants.BasicError,
            };
            var result = BuildResult<bool>(
                (e) => e.Errors = errors,
                (e) => e.ResultObject = true
            );

            // Act
            var ex = Record.Exception(() =>
            {
                result.ShouldHaveErrors();
            });

            // Assert
            ex.ShouldNotBeNull();
        }

        [Fact]
        public void ShouldHaveErrors_Bool_When_Errors_HasValues_Passes_Assertion()
        {
            // Arrange
            var result = BuildResult<bool>((e) => e.Errors = new List<IError>
            {
                ErrorConstants.BasicError,
            });

            // Act
            var ex = Record.Exception(() =>
            {
                result.ShouldHaveErrors();
            });

            // Assert
            ex.ShouldBeNull();
        }

        #endregion ShouldHaveErrors<bool>

        #region ShouldHaveErrorsFor

        [Fact]
        public void ShouldHaveErrorsFor_When_Errors_Null_Fails_Assertion()
        {
            // Arrange
            var result = BuildResult<object>((e) => e.Errors = null);

            // Act
            var ex = Record.Exception(() =>
            {
                result.ShouldHaveErrorsFor(ErrorConstants.BASIC_ERROR_KEY);
            });

            // Assert
            ex.ShouldNotBeNull();
            ex.Message.ShouldContain(IResultMatcherExtensions.ERROR_ERRORS_LIST_IS_NULL_MESSAGE);
        }

        [Fact]
        public void ShouldHaveErrorsFor_When_Errors_Empty_Fails_Assertion()
        {
            // Arrange
            var result = BuildResult<object>((e) => e.Errors = new List<IError>());

            // Act
            var ex = Record.Exception(() =>
            {
                result.ShouldHaveErrorsFor(ErrorConstants.BASIC_ERROR_KEY);
            });

            // Assert
            ex.ShouldNotBeNull();
        }

         [Fact]
        public void ShouldHaveErrorsFor_When_Errors_Contains_Other_Keys_Fails_Assertion()
        {
            // Arrange
            var result = BuildResult<object>((e) => e.Errors = new List<IError>
            {
                new Error
                {
                    Key = "Advanced Error Key",
                },
            });

            // Act
            var ex = Record.Exception(() =>
            {
                result.ShouldHaveErrorsFor(ErrorConstants.BASIC_ERROR_KEY);
            });

            // Assert
            ex.ShouldNotBeNull();
        }


        [Fact]
        public void ShouldHaveErrorsFor_When_Errors_Contains_Key_Passes_Assertion()
        {
            // Arrange
            var result = BuildResult<object>((e) => e.Errors = new List<IError>
            {
                ErrorConstants.BasicError,
            });

            // Act
            var ex = Record.Exception(() =>
            {
                result.ShouldHaveErrorsFor(ErrorConstants.BASIC_ERROR_KEY);
            });

            // Assert
            ex.ShouldBeNull();
        }

        #endregion ShouldHaveErrorsFor
    }
}
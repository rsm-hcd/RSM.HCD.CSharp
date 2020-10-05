using AndcultureCode.CSharp.Core.Models;
using Shouldly;
using Xunit;
using Xunit.Abstractions;
using AndcultureCode.CSharp.Testing.Extensions;
using AndcultureCode.CSharp.Testing.Constants;
using System.Collections.Generic;
using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Testing.Factories;
using System;
using AndcultureCode.CSharp.Core.Models.Errors;

namespace AndcultureCode.CSharp.Testing.Tests.Unit.Extensions
{
    public class IResultMatcherExtensionsTest : ProjectUnitTest
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

            // Act & Assert
            Should.Throw<Exception>(() =>
            {
                result.ShouldHaveBasicError();
            });
        }

        [Fact]
        public void ShouldHaveBasicError_When_Errors_Contains_Other_Keys_Fails_Assertion()
        {
            // Arrange
            var result = BuildResult<object>((e) => e.Errors = new List<IError>
            {
                Build<Error>()
            });

            // Act & Assert
            Should.Throw<Exception>(() =>
            {
                result.ShouldHaveBasicError();
            });
        }

        [Fact]
        public void ShouldHaveBasicError_When_Errors_Contains_BasicErrorKey_Passes_Assertion()
        {
            // Arrange
            var result = BuildResult<object>((e) => e.Errors = new List<IError>
            {
                Build<Error>(ErrorFactory.BASIC_ERROR)
            });

            // Act & Assert
            Should.NotThrow(() =>
            {
                result.ShouldHaveBasicError();
            });
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

            // Act & Assert
            Should.Throw<Exception>(() =>
            {
                result.ShouldHaveErrors();
            });
        }

        [Fact]
        public void ShouldHaveErrors_T_When_Errors_HasValues_Passes_Assertion()
        {
            // Arrange
            var result = BuildResult<object>((e) => e.Errors = new List<IError>
            {
                Build<Error>()
            });

            // Act & Assert
            Should.NotThrow(() =>
            {
                result.ShouldHaveErrors();
            });
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

            // Act & Assert
            Should.Throw<Exception>(() =>
            {
                result.ShouldHaveErrors();
            });
        }

        [Fact]
        public void ShouldHaveErrors_Bool_When_ResultObject_True_Fails_Assertion()
        {
            // Arrange
            var errors = new List<IError>
            {
                Build<Error>(ErrorFactory.BASIC_ERROR)
            };
            var result = BuildResult<bool>(
                (e) => e.Errors = errors,
                (e) => e.ResultObject = true
            );

            // Act & Assert
            Should.Throw<Exception>(() =>
            {
                result.ShouldHaveErrors();
            });
        }

        [Fact]
        public void ShouldHaveErrors_Bool_When_Errors_HasValues_Passes_Assertion()
        {
            // Arrange
            var result = BuildResult<bool>((e) => e.Errors = new List<IError>
            {
                Build<Error>()
            });

            // Act & Assert
            Should.NotThrow(() =>
            {
                result.ShouldHaveErrors();
            });
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

            // Act & Assert
            Should.Throw<Exception>(() =>
            {
                result.ShouldHaveErrorsFor(ErrorConstants.BASIC_ERROR_KEY);
            });
        }

        [Fact]
        public void ShouldHaveErrorsFor_When_Errors_Contains_Other_Keys_Fails_Assertion()
        {
            // Arrange
            var error = Build<Error>();
            var result = BuildResult<object>((e) => e.Errors = new List<IError>
            {
                error
            });

            // Act & Assert
            Should.Throw<Exception>(() =>
            {
                result.ShouldHaveErrorsFor($"not-{error.Key}");
            });
        }


        [Fact]
        public void ShouldHaveErrorsFor_When_Errors_Contains_Key_Passes_Assertion()
        {
            // Arrange
            var error = Build<Error>();
            var result = BuildResult<object>((e) => e.Errors = new List<IError>
            {
                error
            });

            // Act
            var ex = Record.Exception(() =>
            {
                result.ShouldHaveErrorsFor(error.Key);
            });

            // Assert
            ex.ShouldBeNull();
        }

        #endregion ShouldHaveErrorsFor

        #region ShouldHaveResourceNotFoundError

        [Fact]
        public void ShouldHaveResourceNotFoundError_When_Errors_Null_Fails_Assertion()
        {
            // Arrange
            var result = BuildResult<object>((e) => e.Errors = null);

            // Act
            var ex = Record.Exception(() =>
            {
                result.ShouldHaveResourceNotFoundError();
            });

            // Assert
            ex.ShouldNotBeNull();
            ex.Message.ShouldContain(IResultMatcherExtensions.ERROR_ERRORS_LIST_IS_NULL_MESSAGE);
        }

        [Fact]
        public void ShouldHaveResourceNotFoundError_When_Errors_Empty_Fails_Assertion()
        {
            // Arrange
            var result = BuildResult<object>((e) => e.Errors = new List<IError>());

            // Act & Assert
            Should.Throw<Exception>(() =>
            {
                result.ShouldHaveResourceNotFoundError();
            });
        }

        [Fact]
        public void ShouldHaveResourceNotFoundError_When_Errors_Contains_Other_Keys_Fails_Assertion()
        {
            // Arrange
            var result = BuildResult<object>((e) => e.Errors = new List<IError>
            {
                Build<Error>()
            });

            // Act & Assert
            Should.Throw<Exception>(() =>
            {
                result.ShouldHaveResourceNotFoundError();
            });
        }

        [Fact]
        public void ShouldHaveResourceNotFoundError_When_Errors_Contains_ResourceNotFoundKey_Passes_Assertion()
        {
            // Arrange
            var result = BuildResult<object>((e) => e.Errors = new List<IError>
            {
                Build<Error>(ErrorFactory.RESOURCE_NOT_FOUND_ERROR)
            });

            // Act & Assert
            Should.NotThrow(() =>
            {
                result.ShouldHaveResourceNotFoundError();
            });
        }


        #endregion ShouldHaveResourceNotFoundError
    }
}

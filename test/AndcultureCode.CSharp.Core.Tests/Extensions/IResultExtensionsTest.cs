using Shouldly;
using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;
using System.Linq;
using LMS.Core.Utilities;
using AndcultureCode.CSharp.Testing;
using AndcultureCode.CSharp.Testing.Extensions;
using AndcultureCode.CSharp.Core.Models;
using AndcultureCode.CSharp.Core.Extensions;
using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Core.Enumerations;

namespace AndcultureCode.CSharp.Core.Tests.Unit.Extensions
{
    public class IResultExtensionsTest : UnitTestBase
    {
        #region Setup

        public IResultExtensionsTest(ITestOutputHelper output) : base(output) {}

        #endregion Setup


        #region AddError(message)

        [Fact]
        public void AddError_MessageOnly_Overload_Adds_Error_With_Supplied_Message()
        {
            // Arrange
            var destinationResult = new Result<object>();
            var expectedMessage   = Random.String();

            // Act
            destinationResult.AddError(expectedMessage);

            // Assert
            destinationResult.Errors.ShouldContain(e => e.Message == expectedMessage);
        }

        [Fact]
        public void AddError_MessageOnly_Overload_Adds_Error_With_Key_Containing_Caller_ClassName()
        {
            // Arrange
            var destinationResult = new Result<object> ();
            var expectedClassName = this.GetType().Name;

            // Act
            destinationResult.AddError(Random.String());

            // Assert
            destinationResult.Errors.ShouldContain(e => e.Key.StartsWith(expectedClassName), $"Expected to startWith the class name of '{expectedClassName}', but it did not");
        }

        [Fact]
        public void AddError_MessageOnly_Overload_Adds_Error_With_Key_Containing_Caller_MethodName()
        {
            // Arrange
            var destinationResult  = new Result<object> ();
            var expectedMethodName = "AddError_MessageOnly_Overload_Adds_Error_With_Key_Containing_Caller_MethodName";

            // Act
            destinationResult.AddError(Random.String());

            // Assert
            destinationResult.Errors.ShouldContain(e => e.Key.EndsWith(expectedMethodName), $"Expected to endWith the method name of '{expectedMethodName}', but it did not");
        }

        [Fact]
        public IResult<bool> AddError_MessageOnly_Overload_When_Within_DoTry_Adds_Error_With_Key_Containing_Caller_ClassName() => Do<bool>.Try((r) =>
        {

            // Arrange
            var destinationResult = new Result<object> ();
            var expectedClassName = typeof(IResultExtensionsTest).Name;

            // Act
            destinationResult.AddError(Random.String());

            // Assert
            destinationResult.Errors.ShouldContain(e => e.Key.StartsWith(expectedClassName), $"Expected to startWith the class name of '{expectedClassName}', but it did not");

            return true;

        }).Catch<Exception>((ex, r) => {
            throw ex; // re-throw for test runner
        }).Result;

        [Fact]
        public IResult<bool> AddError_MessageOnly_Overload_When_Within_DoTry_Adds_Error_With_Key_Containing_Caller_MethodName() => Do<bool>.Try((r) =>
        {
            // Arrange
            var destinationResult  = new Result<object> ();
            var expectedMethodName = "AddError_MessageOnly_Overload_When_Within_DoTry_Adds_Error_With_Key_Containing_Caller_MethodName";

            // Act
            destinationResult.AddError(Random.String());

            // Assert
            destinationResult.Errors.ShouldContain(e => e.Key.EndsWith(expectedMethodName), $"Expected to endWith the method name of '{expectedMethodName}', but it did not");

            return true;

        }).Catch<Exception>((ex, r) => {
            throw ex; // re-throw for test runner
        }).Result;

        #endregion AddError(message)


        #region AddErrorsAndReturnDefault

        [Fact]
        public void AddErrorsAndReturnDefault_When_Destination_HasErrors_Appends_SourceErrors_And_Returns_DefaultForType()
        {
            // Arrange
            var destinationErrorMessage = "destination error message";
            var sourceErrorMessage      = "source error message";
            var destinationResult       = new Result<int>(destinationErrorMessage);

            // Act
            var result = destinationResult.AddErrorsAndReturnDefault(new Result<string>(sourceErrorMessage));

            // Assert
            result.ShouldBe(0);
            destinationResult.Errors.Count.ShouldBe(2);
            destinationResult.Errors.ShouldContain(e => e.Message == destinationErrorMessage);
            destinationResult.Errors.ShouldContain(e => e.Message == sourceErrorMessage);
        }

        [Fact]
        public void AddErrorsAndReturnDefault_When_Source_Null_DoesNotModify_Destination_And_Returns_DefaultForType()
        {
            // Arrange
            var destinationErrorMessage = "destination error message";
            var destinationResult       = new Result<int>(destinationErrorMessage);

            // Act
            var result = destinationResult.AddErrorsAndReturnDefault((IResult<string>)null);

            // Assert
            result.ShouldBe(0);
            destinationResult.Errors.Count.ShouldBe(1);
            destinationResult.Errors.ShouldContain(e => e.Message == destinationErrorMessage);
        }

        [Fact]
        public void AddErrorsAndReturnDefault_When_Source_DoesNotHaveErrors_DoesNotModify_Destination_And_Returns_DefaultForType()
        {
            // Arrange
            var destinationErrorMessage = "destination error message";
            var destinationResult       = new Result<int>(destinationErrorMessage);

            // Act
            var result = destinationResult.AddErrorsAndReturnDefault(new Result<string>());

            // Assert
            result.ShouldBe(0);
            destinationResult.Errors.Count.ShouldBe(1);
            destinationResult.Errors.ShouldContain(e => e.Message == destinationErrorMessage);
        }

        #endregion AddErrorsAndReturnDefault


        #region AddNextLinkParam (string, int)

        [Fact]
        public void AddNextLinkParam_ValueAsInt_Overload_When_Result_IsNull_Return_Null()
        {
            IResultExtensions                                                                      // Arrange
                .AddNextLinkParam<object>(result: null, key: Random.String(), value: Random.Int()) // Act
                    .ShouldBeNull();                                                               // Assert
        }

        [Fact]
        public void AddNextLinkParam_ValueAsInt_Overload_When_Result_NextLinkParams_IsNull_Returns_Dictionary()
        {
            new Result<object> { NextLinkParams = null }                     // Arrange
                .AddNextLinkParam(key: Random.String(), value: Random.Int()) // Act
                    .ShouldNotBeNull();                                      // Assert
        }

        [Fact]
        public void AddNextLinkParam_ValueAsInt_Overload_When_Result_NextLinkParams_IsNull_Returns_Reference_To_NextLinkParams()
        {
            // Arrange
            var destinationResult = new Result<object> { NextLinkParams = null };

            // Act
            var result = destinationResult.AddNextLinkParam(key: Random.String(), value: Random.Int());

            // Assert
            result.ShouldBe(destinationResult.NextLinkParams, "Expected to return reference to underlying 'NextLinkParams' property, but did not");
        }

        [Fact]
        public void AddNextLinkParam_ValueAsInt_Overload_When_Given_Key_IsNull_Throws_ArgumentNullException()
        {
            // Arrange
            var destinationResult = new Result<object>();

            // Act
            var result = Record.Exception(() => destinationResult.AddNextLinkParam(key: null, value: Random.Int()));

            // Assert
            result.ShouldBeOfType(typeof(ArgumentNullException));
        }

        [Fact]
        public void AddNextLinkParam_ValueAsInt_Overload_When_Given_Value_IsNull_Returns_Dictionary_With_Entry()
        {
            // Arrange
            var destinationResult = new Result<object>();
            var expectedKey       = Random.String();

            // Act
            var result = destinationResult.AddNextLinkParam(key: expectedKey, value: null);

            // Assert
            result.ShouldContainKeyAndValue(expectedKey, null);
        }

        [Fact]
        public void AddNextLinkParam_ValueAsInt_Overload_When_Given_Value_IsInt_Returns_Dictionary_With_Entry_Converted_To_String()
        {
            // Arrange
            var destinationResult = new Result<object>();
            var expectedKey       = Random.String();
            var expectedValue     = Random.Int();

            // Act
            var result = destinationResult.AddNextLinkParam(key: expectedKey, value: expectedValue);

            // Assert
            result.ShouldContainKeyAndValue(expectedKey, expectedValue.ToString());
        }

        #endregion AddNextLinkParam (string, int)


        #region AddNextLinkParam (string, string)

        [Fact]
        public void AddNextLinkParam_When_Result_IsNull_Return_Null()
        {
            IResultExtensions                                                                         // Arrange
                .AddNextLinkParam<object>(result: null, key: Random.String(), value: Random.String()) // Act
                    .ShouldBeNull();                                                                  // Assert
        }

        [Fact]
        public void AddNextLinkParam_When_Result_NextLinkParams_IsNull_Returns_Dictionary()
        {
            new Result<object> { NextLinkParams = null }                        // Arrange
                .AddNextLinkParam(key: Random.String(), value: Random.String()) // Act
                    .ShouldNotBeNull();                                         // Assert
        }

        [Fact]
        public void AddNextLinkParam_When_Result_NextLinkParams_IsNull_Returns_Reference_To_NextLinkParams()
        {
            // Arrange
            var destinationResult = new Result<object> { NextLinkParams = null };

            // Act
            var result = destinationResult.AddNextLinkParam(key: Random.String(), value: Random.String());

            // Assert
            result.ShouldBe(destinationResult.NextLinkParams, "Expected to return reference to underlying 'NextLinkParams' property, but did not");
        }

        [Fact]
        public void AddNextLinkParam_When_Given_Key_IsNull_Throws_ArgumentNullException()
        {
            // Arrange
            var destinationResult = new Result<object>();

            // Act
            var result = Record.Exception(() => destinationResult.AddNextLinkParam(key: null, value: Random.String()));

            // Assert
            result.ShouldBeOfType(typeof(ArgumentNullException));
        }

        [Fact]
        public void AddNextLinkParam_When_Given_Value_IsNull_Returns_Dictionary_With_Entry()
        {
            // Arrange
            var destinationResult = new Result<object>();
            var key               = Random.String();

            // Act
            var result = destinationResult.AddNextLinkParam(key: key, value: null);

            // Assert
            result.ShouldContainKeyAndValue(key, null);
        }

        #endregion AddNextLinkParam (string, string)


        #region AddNextLinkParams

        [Fact]
        public void AddNextLinkParams_When_DestinationResult_IsNull_Returns_Null()
        {
            IResultExtensions                                                           // Arrange
                .AddNextLinkParams<object>(destinationResult: null, sourceResult: null) // Act
                    .ShouldBeNull();                                                    // Assert
        }

        [Fact]
        public void AddNextLinkParams_When_DestinationResult_NextLinkParams_IsNull_Given_SourceResult_IsNull_Returns_Null()
        {
            // Arrange
            var destinationResult = new Result<object> { NextLinkParams = null }; // <----------- destination null

            // Act
            var result = destinationResult.AddNextLinkParams(sourceResult: null);

            // Assert
            result.ShouldBeNull();
        }

        [Fact]
        public void AddNextLinkParams_When_DestinationResult_NextLinkParams_IsNull_Given_SourceResult_NextListParams_IsNull_Returns_Null()
        {
            // Arrange
            var destinationResult = new Result<object> { NextLinkParams = null }; // <------------ destination null
            var sourceResult      = new Result<object> { NextLinkParams = null }; // <------------ source null

            // Act
            var result = destinationResult.AddNextLinkParams(sourceResult: sourceResult);

            // Assert
            result.ShouldBeNull();
        }

        [Fact]
        public void AddNextLinkParams_When_DestinationResult_NextLinkParams_IsNull_Given_SourceResult_NextListParams_IsNotEmpty_Returns_Dictionary()
        {
            // Arrange
            var destinationResult = new Result<object> { NextLinkParams = null }; // <----------- destination null

            var sourceResult = new Result<object>();
            sourceResult.AddNextLinkParam(Random.String(), Random.String());

            // Act
            var result = destinationResult.AddNextLinkParams(sourceResult: sourceResult);

            // Assert
            result.ShouldBeOfType(typeof(Dictionary<string, string>));
        }

        [Fact]
        public void AddNextLinkParams_When_DestinationResult_NextLinkParams_IsNull_Given_SourceResult_NextListParams_IsNotEmpty_Returns_Dictionary_With_SourceEntry()
        {
            // Arrange
            var destinationResult = new Result<object> { NextLinkParams = null }; // <----------- destination null
            var sourceTestKey     = Random.String();
            var sourceTestValue   = Random.String();
            var sourceResult      = new Result<object>();
            sourceResult.AddNextLinkParam(sourceTestKey, sourceTestValue);

            // Act
            var result = destinationResult.AddNextLinkParams(sourceResult: sourceResult);

            // Assert
            result.ShouldContainKeyAndValue(sourceTestKey, sourceTestValue);
        }

        [Fact]
        public void AddNextLinkParams_When_DestinationResult_NextLinkParams_HasEntries_Given_SourceResult_NextListParams_HasEntries_Returns_Dictionary_From_DestinationResult()
        {
            // Arrange
            var destinationResult = new Result<object>();
            destinationResult.AddNextLinkParam("testKeyFromDestination", "testValueFromDestination");

            var sourceResult = new Result<object>();
            sourceResult.AddNextLinkParam("testKeyFromSource", "testValueFromSource");

            // Act
            var result = destinationResult.AddNextLinkParams(sourceResult: sourceResult);

            // Assert
            result.ShouldBe(destinationResult.NextLinkParams);
        }

        [Fact]
        public void AddNextLinkParams_When_DestinationResult_NextLinkParams_HasEntries_Given_SourceResult_NextListParams_HasEntries_Returns_Dictionary_With_BothEntries()
        {
            // Arrange
            var destinationTestKey   = "testKeyFromDestination";
            var destinationTestValue = "testValueFromDestination";
            var destinationResult    = new Result<object>();
            destinationResult.AddNextLinkParam(destinationTestKey, destinationTestValue);

            var sourceTestKey   = "testKeyFromSource";
            var sourceTestValue = "testValueFromSource";
            var sourceResult    = new Result<object>();
            sourceResult.AddNextLinkParam(sourceTestKey, sourceTestValue);

            // Act
            var result = destinationResult.AddNextLinkParams(sourceResult: sourceResult);

            // Assert
            result.ShouldContainKeyAndValue(destinationTestKey, destinationTestValue);
            result.ShouldContainKeyAndValue(sourceTestKey,      sourceTestValue);
        }

        #endregion AddNextLinkParams


        #region HasErrors

            #region HasErrors (IEnumerable<IResult<T>>)

            [Fact]
            public void HasErrors_EnumerableList_When_List_IsNull_Returns_False()
            {
                IResultExtensions.HasErrors<bool>(resultList: null).ShouldBeFalse();
            }

            [Fact]
            public void HasErrors_EnumerableList_When_List_IsEmpty_Returns_False()
            {
                new List<IResult<bool>>().HasErrors().ShouldBeFalse();
            }

            [Fact]
            public void HasErrors_EnumerableList_When_List_Without_Errors_Returns_False()
            {
                new List<IResult<bool>> { new Result<bool>() } // Arrange
                    .HasErrors()                               // Act
                        .ShouldBeFalse();                      // Assert
            }

            [Fact]
            public void HasErrors_EnumerableList_When_List_With_Errors_Returns_True()
            {
                new List<IResult<bool>> { new Result<bool>("errorkey", "errormessage") } // Arrange
                    .HasErrors()                                                         // Act
                        .ShouldBeTrue();                                                 // Assert
            }

            #endregion HasErrors (no arguments)

            #region HasErrors (IEnumerable<IResult<T>>, ErrorType)

            [Fact]
            public void HasErrors_EnumerableList_And_ErrorType_Overload_When_List_IsNull_Returns_False()
            {
                IResultExtensions.HasErrors<bool>(resultList: null, errorType: ErrorType.Error).ShouldBeFalse();
            }

            [Fact]
            public void HasErrors_EnumerableList_And_ErrorType_Overload_When_List_IsEmpty_Returns_False()
            {
                new List<IResult<bool>>().HasErrors(ErrorType.Error).ShouldBeFalse();
            }

            [Fact]
            public void HasErrors_EnumerableList_And_ErrorType_Overload_When_List_Without_Errors_Returns_False()
            {
                new List<IResult<bool>> { new Result<bool>() } // Arrange
                    .HasErrors(ErrorType.Error)                // Act
                        .ShouldBeFalse();                      // Assert
            }

            [Fact]
            public void HasErrors_EnumerableList_And_ErrorType_Overload_When_List_With_Errors_Returns_True()
            {
                new List<IResult<bool>> { new Result<bool>("errorkey", "errormessage") } // Arrange
                    .HasErrors(ErrorType.Error)                                          // Act
                        .ShouldBeTrue();                                                 // Assert
            }

            #endregion HasErrors (IEnumerable<IResult<T>>, ErrorType)


            #region HasErrors (IEnumerable<IResult<T>>, string)

            [Fact]
            public void HasErrors_EnumerableList_And_ErrorKey_Overload_When_List_IsNull_Returns_False()
            {
                IResultExtensions.HasErrors<bool>(resultList: null, key: Random.String()).ShouldBeFalse();
            }

            [Fact]
            public void HasErrors_EnumerableList_And_ErrorKey_Overload_When_List_IsEmpty_Returns_False()
            {
                new List<IResult<bool>>().HasErrors(key: Random.String()).ShouldBeFalse();
            }

            [Fact]
            public void HasErrors_EnumerableList_And_ErrorKey_Overload_When_List_Without_Errors_Returns_False()
            {
                new List<IResult<bool>> { new Result<bool>() } // Arrange
                    .HasErrors(key: Random.String())           // Act
                        .ShouldBeFalse();                      // Assert
            }

            [Fact]
            public void HasErrors_EnumerableList_And_ErrorKey_Overload_When_List_With_Errors_When_Key_DoesNotMatch_Returns_False()
            {
                new List<IResult<bool>> { new Result<bool>("errorkey", "errormessage") } // Arrange
                    .HasErrors(key: "404")                                               // Act
                        .ShouldBeFalse();                                                // Assert
            }

            [Fact]
            public void HasErrors_EnumerableList_And_ErrorKey_Overload_When_List_With_Errors_When_Key_Matches_Returns_True()
            {
                new List<IResult<bool>> { new Result<bool>("errorkey", "errormessage") } // Arrange
                    .HasErrors(key: "errorkey")                                          // Act
                        .ShouldBeTrue();                                                 // Assert
            }

            #endregion HasErrors (IEnumerable<IResult<T>>, string)

        #endregion HasErrors


        #region ListErrors

            #region ListErrors (IEnumerable<IResult<T>>, string)

            [Fact]
            public void ListErrors_When_List_IsNull_Returns_Null()
            {
                IResultExtensions.ListErrors<bool>(resultList: null).ShouldBeNull();
            }

            [Fact]
            public void ListErrors_When_List_IsEmpty_Returns_Null()
            {
                new List<IResult<bool>>().ListErrors().ShouldBeNull();
            }

            [Fact]
            public void ListErrors_When_List_DoesNot_HaveErrors_Returns_Null()
            {
                new List<IResult<bool>> { new Result<bool>() } // Arrange
                    .ListErrors()                              // Act
                        .ShouldBeNull();                       // Assert
            }

            [Fact]
            public void ListErrors_When_List_Has_OneError_Returns_Error_Key_And_Message()
            {
                // Arrange
                var sut = new List<IResult<bool>> { new Result<bool>("testkey", "testmessage") };

                // Act
                var result = sut.ListErrors();

                // Assert
                result.ShouldNotBeEmpty();
                result.ShouldContain("testkey");
                result.ShouldContain("testmessage");
            }

            [Fact]
            public void ListErrors_When_List_Has_MultipleErrors_Returns_Error_Keys_And_Messages()
            {
                // Arrange
                var sut = new List<IResult<bool>>
                {
                    new Result<bool>("testkey1", "testmessage1"),
                    new Result<bool>("testkey2", "testmessage2")
                };

                // Act
                var result = sut.ListErrors();

                // Assert
                result.ShouldNotBeEmpty();
                result.ShouldContain("testkey1");
                result.ShouldContain("testmessage1");
                result.ShouldContain("testkey2");
                result.ShouldContain("testmessage2");
            }

            [Fact]
            public void ListErrors_When_List_Has_MultipleErrors_Given_CustomDelimiter_Returns_Error_Keys_And_Messages_With_Delimiter()
            {
                // Arrange
                var sut = new List<IResult<bool>>
                {
                    new Result<bool>("testkey1", "testmessage1"),
                    new Result<bool>("testkey2", "testmessage2")
                };

                // Act
                var result = sut.ListErrors(delimiter: "delimiter");

                // Assert
                result.ShouldNotBeEmpty();
                result.ShouldContain("testkey1");
                result.ShouldContain("testmessage1");
                result.ShouldContain("testkey2");
                result.ShouldContain("testmessage2");
                result.ShouldContain("delimiter");
            }

            #endregion ListErrors (IEnumerable<IResult<T>>, string)

        #endregion ListErrors


        #region ThrowIfAnyErrorsOrResultIsNull

        [Fact]
        public void ThrowIfAnyErrorsOrResultIsNull_Result_Has_Errors_Throws_Exception()
        {
            var result = new Result<bool?>
            {
                Errors = new List<IError>
                {
                    new Error
                    {
                        Message = "This is a test error!"
                    }
                },
                ResultObject = false
            };
            var thrown = false;

            try
            {
                result.ThrowIfAnyErrorsOrResultIsNull();
            }
            catch (Exception e)
            {
                e.ShouldNotBeNull();
                e.Message.ShouldContain("This is a test error!");
                thrown = true;
            }
            finally
            {
                result.ShouldHaveErrors();
                result.ResultObject.ShouldNotBeNull();
                thrown.ShouldBeTrue();
            }
        }

        [Fact]
        public void ThrowIfAnyErrorsOrResultIsNull_Result_Has_NullResult_And_NoErrors_Throws_Exception()
        {
            var result = new Result<bool?>
            {
                Errors = null,
                ResultObject = null
            };
            var thrown = false;

            try
            {
                result.ThrowIfAnyErrorsOrResultIsNull();
            }
            catch (Exception e)
            {
                e.ShouldNotBeNull();
                e.Message.ShouldContain($"Result object for IResult returning {typeof(bool?).Name} is null!");
                thrown = true;
            }
            finally
            {
                result.ShouldNotHaveErrors();
                result.ResultObject.ShouldBeNull();
                thrown.ShouldBeTrue();
            }
        }

        [Fact]
        public void ThrowIfAnyErrorsOrResultIsNull_Result_IsNotNull_And_DoesNotHaveErrors_DoesNotThrowException()
        {
            var result = new Result<bool?>
            {
                Errors = null,
                ResultObject = true
            };

            result.ThrowIfAnyErrorsOrResultIsNull();

            result.ShouldNotHaveErrors();
            result.ResultObject.ShouldNotBeNull();
        }

        #endregion ThrowIfAnyErrorsOrResultIsNull
    }
}
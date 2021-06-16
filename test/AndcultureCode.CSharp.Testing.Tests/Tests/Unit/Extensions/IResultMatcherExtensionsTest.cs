using Shouldly;
using Xunit;
using Xunit.Abstractions;
using AndcultureCode.CSharp.Testing.Extensions;
using AndcultureCode.CSharp.Testing.Constants;
using System.Collections.Generic;
using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Testing.Factories;
using AndcultureCode.CSharp.Core.Models.Errors;
using AndcultureCode.CSharp.Core.Interfaces.Entity;
using AndcultureCode.CSharp.Testing.Models.Stubs;
using System.Linq;

namespace AndcultureCode.CSharp.Testing.Tests.Unit.Extensions
{
    public class IResultMatcherExtensionsTest : ProjectUnitTest
    {
        #region Setup

        public IResultMatcherExtensionsTest(ITestOutputHelper output) : base(output)
        {

        }

        #endregion Setup

        #region ShouldBeCreated

        [Fact]
        public void ShouldBeCreated_When_Result_Null_Fails_Assertion()
        {
            // Arrange
            IResult<ICreatable> result = null;

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldBeCreated());
        }

        [Fact]
        public void ShouldBeCreated_When_ResultObject_Null_Fails_Assertion()
        {
            // Arrange
            var result = BuildResult<UserStub>((e) => e.ResultObject = null);

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldBeCreated());
        }

        [Fact]
        public void ShouldBeCreated_When_CreatedOn_Null_Fails_Assertion()
        {
            // Arrange
            var result = BuildResult<UserStub>((e) => e.CreatedOn = null);

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldBeCreated());
        }

        [Fact]
        public void ShouldBeCreated_When_CreatedOn_HasValue_Passes_Assertion()
        {
            // Arrange
            var result = BuildResult<UserStub>((e) => e.CreatedOn = Faker.Date.RecentOffset());

            // Act & Assert
            Should.NotThrow(() => result.ShouldBeCreated());
        }

        #endregion ShouldBeCreated

        #region ShouldBeCreatedBy(long createdById)

        [Fact]
        public void ShouldBeCreatedBy_CreatedById_When_Result_Null_Fails_Assertion()
        {
            // Arrange
            IResult<ICreatable> result = null;

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldBeCreatedBy(createdById: Random.Long()));
        }

        [Fact]
        public void ShouldBeCreatedBy_CreatedById_When_ResultObject_Null_Fails_Assertion()
        {
            // Arrange
            var result = BuildResult<UserStub>((e) => e.ResultObject = null);

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldBeCreatedBy(createdById: Random.Long()));
        }

        [Fact]
        public void ShouldBeCreatedBy_CreatedById_When_CreatedById_Null_Fails_Assertion()
        {
            // Arrange
            var result = BuildResult<UserStub>((e) => e.CreatedById = null);

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldBeCreatedBy(createdById: Random.Long()));
        }

        [Fact]
        public void ShouldBeCreatedBy_CreatedById_When_CreatedById_Does_Not_Match_Fails_Assertion()
        {
            // Arrange
            var createdById = Random.Long(min: 1, max: 100);
            var unexpected = createdById + 1;
            var result = BuildResult<UserStub>((e) => e.CreatedById = createdById);

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldBeCreatedBy(createdById: unexpected));
        }

        [Fact]
        public void ShouldBeCreatedBy_CreatedById_When_CreatedById_Matches_Passes_Assertion()
        {
            // Arrange
            var expected = Random.Long();
            var result = BuildResult<UserStub>((e) => e.CreatedById = expected);

            // Act & Assert
            Should.NotThrow(() => result.ShouldBeCreatedBy(createdById: expected));
        }

        #endregion ShouldBeCreatedBy(long createdById)

        #region ShouldBeCreatedBy(IEntity createdBy)

        [Fact]
        public void ShouldBeCreatedBy_CreatedBy_When_Result_Null_Fails_Assertion()
        {
            // Arrange
            IResult<ICreatable> result = null;

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldBeCreatedBy(createdBy: Build<UserStub>()));
        }

        [Fact]
        public void ShouldBeCreatedBy_CreatedBy_When_ResultObject_Null_Fails_Assertion()
        {
            // Arrange
            var result = BuildResult<UserStub>((e) => e.ResultObject = null);

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldBeCreatedBy(createdBy: Build<UserStub>()));
        }

        [Fact]
        public void ShouldBeCreatedBy_CreatedBy_When_CreatedById_Null_Fails_Assertion()
        {
            // Arrange
            var unexpected = Build<UserStub>((e) => e.CreatedById = Random.Long());
            var result = BuildResult<UserStub>((e) => e.CreatedById = null);

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldBeCreatedBy(createdBy: unexpected));
        }

        [Fact]
        public void ShouldBeCreatedBy_CreatedBy_When_CreatedById_Does_Not_Match_Fails_Assertion()
        {
            // Arrange
            var unexpected = Build<UserStub>((e) => e.CreatedById = Random.Long(min: 1, max: 100));
            var result = BuildResult<UserStub>((e) => e.CreatedById = unexpected.Id + 1);

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldBeCreatedBy(createdBy: unexpected));
        }

        [Fact]
        public void ShouldBeCreatedBy_CreatedBy_When_CreatedById_Matches_Passes_Assertion()
        {
            // Arrange
            var expected = Build<UserStub>((e) => e.CreatedById = Random.Long());
            var result = BuildResult<UserStub>((e) => e.CreatedById = expected.Id);

            // Act & Assert
            Should.NotThrow(() => result.ShouldBeCreatedBy(createdBy: expected));
        }

        #endregion ShouldBeCreatedBy(IEntity createdBy)

        #region ShouldBeDeleted

        [Fact]
        public void ShouldBeDeleted_When_Result_Null_Fails_Assertion()
        {
            // Arrange
            IResult<IDeletable> result = null;

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldBeDeleted());
        }

        [Fact]
        public void ShouldBeDeleted_When_ResultObject_Null_Fails_Assertion()
        {
            // Arrange
            var result = BuildResult<UserStub>((e) => e.ResultObject = null);

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldBeDeleted());
        }

        [Fact]
        public void ShouldBeDeleted_When_DeletedOn_Null_Fails_Assertion()
        {
            // Arrange
            var result = BuildResult<UserStub>((e) => e.DeletedOn = null);

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldBeDeleted());
        }

        [Fact]
        public void ShouldBeDeleted_When_DeletedOn_HasValue_Passes_Assertion()
        {
            // Arrange
            var result = BuildResult<UserStub>((e) => e.DeletedOn = Faker.Date.RecentOffset());

            // Act & Assert
            Should.NotThrow(() => result.ShouldBeDeleted());
        }

        #endregion ShouldBeDeleted

        #region ShouldBeDeletedBy(long deletedById)

        [Fact]
        public void ShouldBeDeletedBy_DeletedById_When_Result_Null_Fails_Assertion()
        {
            // Arrange
            IResult<IDeletable> result = null;

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldBeDeletedBy(deletedById: Random.Long()));
        }

        [Fact]
        public void ShouldBeDeletedBy_DeletedById_When_ResultObject_Null_Fails_Assertion()
        {
            // Arrange
            var result = BuildResult<UserStub>((e) => e.ResultObject = null);

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldBeDeletedBy(deletedById: Random.Long()));
        }

        [Fact]
        public void ShouldBeDeletedBy_DeletedById_When_DeletedById_Null_Fails_Assertion()
        {
            // Arrange
            var result = BuildResult<UserStub>((e) => e.DeletedById = null);

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldBeDeletedBy(deletedById: Random.Long()));
        }

        [Fact]
        public void ShouldBeDeletedBy_DeletedById_When_DeletedById_Does_Not_Match_Fails_Assertion()
        {
            // Arrange
            var deletedById = Random.Long(min: 1, max: 100);
            var unexpected = deletedById + 1;
            var result = BuildResult<UserStub>((e) => e.DeletedById = deletedById);

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldBeDeletedBy(deletedById: unexpected));
        }

        [Fact]
        public void ShouldBeDeletedBy_DeletedById_When_DeletedById_Matches_Passes_Assertion()
        {
            // Arrange
            var expected = Random.Long();
            var result = BuildResult<UserStub>((e) => e.DeletedById = expected);

            // Act & Assert
            Should.NotThrow(() => result.ShouldBeDeletedBy(deletedById: expected));
        }

        #endregion ShouldBeDeletedBy(long deletedById)

        #region ShouldBeDeletedBy(IEntity deletedBy)

        [Fact]
        public void ShouldBeDeletedBy_DeletedBy_When_Result_Null_Fails_Assertion()
        {
            // Arrange
            IResult<IDeletable> result = null;

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldBeDeletedBy(deletedBy: Build<UserStub>()));
        }

        [Fact]
        public void ShouldBeDeletedBy_DeletedBy_When_ResultObject_Null_Fails_Assertion()
        {
            // Arrange
            var result = BuildResult<UserStub>((e) => e.ResultObject = null);

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldBeDeletedBy(deletedBy: Build<UserStub>()));
        }

        [Fact]
        public void ShouldBeDeletedBy_DeletedBy_When_DeletedById_Null_Fails_Assertion()
        {
            // Arrange
            var unexpected = Build<UserStub>((e) => e.DeletedById = Random.Long());
            var result = BuildResult<UserStub>((e) => e.DeletedById = null);

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldBeDeletedBy(deletedBy: unexpected));
        }

        [Fact]
        public void ShouldBeDeletedBy_DeletedBy_When_DeletedById_Does_Not_Match_Fails_Assertion()
        {
            // Arrange
            var unexpected = Build<UserStub>((e) => e.DeletedById = Random.Long(min: 1, max: 100));
            var result = BuildResult<UserStub>((e) => e.DeletedById = unexpected.Id + 1);

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldBeDeletedBy(deletedBy: unexpected));
        }

        [Fact]
        public void ShouldBeDeletedBy_DeletedBy_When_DeletedById_Matches_Passes_Assertion()
        {
            // Arrange
            var expected = Build<UserStub>((e) => e.DeletedById = Random.Long());
            var result = BuildResult<UserStub>((e) => e.DeletedById = expected.Id);

            // Act & Assert
            Should.NotThrow(() => result.ShouldBeDeletedBy(deletedBy: expected));
        }

        #endregion ShouldBeDeletedBy(IEntity deletedBy)

        #region ShouldBeUpdated

        [Fact]
        public void ShouldBeUpdated_When_Result_Null_Fails_Assertion()
        {
            // Arrange
            IResult<IUpdatable> result = null;

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldBeUpdated());
        }

        [Fact]
        public void ShouldBeUpdated_When_ResultObject_Null_Fails_Assertion()
        {
            // Arrange
            var result = BuildResult<UserStub>((e) => e.ResultObject = null);

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldBeUpdated());
        }

        [Fact]
        public void ShouldBeUpdated_When_UpdatedOn_Null_Fails_Assertion()
        {
            // Arrange
            var result = BuildResult<UserStub>((e) => e.UpdatedOn = null);

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldBeUpdated());
        }

        [Fact]
        public void ShouldBeUpdated_When_UpdatedOn_HasValue_Passes_Assertion()
        {
            // Arrange
            var result = BuildResult<UserStub>((e) => e.UpdatedOn = Faker.Date.RecentOffset());

            // Act & Assert
            Should.NotThrow(() => result.ShouldBeUpdated());
        }

        #endregion ShouldBeUpdated

        #region ShouldBeUpdatedBy(long updatedById)

        [Fact]
        public void ShouldBeUpdatedBy_UpdatedById_When_Result_Null_Fails_Assertion()
        {
            // Arrange
            IResult<IUpdatable> result = null;

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldBeUpdatedBy(updatedById: Random.Long()));
        }

        [Fact]
        public void ShouldBeUpdatedBy_UpdatedById_When_ResultObject_Null_Fails_Assertion()
        {
            // Arrange
            var result = BuildResult<UserStub>((e) => e.ResultObject = null);

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldBeUpdatedBy(updatedById: Random.Long()));
        }

        [Fact]
        public void ShouldBeUpdatedBy_UpdatedById_When_UpdatedById_Null_Fails_Assertion()
        {
            // Arrange
            var result = BuildResult<UserStub>((e) => e.UpdatedById = null);

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldBeUpdatedBy(updatedById: Random.Long()));
        }

        [Fact]
        public void ShouldBeUpdatedBy_UpdatedById_When_UpdatedById_Does_Not_Match_Fails_Assertion()
        {
            // Arrange
            var updatedById = Random.Long(min: 1, max: 100);
            var unexpected = updatedById + 1;
            var result = BuildResult<UserStub>((e) => e.UpdatedById = updatedById);

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldBeUpdatedBy(updatedById: unexpected));
        }

        [Fact]
        public void ShouldBeUpdatedBy_UpdatedById_When_UpdatedById_Matches_Passes_Assertion()
        {
            // Arrange
            var expected = Random.Long();
            var result = BuildResult<UserStub>((e) => e.UpdatedById = expected);

            // Act & Assert
            Should.NotThrow(() => result.ShouldBeUpdatedBy(updatedById: expected));
        }

        #endregion ShouldBeUpdatedBy(long updatedById)

        #region ShouldBeUpdatedBy(IEntity updatedBy)

        [Fact]
        public void ShouldBeUpdatedBy_UpdatedBy_When_Result_Null_Fails_Assertion()
        {
            // Arrange
            IResult<IUpdatable> result = null;

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldBeUpdatedBy(updatedBy: Build<UserStub>()));
        }

        [Fact]
        public void ShouldBeUpdatedBy_UpdatedBy_When_ResultObject_Null_Fails_Assertion()
        {
            // Arrange
            var result = BuildResult<UserStub>((e) => e.ResultObject = null);

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldBeUpdatedBy(updatedBy: Build<UserStub>()));
        }

        [Fact]
        public void ShouldBeUpdatedBy_UpdatedBy_When_UpdatedById_Null_Fails_Assertion()
        {
            // Arrange
            var unexpected = Build<UserStub>((e) => e.UpdatedById = Random.Long());
            var result = BuildResult<UserStub>((e) => e.UpdatedById = null);

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldBeUpdatedBy(updatedBy: unexpected));
        }

        [Fact]
        public void ShouldBeUpdatedBy_UpdatedBy_When_UpdatedById_Does_Not_Match_Fails_Assertion()
        {
            // Arrange
            var unexpected = Build<UserStub>((e) => e.UpdatedById = Random.Long(min: 1, max: 100));
            var result = BuildResult<UserStub>((e) => e.UpdatedById = unexpected.Id + 1);

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldBeUpdatedBy(updatedBy: unexpected));
        }

        [Fact]
        public void ShouldBeUpdatedBy_UpdatedBy_When_UpdatedById_Matches_Passes_Assertion()
        {
            // Arrange
            var expected = Build<UserStub>((e) => e.UpdatedById = Random.Long());
            var result = BuildResult<UserStub>((e) => e.UpdatedById = expected.Id);

            // Act & Assert
            Should.NotThrow(() => result.ShouldBeUpdatedBy(updatedBy: expected));
        }

        #endregion ShouldBeUpdatedBy(IEntity updatedBy)

        #region ShouldHaveBasicError

        [Fact]
        public void ShouldHaveBasicError_When_Errors_Null_Fails_Assertion()
        {
            // Arrange
            var result = BuildResult<object>((e) => e.Errors = null);

            // Act
            var ex = Record.Exception(() => result.ShouldHaveBasicError());

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
            Should.Throw<ShouldAssertException>(() => result.ShouldHaveBasicError());
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
            Should.Throw<ShouldAssertException>(() => result.ShouldHaveBasicError());
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
            Should.NotThrow(() => result.ShouldHaveBasicError());
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
            Should.Throw<ShouldAssertException>(() => result.ShouldHaveErrors());
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
            Should.NotThrow(() => result.ShouldHaveErrors());
        }

        #endregion ShouldHaveErrors<T>

        #region ShouldHaveErrors<bool>

        [Fact]
        public void ShouldHaveErrors_Bool_When_Errors_Null_Fails_Assertion()
        {
            // Arrange
            var result = BuildResult<bool>((e) => e.Errors = null);

            // Act
            var ex = Record.Exception(() => result.ShouldHaveErrors());

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
            Should.Throw<ShouldAssertException>(() => result.ShouldHaveErrors());
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
            Should.Throw<ShouldAssertException>(() => result.ShouldHaveErrors());
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
            Should.NotThrow(() => result.ShouldHaveErrors());
        }

        #endregion ShouldHaveErrors<bool>

        #region ShouldHaveErrorsFor

        [Fact]
        public void ShouldHaveErrorsFor_When_Errors_Null_Fails_Assertion()
        {
            // Arrange
            var result = BuildResult<object>((e) => e.Errors = null);

            // Act
            var ex = Record.Exception(() => result.ShouldHaveErrorsFor(ErrorConstants.BASIC_ERROR_KEY));

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
            Should.Throw<ShouldAssertException>(() => result.ShouldHaveErrorsFor(ErrorConstants.BASIC_ERROR_KEY));
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
            Should.Throw<ShouldAssertException>(() => result.ShouldHaveErrorsFor($"not-{error.Key}"));
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

            // Act & Assert
            Should.NotThrow(() => result.ShouldHaveErrorsFor(error.Key));
        }

        #endregion ShouldHaveErrorsFor

        #region ShouldHaveResultObject

        [Fact]
        public void ShouldHaveResultObject_When_Result_Null_Fails_Assertion()
        {
            // Arrange
            IResult<object> result = null;

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldHaveResultObject());
        }

        [Fact]
        public void ShouldHaveResultObject_When_ResultObject_Null_Fails_Assertion()
        {
            // Arrange
            var result = BuildResult<object>((e) => e.ResultObject = null);

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldHaveResultObject());
        }

        [Fact]
        public void ShouldHaveResultObject_When_ResultObject_HasValue_Passes_Assertion()
        {
            // Arrange
            var result = BuildResult<UserStub>();

            // Act & Assert
            Should.NotThrow(() => result.ShouldHaveResultObject());
        }

        #endregion ShouldHaveResultObject

        #region ShouldHaveResultObjects

        [Fact]
        public void ShouldHaveResultObjects_When_Result_Null_Fails_Assertion()
        {
            // Arrange
            IResult<IEnumerable<object>> result = null;

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldHaveResultObjects());
        }

        [Fact]
        public void ShouldHaveResultObjects_When_ResultObject_Null_Fails_Assertion()
        {
            // Arrange
            var result = BuildResult<IEnumerable<object>>((e) => e.ResultObject = null);

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldHaveResultObjects());
        }

        [Fact]
        public void ShouldHaveResultObjects_When_ResultObject_Empty_Fails_Assertion()
        {
            // Arrange
            var result = BuildResult<IEnumerable<UserStub>>((e) => e.ResultObject = new List<UserStub>());

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldHaveResultObjects());
        }

        [Fact]
        public void ShouldHaveResultObjects_When_ResultObject_HasValues_Given_Non_Matching_ExactCount_Fails_Assertion()
        {
            // Arrange
            var result = BuildResult<IEnumerable<UserStub>>((e) => e.ResultObject = BuildList<UserStub>(2));
            var unexpected = result.ResultObject.Count() + 1;

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldHaveResultObjects(exactCount: unexpected));
        }

        [Fact]
        public void ShouldHaveResultObjects_When_ResultObject_HasValues_Given_Matching_ExactCount_Passes_Assertion()
        {
            // Arrange
            var result = BuildResult<IEnumerable<UserStub>>((e) => e.ResultObject = BuildList<UserStub>(2));
            var expected = result.ResultObject.Count();

            // Act & Assert
            Should.NotThrow(() => result.ShouldHaveResultObjects(exactCount: expected));
        }

        [Fact]
        public void ShouldHaveResultObjects_When_ResultObject_Empty_Given_0_ExactCount_Passes_Assertion()
        {
            // Arrange
            var result = BuildResult<IEnumerable<UserStub>>((e) => e.ResultObject = new List<UserStub>());
            var expected = 0;

            // Act & Assert
            Should.NotThrow(() => result.ShouldHaveResultObjects(exactCount: expected));
        }

        [Fact]
        public void ShouldHaveResultObjects_When_ResultObject_HasValues_Passes_Assertion()
        {
            // Arrange
            var result = BuildResult<IEnumerable<UserStub>>((e) => e.ResultObject = BuildList<UserStub>(2));

            // Act & Assert
            Should.NotThrow(() => result.ShouldHaveResultObjects());
        }

        #endregion ShouldHaveResultObjects

        #region ShouldHaveResourceNotFoundError

        [Fact]
        public void ShouldHaveResourceNotFoundError_When_Errors_Null_Fails_Assertion()
        {
            // Arrange
            var result = BuildResult<object>((e) => e.Errors = null);

            // Act
            var ex = Record.Exception(() => result.ShouldHaveResourceNotFoundError());

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
            Should.Throw<ShouldAssertException>(() => result.ShouldHaveResourceNotFoundError());
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
            Should.Throw<ShouldAssertException>(() => result.ShouldHaveResourceNotFoundError());
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
            Should.NotThrow(() => result.ShouldHaveResourceNotFoundError());
        }

        #endregion ShouldHaveResourceNotFoundError
    }
}

using Shouldly;
using Xunit;
using Xunit.Abstractions;
using RSM.HCD.CSharp.Testing.Extensions;
using RSM.HCD.CSharp.Testing.Constants;
using System.Collections.Generic;
using RSM.HCD.CSharp.Core.Interfaces;
using RSM.HCD.CSharp.Testing.Factories;
using RSM.HCD.CSharp.Core.Models.Errors;
using RSM.HCD.CSharp.Core.Interfaces.Entity;
using RSM.HCD.CSharp.Testing.Models.Stubs;
using System.Linq;

namespace RSM.HCD.CSharp.Testing.Tests.Unit.Extensions
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
        public void ShouldBeCreatedBy_CreatedBy_When_Expected_Entity_Null_Fails_Assertion()
        {
            // Arrange
            var result = BuildResult<UserStub>();

            // Act
            var exception = Record.Exception(() => result.ShouldBeCreatedBy(createdBy: (IEntity)null));

            // Assert
            exception.ShouldNotBeNull();
            exception.Message.ShouldContain(ErrorConstants.ERROR_EXPECTED_ENTITY_IS_NULL_MESSAGE);
        }

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
        public void ShouldBeDeletedBy_DeletedBy_When_Expected_Entity_Null_Fails_Assertion()
        {
            // Arrange
            var result = BuildResult<UserStub>();

            // Act
            var exception = Record.Exception(() => result.ShouldBeDeletedBy(deletedBy: (IEntity)null));

            // Assert
            exception.ShouldNotBeNull();
            exception.Message.ShouldContain(ErrorConstants.ERROR_EXPECTED_ENTITY_IS_NULL_MESSAGE);
        }

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
        public void ShouldBeUpdatedBy_UpdatedBy_When_Expected_Entity_Null_Fails_Assertion()
        {
            // Arrange
            var result = BuildResult<UserStub>();

            // Act
            var exception = Record.Exception(() => result.ShouldBeUpdatedBy(updatedBy: (IEntity)null));

            // Assert
            exception.ShouldNotBeNull();
            exception.Message.ShouldContain(ErrorConstants.ERROR_EXPECTED_ENTITY_IS_NULL_MESSAGE);
        }

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
            var exception = Record.Exception(() => result.ShouldHaveBasicError());

            // Assert
            exception.ShouldNotBeNull();
            exception.Message.ShouldContain(ErrorConstants.ERROR_ERRORS_LIST_IS_NULL_MESSAGE);
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
            var exception = Record.Exception(() =>
            {
                result.ShouldHaveErrors();
            });

            // Assert
            exception.ShouldNotBeNull();
            exception.Message.ShouldContain(ErrorConstants.ERROR_ERRORS_LIST_IS_NULL_MESSAGE);
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
            var exception = Record.Exception(() => result.ShouldHaveErrors());

            // Assert
            exception.ShouldNotBeNull();
            exception.Message.ShouldContain(ErrorConstants.ERROR_ERRORS_LIST_IS_NULL_MESSAGE);
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
            var exception = Record.Exception(() => result.ShouldHaveErrorsFor(ErrorConstants.BASIC_ERROR_KEY));

            // Assert
            exception.ShouldNotBeNull();
            exception.Message.ShouldContain(ErrorConstants.ERROR_ERRORS_LIST_IS_NULL_MESSAGE);
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
        public void ShouldHaveResultObjects_When_ResultObject_Empty_Enumerable_Fails_Assertion()
        {
            // Arrange
            var result = BuildResult<IEnumerable<UserStub>>((e) => e.ResultObject = Enumerable.Empty<UserStub>());

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldHaveResultObjects());
        }

        [Fact]
        public void ShouldHaveResultObjects_When_ResultObject_Empty_Queryable_Fails_Assertion()
        {
            // Arrange
            var result = BuildResult<IQueryable<UserStub>>(
                (e) => e.ResultObject = Enumerable.Empty<UserStub>().AsQueryable()
            );

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldHaveResultObjects());
        }

        [Fact]
        public void ShouldHaveResultObjects_When_ResultObject_Empty_List_Fails_Assertion()
        {
            // Arrange
            var result = BuildResult<List<UserStub>>((e) => e.ResultObject = new List<UserStub>());

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
            var exception = Record.Exception(() => result.ShouldHaveResourceNotFoundError());

            // Assert
            exception.ShouldNotBeNull();
            exception.Message.ShouldContain(ErrorConstants.ERROR_ERRORS_LIST_IS_NULL_MESSAGE);
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

        #region ShouldNotBeCreated

        [Fact]
        public void ShouldNotBeCreated_When_Result_Null_Fails_Assertion()
        {
            // Arrange
            IResult<ICreatable> result = null;

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldNotBeCreated());
        }

        [Fact]
        public void ShouldNotBeCreated_When_CreatedOn_HasValue_Fails_Assertion()
        {
            // Arrange
            var result = BuildResult<UserStub>((e) => e.CreatedOn = Faker.Date.RecentOffset());

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldNotBeCreated());
        }

        [Fact]
        public void ShouldNotBeCreated_When_CreatedOn_Null_Passes_Assertion()
        {
            // Arrange
            var result = BuildResult<UserStub>((e) => e.CreatedOn = null);

            // Act & Assert
            Should.NotThrow(() => result.ShouldNotBeCreated());
        }

        #endregion ShouldNotBeCreated

        #region ShouldNotBeCreatedBy(long createdById)

        [Fact]
        public void ShouldNotBeCreatedBy_CreatedById_When_Result_Null_Fails_Assertion()
        {
            // Arrange
            IResult<ICreatable> result = null;

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldNotBeCreatedBy(createdById: Random.Long()));
        }

        [Fact]
        public void ShouldNotBeCreatedBy_CreatedById_When_CreatedById_Matches_Fails_Assertion()
        {
            // Arrange
            var expected = Random.Long();
            var result = BuildResult<UserStub>((e) => e.CreatedById = expected);

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldNotBeCreatedBy(createdById: expected));
        }

        [Fact]
        public void ShouldNotBeCreatedBy_CreatedById_When_CreatedById_Null_Passes_Assertion()
        {
            // Arrange
            var result = BuildResult<UserStub>((e) => e.CreatedById = null);

            // Act & Assert
            Should.NotThrow(() => result.ShouldNotBeCreatedBy(createdById: Random.Long()));
        }

        [Fact]
        public void ShouldNotBeCreatedBy_CreatedById_When_CreatedById_Does_Not_Match_Passes_Assertion()
        {
            // Arrange
            var createdById = Random.Long(min: 1, max: 100);
            var unexpected = createdById + 1;
            var result = BuildResult<UserStub>((e) => e.CreatedById = createdById);

            // Act & Assert
            Should.NotThrow(() => result.ShouldNotBeCreatedBy(createdById: unexpected));
        }

        #endregion ShouldNotBeCreatedBy(long createdById)

        #region ShouldNotBeCreatedBy(IEntity createdBy)

        [Fact]
        public void ShouldNotBeCreatedBy_CreatedBy_When_Expected_Entity_Null_Fails_Assertion()
        {
            // Arrange
            var result = BuildResult<UserStub>();

            // Act
            var exception = Record.Exception(() => result.ShouldNotBeCreatedBy(createdBy: (IEntity)null));

            // Assert
            exception.ShouldNotBeNull();
            exception.Message.ShouldContain(ErrorConstants.ERROR_EXPECTED_ENTITY_IS_NULL_MESSAGE);
        }

        [Fact]
        public void ShouldNotBeCreatedBy_CreatedBy_When_Result_Null_Fails_Assertion()
        {
            // Arrange
            IResult<ICreatable> result = null;

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldNotBeCreatedBy(createdBy: Build<UserStub>()));
        }

        [Fact]
        public void ShouldNotBeCreatedBy_CreatedBy_When_CreatedById_Matches_Fails_Assertion()
        {
            // Arrange
            var expected = Build<UserStub>((e) => e.CreatedById = Random.Long());
            var result = BuildResult<UserStub>((e) => e.CreatedById = expected.Id);

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldNotBeCreatedBy(createdBy: expected));
        }

        [Fact]
        public void ShouldNotBeCreatedBy_CreatedBy_When_CreatedById_Null_Passes_Assertion()
        {
            // Arrange
            var unexpected = Build<UserStub>((e) => e.CreatedById = Random.Long());
            var result = BuildResult<UserStub>((e) => e.CreatedById = null);

            // Act & Assert
            Should.NotThrow(() => result.ShouldNotBeCreatedBy(createdBy: unexpected));
        }

        [Fact]
        public void ShouldNotBeCreatedBy_CreatedBy_When_CreatedById_Does_Not_Match_Passes_Assertion()
        {
            // Arrange
            var unexpected = Build<UserStub>((e) => e.CreatedById = Random.Long(min: 1, max: 100));
            var result = BuildResult<UserStub>((e) => e.CreatedById = unexpected.Id + 1);

            // Act & Assert
            Should.NotThrow(() => result.ShouldNotBeCreatedBy(createdBy: unexpected));
        }

        #endregion ShouldNotBeCreatedBy(IEntity createdBy)

        #region ShouldNotBeDeleted

        [Fact]
        public void ShouldNotBeDeleted_When_Result_Null_Fails_Assertion()
        {
            // Arrange
            IResult<IDeletable> result = null;

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldNotBeDeleted());
        }

        [Fact]
        public void ShouldNotBeDeleted_When_DeletedOn_HasValue_Fails_Assertion()
        {
            // Arrange
            var result = BuildResult<UserStub>((e) => e.DeletedOn = Faker.Date.RecentOffset());

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldNotBeDeleted());
        }

        [Fact]
        public void ShouldNotBeDeleted_When_DeletedOn_Null_Passes_Assertion()
        {
            // Arrange
            var result = BuildResult<UserStub>((e) => e.DeletedOn = null);

            // Act & Assert
            Should.NotThrow(() => result.ShouldNotBeDeleted());
        }

        #endregion ShouldNotBeDeleted

        #region ShouldNotBeDeletedBy(long deletedById)

        [Fact]
        public void ShouldNotBeDeletedBy_DeletedById_When_Result_Null_Fails_Assertion()
        {
            // Arrange
            IResult<IDeletable> result = null;

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldNotBeDeletedBy(deletedById: Random.Long()));
        }

        [Fact]
        public void ShouldNotBeDeletedBy_DeletedById_When_DeletedById_Matches_Fails_Assertion()
        {
            // Arrange
            var expected = Random.Long();
            var result = BuildResult<UserStub>((e) => e.DeletedById = expected);

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldNotBeDeletedBy(deletedById: expected));
        }

        [Fact]
        public void ShouldNotBeDeletedBy_DeletedById_When_DeletedById_Null_Passes_Assertion()
        {
            // Arrange
            var result = BuildResult<UserStub>((e) => e.DeletedById = null);

            // Act & Assert
            Should.NotThrow(() => result.ShouldNotBeDeletedBy(deletedById: Random.Long()));
        }

        [Fact]
        public void ShouldNotBeDeletedBy_DeletedById_When_DeletedById_Does_Not_Match_Passes_Assertion()
        {
            // Arrange
            var deletedById = Random.Long(min: 1, max: 100);
            var unexpected = deletedById + 1;
            var result = BuildResult<UserStub>((e) => e.DeletedById = deletedById);

            // Act & Assert
            Should.NotThrow(() => result.ShouldNotBeDeletedBy(deletedById: unexpected));
        }

        #endregion ShouldNotBeDeletedBy(long deletedById)

        #region ShouldNotBeDeletedBy(IEntity deletedBy)

        [Fact]
        public void ShouldNotBeDeletedBy_DeletedBy_When_Expected_Entity_Null_Fails_Assertion()
        {
            // Arrange
            var result = BuildResult<UserStub>();

            // Act
            var exception = Record.Exception(() => result.ShouldNotBeDeletedBy(deletedBy: (IEntity)null));

            // Assert
            exception.ShouldNotBeNull();
            exception.Message.ShouldContain(ErrorConstants.ERROR_EXPECTED_ENTITY_IS_NULL_MESSAGE);
        }

        [Fact]
        public void ShouldNotBeDeletedBy_DeletedBy_When_Result_Null_Fails_Assertion()
        {
            // Arrange
            IResult<IDeletable> result = null;

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldNotBeDeletedBy(deletedBy: Build<UserStub>()));
        }

        [Fact]
        public void ShouldNotBeDeletedBy_DeletedBy_When_DeletedById_Matches_Fails_Assertion()
        {
            // Arrange
            var expected = Build<UserStub>((e) => e.DeletedById = Random.Long());
            var result = BuildResult<UserStub>((e) => e.DeletedById = expected.Id);

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldNotBeDeletedBy(deletedBy: expected));
        }

        [Fact]
        public void ShouldNotBeDeletedBy_DeletedBy_When_DeletedById_Null_Passes_Assertion()
        {
            // Arrange
            var unexpected = Build<UserStub>((e) => e.DeletedById = Random.Long());
            var result = BuildResult<UserStub>((e) => e.DeletedById = null);

            // Act & Assert
            Should.NotThrow(() => result.ShouldNotBeDeletedBy(deletedBy: unexpected));
        }

        [Fact]
        public void ShouldNotBeDeletedBy_DeletedBy_When_DeletedById_Does_Not_Match_Passes_Assertion()
        {
            // Arrange
            var unexpected = Build<UserStub>((e) => e.DeletedById = Random.Long(min: 1, max: 100));
            var result = BuildResult<UserStub>((e) => e.DeletedById = unexpected.Id + 1);

            // Act & Assert
            Should.NotThrow(() => result.ShouldNotBeDeletedBy(deletedBy: unexpected));
        }

        #endregion ShouldNotBeDeletedBy(IEntity deletedBy)

        #region ShouldNotBeUpdated

        [Fact]
        public void ShouldNotBeUpdated_When_Result_Null_Fails_Assertion()
        {
            // Arrange
            IResult<IUpdatable> result = null;

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldNotBeUpdated());
        }

        [Fact]
        public void ShouldNotBeUpdated_When_UpdatedOn_HasValue_Fails_Assertion()
        {
            // Arrange
            var result = BuildResult<UserStub>((e) => e.UpdatedOn = Faker.Date.RecentOffset());

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldNotBeUpdated());
        }

        [Fact]
        public void ShouldNotBeUpdated_When_UpdatedOn_Null_Passes_Assertion()
        {
            // Arrange
            var result = BuildResult<UserStub>((e) => e.UpdatedOn = null);

            // Act & Assert
            Should.NotThrow(() => result.ShouldNotBeUpdated());
        }

        #endregion ShouldNotBeUpdated

        #region ShouldNotBeUpdatedBy(long updatedById)

        [Fact]
        public void ShouldNotBeUpdatedBy_UpdatedById_When_Result_Null_Fails_Assertion()
        {
            // Arrange
            IResult<IUpdatable> result = null;

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldNotBeUpdatedBy(updatedById: Random.Long()));
        }

        [Fact]
        public void ShouldNotBeUpdatedBy_UpdatedById_When_UpdatedById_Matches_Fails_Assertion()
        {
            // Arrange
            var expected = Random.Long();
            var result = BuildResult<UserStub>((e) => e.UpdatedById = expected);

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldNotBeUpdatedBy(updatedById: expected));
        }

        [Fact]
        public void ShouldNotBeUpdatedBy_UpdatedById_When_UpdatedById_Null_Passes_Assertion()
        {
            // Arrange
            var result = BuildResult<UserStub>((e) => e.UpdatedById = null);

            // Act & Assert
            Should.NotThrow(() => result.ShouldNotBeUpdatedBy(updatedById: Random.Long()));
        }

        [Fact]
        public void ShouldNotBeUpdatedBy_UpdatedById_When_UpdatedById_Does_Not_Match_Passes_Assertion()
        {
            // Arrange
            var updatedById = Random.Long(min: 1, max: 100);
            var unexpected = updatedById + 1;
            var result = BuildResult<UserStub>((e) => e.UpdatedById = updatedById);

            // Act & Assert
            Should.NotThrow(() => result.ShouldNotBeUpdatedBy(updatedById: unexpected));
        }

        #endregion ShouldNotBeUpdatedBy(long updatedById)

        #region ShouldNotBeUpdatedBy(IEntity updatedBy)

        [Fact]
        public void ShouldNotBeUpdatedBy_UpdatedBy_When_Expected_Entity_Null_Fails_Assertion()
        {
            // Arrange
            var result = BuildResult<UserStub>();

            // Act
            var exception = Record.Exception(() => result.ShouldNotBeUpdatedBy(updatedBy: (IEntity)null));

            // Assert
            exception.ShouldNotBeNull();
            exception.Message.ShouldContain(ErrorConstants.ERROR_EXPECTED_ENTITY_IS_NULL_MESSAGE);
        }

        [Fact]
        public void ShouldNotBeUpdatedBy_UpdatedBy_When_Result_Null_Fails_Assertion()
        {
            // Arrange
            IResult<IUpdatable> result = null;

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldNotBeUpdatedBy(updatedBy: Build<UserStub>()));
        }

        [Fact]
        public void ShouldNotBeUpdatedBy_UpdatedBy_When_UpdatedById_Matches_Fails_Assertion()
        {
            // Arrange
            var expected = Build<UserStub>((e) => e.UpdatedById = Random.Long());
            var result = BuildResult<UserStub>((e) => e.UpdatedById = expected.Id);

            // Act & Assert
            Should.Throw<ShouldAssertException>(() => result.ShouldNotBeUpdatedBy(updatedBy: expected));
        }

        [Fact]
        public void ShouldNotBeUpdatedBy_UpdatedBy_When_UpdatedById_Null_Passes_Assertion()
        {
            // Arrange
            var unexpected = Build<UserStub>((e) => e.UpdatedById = Random.Long());
            var result = BuildResult<UserStub>((e) => e.UpdatedById = null);

            // Act & Assert
            Should.NotThrow(() => result.ShouldNotBeUpdatedBy(updatedBy: unexpected));
        }

        [Fact]
        public void ShouldNotBeUpdatedBy_UpdatedBy_When_UpdatedById_Does_Not_Match_Passes_Assertion()
        {
            // Arrange
            var unexpected = Build<UserStub>((e) => e.UpdatedById = Random.Long(min: 1, max: 100));
            var result = BuildResult<UserStub>((e) => e.UpdatedById = unexpected.Id + 1);

            // Act & Assert
            Should.NotThrow(() => result.ShouldNotBeUpdatedBy(updatedBy: unexpected));
        }

        #endregion ShouldNotBeUpdatedBy(IEntity updatedBy)
    }
}

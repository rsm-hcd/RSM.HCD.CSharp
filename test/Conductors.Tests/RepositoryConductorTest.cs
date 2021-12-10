using System.Collections.Generic;
using System.Linq;
using AndcultureCode.CSharp.Core.Interfaces.Conductors;
using AndcultureCode.CSharp.Testing.Extensions;
using AndcultureCode.CSharp.Testing.Tests;
using Moq;
using Shouldly;
using Xunit;
using Xunit.Abstractions;
using System.Linq.Expressions;
using System;
using AndcultureCode.CSharp.Testing.Models.Stubs;

namespace AndcultureCode.CSharp.Conductors.Tests
{
    public class RepositoryConductorTest : ProjectUnitTest
    {
        #region Setup

        public RepositoryConductorTest(ITestOutputHelper output) : base(output)
        {
        }

        private IRepositoryConductor<UserStub> SetupSut(
            Mock<IRepositoryCreateConductor<UserStub>> createConductor = null,
            Mock<IRepositoryDeleteConductor<UserStub>> deleteConductor = null,
            Mock<IRepositoryReadConductor<UserStub>> readConductor = null,
            Mock<IRepositoryUpdateConductor<UserStub>> updateConductor = null
        )
        {
            return new RepositoryConductor<UserStub>(
                createConductor: createConductor?.Object,
                deleteConductor: deleteConductor?.Object,
                readConductor: readConductor?.Object,
                updateConductor: updateConductor?.Object
            );
        }

        #endregion Setup

        #region BulkCreateOrUpdate

        [Fact]
        public void BulkCreateOrUpdate_When_Items_Is_Null_Then_Returns_Null()
        {
            // Arrange & Act
            var result = SetupSut().BulkCreateOrUpdate(null);

            // Assert
            result.ResultObject.ShouldBeNull();
        }

        [Fact]
        public void BulkCreateOrUpdate_When_Items_Is_Empty_Then_Returns_Empty()
        {
            // Arrange & Act
            var result = SetupSut().BulkCreateOrUpdate(new List<UserStub>());

            // Assert
            result.ResultObject.ShouldBeEmpty();
        }

        [Fact]
        public void BulkCreateOrUpdate_When_BulkUpdate_Has_Errors_Then_Result_Has_Errors_For_BulkUpdate()
        {
            // Arrange
            var mockUpdateConductor = new Mock<IRepositoryUpdateConductor<UserStub>>();

            var entities = BuildList<UserStub>(2);

            mockUpdateConductor.Setup(e => e.BulkUpdate(
                It.IsAny<IEnumerable<UserStub>>(),
                It.IsAny<long?>()
            )).ReturnsBasicErrorResult();

            var sut = SetupSut(
                updateConductor: mockUpdateConductor
            );

            // Act
            var result = sut.BulkCreateOrUpdate(entities);

            // Assert
            result.ShouldHaveBasicError();
        }

        [Fact]
        public void BulkCreateOrUpdate_When_BulkCreate_Has_Errors_Then_Result_Has_Errors_For_BulkCreate()
        {
            // Arrange
            var mockUpdateConductor = new Mock<IRepositoryUpdateConductor<UserStub>>();
            var mockCreateConductor = new Mock<IRepositoryCreateConductor<UserStub>>();

            var entities = BuildList<UserStub>(2);

            mockUpdateConductor.Setup(e => e.BulkUpdate(
                It.IsAny<IEnumerable<UserStub>>(),
                It.IsAny<long?>()
            )).ReturnsGivenResult(false);
            mockCreateConductor.Setup(e => e.BulkCreate(
                It.IsAny<IEnumerable<UserStub>>(),
                It.IsAny<long?>()
            )).ReturnsBasicErrorResult();

            var sut = SetupSut(
                createConductor: mockCreateConductor,
                updateConductor: mockUpdateConductor
            );

            // Act
            var result = sut.BulkCreateOrUpdate(entities);

            // Assert
            result.ShouldHaveBasicError();
        }

        [Fact]
        public void BulkCreateOrUpdate_When_BulkCreate_Returns_Null_Then_Result_Has_Errors()
        {
            // Arrange
            var mockUpdateConductor = new Mock<IRepositoryUpdateConductor<UserStub>>();
            var mockCreateConductor = new Mock<IRepositoryCreateConductor<UserStub>>();

            var entities = BuildList<UserStub>(2);

            mockUpdateConductor.Setup(e => e.BulkUpdate(
                It.IsAny<IEnumerable<UserStub>>(),
                It.IsAny<long?>()
            )).ReturnsGivenResult(false);
            mockCreateConductor.Setup(e => e.BulkCreate(
                It.IsAny<IEnumerable<UserStub>>(),
                It.IsAny<long?>()
            )).ReturnsBasicErrorResult();

            var sut = SetupSut(
                createConductor: mockCreateConductor,
                updateConductor: mockUpdateConductor
            );

            // Act
            var result = sut.BulkCreateOrUpdate(entities);

            // Assert
            result.ShouldHaveBasicError();
        }

        [Fact]
        public void BulkCreateOrUpdate_When_CreateResult_Is_Not_Null_Then_Returns_List_With_UserStub()
        {
            // Arrange
            var mockUpdateConductor = new Mock<IRepositoryUpdateConductor<UserStub>>();
            var mockCreateConductor = new Mock<IRepositoryCreateConductor<UserStub>>();

            var entities = BuildList<UserStub>(2);

            mockUpdateConductor.Setup(e => e.BulkUpdate(
                It.IsAny<IEnumerable<UserStub>>(),
                It.IsAny<long?>()
            )).ReturnsGivenResult(false);
            mockCreateConductor.Setup(e => e.BulkCreate(
                It.IsAny<IEnumerable<UserStub>>(),
                It.IsAny<long?>()
            )).ReturnsGivenResult(entities);

            var sut = SetupSut(
                createConductor: mockCreateConductor,
                updateConductor: mockUpdateConductor
            );

            // Act
            var result = sut.BulkCreateOrUpdate(entities);

            // Assert
            result.ShouldNotHaveErrors();
            result.ResultObject.ShouldNotBeNull();
            result.ResultObject.ShouldBeOfSize(entities.Count);
        }

        #endregion BulkCreateOrUpdate

        #region CreateOrUpdate

        [Fact]
        public void CreateOrUpdate_When_Id_Is_0_And_Create_Result_Has_Errors_Then_Returns_Null_With_Errors()
        {
            // Arrange
            var mockCreateConductor = new Mock<IRepositoryCreateConductor<UserStub>>();
            var entity = Build<UserStub>((e) => e.Id = 0);

            mockCreateConductor.Setup(e => e.Create(
                It.IsAny<UserStub>(),
                It.IsAny<long?>()
            )).ReturnsBasicErrorResult();
            var sut = SetupSut(createConductor: mockCreateConductor);

            // Act
            var result = sut.CreateOrUpdate(entity);

            // Assert
            result.ShouldHaveBasicError();
            result.ResultObject.ShouldBeNull();
        }

        [Fact]
        public void CreateOrUpdate_When_Id_Is_0_And_Create_Is_Successful_Then_Returns_Created_Object()
        {
            // Arrange
            var mockCreateConductor = new Mock<IRepositoryCreateConductor<UserStub>>();
            var entity = Build<UserStub>((e) => e.Id = 0);
            var created = Build<UserStub>((e) => e.Id = Random.Long(min: 1));

            mockCreateConductor.Setup(e => e.Create(
                It.IsAny<UserStub>(),
                It.IsAny<long?>()
            )).ReturnsGivenResult(created);
            var sut = SetupSut(createConductor: mockCreateConductor);

            // Act
            var result = sut.CreateOrUpdate(entity);

            // Assert
            result.ShouldNotHaveErrors();
            result.ResultObject.ShouldBe(created);
        }

        [Fact]
        public void CreateOrUpdate_When_Id_Is_Greater_Than_0_And_Update_Has_Errors_Then_Returns_Null_With_Errors()
        {
            // Arrange
            var mockUpdateConductor = new Mock<IRepositoryUpdateConductor<UserStub>>();
            var entity = Build<UserStub>((e) => e.Id = Random.Long(min: 1));

            mockUpdateConductor.Setup(e => e.Update(
                It.IsAny<UserStub>(),
                It.IsAny<long?>()
            )).ReturnsBasicErrorResult();
            var sut = SetupSut(updateConductor: mockUpdateConductor);

            // Act
            var result = sut.CreateOrUpdate(entity);

            // Assert
            result.ShouldHaveBasicError();
            result.ResultObject.ShouldBeNull();
        }

        [Fact]
        public void CreateOrUpdate_When_Id_Is_Greater_Than_0_and_Update_Is_Successful_Then_Returns_Updated_Item()
        {
            // Arrange
            var mockUpdateConductor = new Mock<IRepositoryUpdateConductor<UserStub>>();
            var entity = Build<UserStub>((e) => e.Id = Random.Long(min: 1));

            mockUpdateConductor.Setup(e => e.Update(
                It.IsAny<UserStub>(),
                It.IsAny<long?>()
            )).ReturnsGivenResult(true);
            var sut = SetupSut(updateConductor: mockUpdateConductor);

            // Act
            var result = sut.CreateOrUpdate(entity);

            // Assert
            result.ShouldNotHaveErrors();
            result.ResultObject.ShouldBe(entity);
        }

        [Fact]
        public void CreateOrUpdate_When_Exists_Items_To_Update_And_No_Items_To_Create_And_Update_HasErrors_Then_Returns_Empty_List_And_Error()
        {
            // Arrange
            var mockUpdateConductor = new Mock<IRepositoryUpdateConductor<UserStub>>();
            var mockCreateConductor = new Mock<IRepositoryCreateConductor<UserStub>>();

            var entities = BuildList<UserStub>(2);
            foreach (var entity in entities)
            {
                entity.Id = Random.Long(min: 1);
            }

            mockUpdateConductor.Setup(e => e.Update(
                It.IsAny<IEnumerable<UserStub>>(),
                It.IsAny<long?>()
            )).ReturnsBasicErrorResult();
            mockCreateConductor.Setup(e => e.Create(
                It.IsAny<IEnumerable<UserStub>>(),
                It.IsAny<long?>()
            )).ReturnsGivenResult();

            var sut = SetupSut(
                createConductor: mockCreateConductor,
                updateConductor: mockUpdateConductor);

            // Act
            var result = sut.CreateOrUpdate(entities);

            // Assert
            result.ShouldHaveErrors();
            result.ResultObject.ShouldBeEmpty();
        }

        [Fact]
        public void CreateOrUpdate_When_Items_To_Update_And_No_Items_To_Create_And_Update_Is_Successful_Then_Returns_Null()
        {
            // Arrange
            var mockUpdateConductor = new Mock<IRepositoryUpdateConductor<UserStub>>();
            var mockCreateConductor = new Mock<IRepositoryCreateConductor<UserStub>>();

            var entities = BuildList<UserStub>(2);
            foreach (var entity in entities)
            {
                entity.Id = Random.Long(min: 1);
            }

            mockUpdateConductor.Setup(e => e.Update(
                It.IsAny<IEnumerable<UserStub>>(),
                It.IsAny<long?>()
            )).ReturnsGivenResult(true);
            mockCreateConductor.Setup(e => e.Create(
                It.IsAny<IEnumerable<UserStub>>(),
                It.IsAny<long?>()
            )).ReturnsGivenResult(null);

            var sut = SetupSut(
                createConductor: mockCreateConductor,
                updateConductor: mockUpdateConductor);

            // Act
            var result = sut.CreateOrUpdate(entities);

            // Assert
            result.ShouldNotHaveErrors();
            result.ResultObject.ShouldBeEmpty();
        }

        [Fact]
        public void CreateOrUpdate_When_Items_To_Update_Do_Not_Exist_And_Items_To_Create_Exist_And_Create_Has_Errors_Then_Returns_Null_With_Error()
        {
            // Arrange
            var mockUpdateConductor = new Mock<IRepositoryUpdateConductor<UserStub>>();
            var mockCreateConductor = new Mock<IRepositoryCreateConductor<UserStub>>();

            var entities = BuildList<UserStub>(2);

            mockUpdateConductor.Setup(e => e.Update(
                It.IsAny<IEnumerable<UserStub>>(),
                It.IsAny<long?>()
            )).ReturnsGivenResult(true);
            mockCreateConductor.Setup(e => e.Create(
                It.IsAny<IEnumerable<UserStub>>(),
                It.IsAny<long?>()
            )).ReturnsBasicErrorResult();

            var sut = SetupSut(
                createConductor: mockCreateConductor,
                updateConductor: mockUpdateConductor);

            // Act
            var result = sut.CreateOrUpdate(entities);

            // Assert
            result.ShouldHaveBasicError();
            result.ResultObject.ShouldBeEmpty();
        }

        [Fact]
        public void CreateOrUpdate_When_Items_To_Update_Do_Not_Exist_And_Items_To_Create_Exist_And_Create_is_Successful_Then_Returns_Created_Entities()
        {
            // Arrange
            var mockUpdateConductor = new Mock<IRepositoryUpdateConductor<UserStub>>();
            var mockCreateConductor = new Mock<IRepositoryCreateConductor<UserStub>>();

            var entities = BuildList<UserStub>(2);

            var createdEntities = BuildList<UserStub>(2);
            foreach (var createdEntity in createdEntities)
            {
                createdEntity.Id = Random.Long(min: 1);
            }

            mockUpdateConductor.Setup(e => e.Update(
                It.IsAny<IEnumerable<UserStub>>(),
                It.IsAny<long?>()
            )).ReturnsGivenResult(true);
            mockCreateConductor.Setup(e => e.Create(
                It.IsAny<IEnumerable<UserStub>>(),
                It.IsAny<long?>()
            )).ReturnsGivenResult(createdEntities);

            var sut = SetupSut(
                createConductor: mockCreateConductor,
                updateConductor: mockUpdateConductor
            );

            // Act
            var result = sut.CreateOrUpdate(entities);

            // Assert
            result.ShouldNotHaveErrors();
            result.ResultObject.ShouldBe(createdEntities);
        }

        #endregion CreateOrUpdate

        #region Delete

        [Fact]
        public void Delete_When_Delete_HasErrors_Then_Returns_False_With_Errors()
        {
            // Arrange
            var entities = new List<UserStub>();
            var mockDeleteConductor = new Mock<IRepositoryDeleteConductor<UserStub>>();
            mockDeleteConductor.Setup(
                m => m.Delete(
                    It.IsAny<IEnumerable<UserStub>>(),
                    It.IsAny<long?>(),
                    It.IsAny<long>(),
                    It.IsAny<bool>()
            )).ReturnsBasicErrorResult();
            var sut = SetupSut(deleteConductor: mockDeleteConductor);

            // Act
            var result = sut.Delete(entities);

            // Assert
            result.ShouldHaveBasicError();
            result.ResultObject.ShouldBeFalse();
        }

        [Fact]
        public void Delete_When_Delete_Succeeds_Then_Returns_True()
        {
            // Arrange
            var entities = new List<UserStub>();
            var mockDeleteConductor = new Mock<IRepositoryDeleteConductor<UserStub>>();
            mockDeleteConductor.Setup(
                m => m.Delete(
                    It.IsAny<IEnumerable<UserStub>>(),
                    It.IsAny<long?>(),
                    It.IsAny<long>(),
                    It.IsAny<bool>()
            )).ReturnsGivenResult(true);
            var sut = SetupSut(deleteConductor: mockDeleteConductor);

            // Act
            var result = sut.Delete(entities);

            // Assert
            result.ShouldNotHaveErrors();
            result.ResultObject.ShouldBeTrue();
        }

        #endregion Delete

        #region FindAll (groupBy)

        #region Setup

        /// <summary>
        /// Mock class used in groupBySelector of tests below
        /// </summary>
        internal class GroupingResult
        {
            public object Key { get; set; }
            public object Value { get; set; }
        }

        #endregion Setup

        [Fact]
        public void FindAll_GroupBy_When_FindAll_HasErrors_Then_Returns_Errors()
        {
            // Arrange
            var mockReadConductor = new Mock<IRepositoryReadConductor<UserStub>>();
            mockReadConductor.Setup(
                m => m.FindAll<long>(
                    It.IsAny<Expression<Func<UserStub, bool>>>(), // filter
                    It.IsAny<Func<IQueryable<UserStub>, IOrderedQueryable<UserStub>>>(), // orderBy
                    It.IsAny<Expression<Func<UserStub, long>>>(), // groupBy
                    It.IsAny<string>(), // includeProperties
                    It.IsAny<int?>(), // skip
                    It.IsAny<int?>(), // take
                    It.IsAny<bool?>(), // ignoreQueryFilters
                    It.IsAny<bool>() // asNoTracking
            )).ReturnsBasicErrorResult();
            var sut = SetupSut(readConductor: mockReadConductor);

            // Act
            var result = sut.FindAll<long>(
                filter: o => o.Id == 1,
                orderBy: o => o.OrderBy(x => x.Id),
                groupBy: o => o.Id,
                ignoreQueryFilters: false,
                asNoTracking: false
            );

            // Assert
            result.ShouldHaveBasicError();
            result.ResultObject.ShouldBeNull();
        }

        [Fact]
        public void FindAll_GroupBy_When_No_Records_Found_Returns_Empty_List()
        {
            // Arrange
            var mockReadConductor = new Mock<IRepositoryReadConductor<UserStub>>();
            mockReadConductor.Setup(
                m => m.FindAll<long>(
                    It.IsAny<Expression<Func<UserStub, bool>>>(), // filter
                    It.IsAny<Func<IQueryable<UserStub>, IOrderedQueryable<UserStub>>>(), // orderBy
                    It.IsAny<Expression<Func<UserStub, long>>>(), // groupBy
                    It.IsAny<string>(), // includeProperties
                    It.IsAny<int?>(), // skip
                    It.IsAny<int?>(), // take
                    It.IsAny<bool?>(), // ignoreQueryFilters
                    It.IsAny<bool>() // asNoTracking
            )).ReturnsGivenResult(new List<IGrouping<long, UserStub>>().AsQueryable());
            var sut = SetupSut(readConductor: mockReadConductor);

            // Act
            var result = sut.FindAll<long>(
                filter: o => o.Id == 1,
                orderBy: o => o.OrderBy(x => x.Id),
                groupBy: o => o.Id,
                ignoreQueryFilters: false,
                asNoTracking: false
            );

            // Assert
            result.ShouldNotHaveErrors();
            result.ResultObject.ShouldNotBeNull();
            result.ResultObject.ShouldBeEmpty();
        }

        [Fact]
        public void FindAll_GroupBy_When_FindAll_Find_Something_And_Succeeds_Then_Returns_IQueryable()
        {
            // Arrange
            var query = BuildList<UserStub>(10).AsQueryable().GroupBy(UserStub => UserStub.Id);
            var mockReadConductor = new Mock<IRepositoryReadConductor<UserStub>>();
            mockReadConductor.Setup(
                m => m.FindAll<long>(
                    It.IsAny<Expression<Func<UserStub, bool>>>(), // filter
                    It.IsAny<Func<IQueryable<UserStub>, IOrderedQueryable<UserStub>>>(), // orderBy
                    It.IsAny<Expression<Func<UserStub, long>>>(), // groupBy
                    It.IsAny<string>(), // includeProperties
                    It.IsAny<int?>(), // skip
                    It.IsAny<int?>(), // take
                    It.IsAny<bool?>(), // ignoreQueryFilters
                    It.IsAny<bool>() // asNoTracking
            )).ReturnsGivenResult(query);
            var sut = SetupSut(readConductor: mockReadConductor);

            // Act
            var result = sut.FindAll<long>(
                filter: o => o.Id == 0,
                orderBy: o => o.OrderBy(x => x.Id),
                groupBy: o => o.Id,
                includeProperties: string.Empty,
                skip: 0,
                take: 100,
                ignoreQueryFilters: false,
                asNoTracking: false
            );

            // Assert
            result.ShouldNotHaveErrors();
            result.ResultObject.ShouldNotBeEmpty();
        }

        [Fact]
        public void FindAll_GroupBy_With_Selector_When_FindAll_HasErrors_Then_Returns_Errors()
        {
            // Arrange
            var mockReadConductor = new Mock<IRepositoryReadConductor<UserStub>>();
            mockReadConductor.Setup(
                m => m.FindAll<long, GroupingResult>(
                    It.IsAny<Expression<Func<UserStub, bool>>>(), // filter
                    It.IsAny<Func<IQueryable<UserStub>, IOrderedQueryable<UserStub>>>(), // orderBy
                    It.IsAny<Expression<Func<UserStub, long>>>(), // groupBy
                    It.IsAny<Expression<Func<long, IEnumerable<UserStub>, GroupingResult>>>(), // groupBySelector
                    It.IsAny<string>(), // includeProperties
                    It.IsAny<int?>(), // skip
                    It.IsAny<int?>(), // take
                    It.IsAny<bool?>(), // ignoreQueryFilters
                    It.IsAny<bool>() // asNoTracking
            )).ReturnsBasicErrorResult();
            var sut = SetupSut(readConductor: mockReadConductor);

            // Act
            var result = sut.FindAll<long, GroupingResult>(
                filter: o => o.Id == 1,
                orderBy: o => o.OrderBy(x => x.Id),
                groupBy: o => o.Id,
                groupBySelector: (o, k) => new GroupingResult { Key = o, Value = k.Max() },
                ignoreQueryFilters: false,
                asNoTracking: false
            );

            // Assert
            result.ShouldHaveBasicError();
            result.ResultObject.ShouldBeNull();
        }

        [Fact]
        public void FindAll_GroupBy_Given_Selector_When_No_Records_Found_Returns_Empty_List()
        {
            // Arrange
            var entities = new List<UserStub>();
            var mockReadConductor = new Mock<IRepositoryReadConductor<UserStub>>();
            mockReadConductor.Setup(
                m => m.FindAll<long, GroupingResult>(
                    It.IsAny<Expression<Func<UserStub, bool>>>(), // filter
                    It.IsAny<Func<IQueryable<UserStub>, IOrderedQueryable<UserStub>>>(), // orderBy
                    It.IsAny<Expression<Func<UserStub, long>>>(), // groupBy
                    It.IsAny<Expression<Func<long, IEnumerable<UserStub>, GroupingResult>>>(), // groupBySelector
                    It.IsAny<string>(), // includeProperties
                    It.IsAny<int?>(), // skip
                    It.IsAny<int?>(), // take
                    It.IsAny<bool?>(), // ignoreQueryFilters
                    It.IsAny<bool>() // asNoTracking
            )).ReturnsGivenResult(new List<GroupingResult>().AsQueryable());
            var sut = SetupSut(readConductor: mockReadConductor);

            // Act
            var result = sut.FindAll<long, GroupingResult>(
                filter: o => o.Id == 1,
                orderBy: o => o.OrderBy(x => x.Id),
                groupBy: o => o.Id,
                groupBySelector: (o, k) => new GroupingResult { Key = o, Value = k.Count() },
                ignoreQueryFilters: false,
                asNoTracking: false
            );

            // Assert
            result.ShouldNotHaveErrors();
            result.ResultObject.ShouldNotBeNull();
            result.ResultObject.ShouldBeEmpty();
        }

        [Fact]
        public void FindAll_GroupBy_With_Selector_When_FindAll_Find_Something_And_Succeeds_Then_Returns_IQueryable()
        {
            // Arrange
            var query = BuildList<UserStub>(10)
                .AsQueryable()
                .GroupBy(
                    e => e.FirstName,
                    (name, list) => new GroupingResult
                    {
                        Key = name,
                        Value = list.Count()
                    }
                );
            var mockReadConductor = new Mock<IRepositoryReadConductor<UserStub>>();
            mockReadConductor.Setup(
                m => m.FindAll<long, GroupingResult>(
                    It.IsAny<Expression<Func<UserStub, bool>>>(), // filter
                    It.IsAny<Func<IQueryable<UserStub>, IOrderedQueryable<UserStub>>>(), // orderBy
                    It.IsAny<Expression<Func<UserStub, long>>>(), // groupBy
                    It.IsAny<Expression<Func<long, IEnumerable<UserStub>, GroupingResult>>>(), // groupBySelector
                    It.IsAny<string>(), // includeProperties
                    It.IsAny<int?>(), // skip
                    It.IsAny<int?>(), // take
                    It.IsAny<bool?>(), // ignoreQueryFilters
                    It.IsAny<bool>() // asNoTracking
            )).ReturnsGivenResult(query);
            var sut = SetupSut(readConductor: mockReadConductor);

            // Act
            var result = sut.FindAll<long, GroupingResult>(
                filter: o => o.Id == 0,
                orderBy: o => o.OrderBy(x => x.Id),
                groupBy: o => o.Id,
                groupBySelector: (o, k) => new GroupingResult { Key = o, Value = k.Count() },
                includeProperties: string.Empty,
                skip: 0,
                take: 100,
                ignoreQueryFilters: false,
                asNoTracking: false
            );

            // Assert
            result.ShouldNotHaveErrors();
            result.ResultObject.ShouldNotBeEmpty();
        }

        #endregion FindAll
    }
}

using System.Collections.Generic;
using System.Linq;
using AndcultureCode.CSharp.Conductors.Tests.Stubs;
using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Core.Interfaces.Conductors;
using AndcultureCode.CSharp.Core.Models.Errors;
using AndcultureCode.CSharp.Core.Models.Entities;
using AndcultureCode.CSharp.Testing.Extensions;
using AndcultureCode.CSharp.Testing.Extensions.Mocks;
using AndcultureCode.CSharp.Testing.Extensions.Mocks.Conductors;
using AndcultureCode.CSharp.Testing.Tests;
using Moq;
using Shouldly;
using Xunit;
using Xunit.Abstractions;
using System.Linq.Expressions;
using System;

namespace AndcultureCode.CSharp.Conductors.Tests
{
    public class RepositoryConductorTest : BaseUnitTest
    {
        #region Setup
        public RepositoryConductorTest(ITestOutputHelper output) : base(output)
        {
        }
        #endregion

        const string BASIC_ERROR_KEY = "TESTERRORKEY";
        const string BASIC_ERROR_MESSAGE = "TESTERRORMESSAGE";

        private IRepositoryConductor<Entity> SetupSut(
            Mock<IRepositoryCreateConductor<Entity>> createConductor = null,
            Mock<IRepositoryDeleteConductor<Entity>> deleteConductor = null,
            Mock<IRepositoryReadConductor<Entity>> readConductor = null,
            Mock<IRepositoryUpdateConductor<Entity>> updateConductor = null
        )
        {
            return new RepositoryConductor<Entity>(
                createConductor: createConductor?.Object,
                deleteConductor: deleteConductor?.Object,
                readConductor: readConductor?.Object,
                updateConductor: updateConductor?.Object
            );
        }

        #region BulkCreateOrUpdate

        [Fact]
        public void BulkCreateOrUpdate_When_Items_Is_Null_Then_Returns_Null()
        {
            // Arrange

            // Act
            var bulkCreateOrUpdateResponse = SetupSut().BulkCreateOrUpdate(null);

            // Assert
            bulkCreateOrUpdateResponse.ResultObject.ShouldBeNull();
        }

        [Fact]
        public void BulkCreateOrUpdate_When_Items_Is_Empty_Then_Returns_Empty()
        {
            // Arrange

            // Act
            var bulkCreateOrUpdateResponse = SetupSut().BulkCreateOrUpdate(new List<TestEntity>());

            // Assert
            bulkCreateOrUpdateResponse.ResultObject.ShouldBeEmpty();
        }

        [Fact]
        public void BulkCreateOrUpdate_When_BulkUpdate_Has_Errors_Then_Result_Has_Errors_For_BulkUpdate()
        {
            // Arrange
            var mockUpdateConductor = new Mock<IRepositoryUpdateConductor<Entity>>();

            var entities = new List<TestEntity>();
            entities.Add(new TestEntity { Id = 1, Name = "hello-world" });
            mockUpdateConductor.Setup(e => e.BulkUpdate(
                It.IsAny<IEnumerable<Entity>>(),
                It.IsAny<long?>()
            )).Returns(new Result<bool>
            {
                Errors = new List<IError> {
                        new Error
                        {
                            Key     = BASIC_ERROR_KEY,
                            Message = BASIC_ERROR_MESSAGE
                        }
                    },
                ResultObject = false
            });

            var sut = SetupSut(
                updateConductor: mockUpdateConductor
            );

            // Act
            var bulkCreateOrUpdateResponse = sut.BulkCreateOrUpdate(entities.AsEnumerable(), 1);

            // Assert
            bulkCreateOrUpdateResponse.ShouldHaveErrors();
            bulkCreateOrUpdateResponse.ShouldHaveErrorsFor(BASIC_ERROR_KEY);
        }

        [Fact]
        public void BulkCreateOrUpdate_When_BulkCreate_Has_Errors_Then_Result_Has_Errors_For_BulkCreate()
        {
            // Arrange
            var mockUpdateConductor = new Mock<IRepositoryUpdateConductor<Entity>>();
            var mockCreateConductor = new Mock<IRepositoryCreateConductor<Entity>>();

            var entities = new List<Entity>();
            var entity = new TestEntity { Id = 0, Name = "hello-world" };
            entities.Add(entity);

            mockUpdateConductor.Setup(e => e.BulkUpdate(
                It.IsAny<IEnumerable<Entity>>(),
                It.IsAny<long?>()
            )).Returns(new Result<bool>
            {
                ResultObject = false
            });
            mockCreateConductor.Setup(e => e.BulkCreate(
                It.IsAny<IEnumerable<Entity>>(),
                It.IsAny<long?>()
            )).Returns(new Result<List<Entity>>
            {
                Errors = new List<IError> {
                        new Error
                        {
                            Key     = BASIC_ERROR_KEY,
                            Message = BASIC_ERROR_MESSAGE
                        }
                    },
                ResultObject = new List<Entity> { entity }
            });

            var sut = SetupSut(
                createConductor: mockCreateConductor,
                updateConductor: mockUpdateConductor
            );

            // Act
            var bulkCreateOrUpdateResponse = sut.BulkCreateOrUpdate(entities.AsEnumerable(), 1);

            // Assert
            bulkCreateOrUpdateResponse.ShouldHaveErrors();
            bulkCreateOrUpdateResponse.ShouldHaveErrorsFor(BASIC_ERROR_KEY);
        }

        [Fact]
        public void BulkCreateOrUpdate_When_BulkCreate_Returns_Null_Then_Result_Has_Errors()
        {
            // Arrange
            var mockUpdateConductor = new Mock<IRepositoryUpdateConductor<Entity>>();
            var mockCreateConductor = new Mock<IRepositoryCreateConductor<Entity>>();

            var entities = new List<Entity>();
            var entity = new TestEntity { Id = 0, Name = "hello-world" };
            entities.Add(entity);

            mockUpdateConductor.Setup(e => e.BulkUpdate(
                It.IsAny<IEnumerable<Entity>>(),
                It.IsAny<long?>()
            )).Returns(new Result<bool>
            {
                ResultObject = false
            });
            mockCreateConductor.Setup(e => e.BulkCreate(
                It.IsAny<IEnumerable<Entity>>(),
                It.IsAny<long?>()
            )).Returns(new Result<List<Entity>>
            {
                Errors = new List<IError> {
                        new Error
                        {
                            Key     = BASIC_ERROR_KEY,
                            Message = BASIC_ERROR_MESSAGE
                        }
                    },
                ResultObject = null
            });

            var sut = SetupSut(
                createConductor: mockCreateConductor,
                updateConductor: mockUpdateConductor
            );

            // Act
            var bulkCreateOrUpdateResponse = sut.BulkCreateOrUpdate(entities, 1);

            // Assert
            bulkCreateOrUpdateResponse.ShouldHaveErrors();
            bulkCreateOrUpdateResponse.ShouldHaveErrorsFor(BASIC_ERROR_KEY);
        }

        [Fact]
        public void BulkCreateOrUpdate_When_CreateResult_Is_Not_Null_Then_Returns_List_With_Entity()
        {
            // Arrange
            var mockUpdateConductor = new Mock<IRepositoryUpdateConductor<Entity>>();
            var mockCreateConductor = new Mock<IRepositoryCreateConductor<Entity>>();

            var entities = new List<Entity>();
            var entity = new TestEntity { Id = 0, Name = "hello-world" };
            entities.Add(entity);

            mockUpdateConductor.Setup(e => e.BulkUpdate(
                It.IsAny<IEnumerable<Entity>>(),
                It.IsAny<long?>()
            )).Returns(new Result<bool>
            {
                ResultObject = false
            });
            mockCreateConductor.Setup(e => e.BulkCreate(
                It.IsAny<IEnumerable<Entity>>(),
                It.IsAny<long?>()
            )).Returns(new Result<List<Entity>>
            {
                ResultObject = entities
            });

            var sut = SetupSut(
                createConductor: mockCreateConductor,
                updateConductor: mockUpdateConductor
            );

            // Act
            var bulkCreateOrUpdateResponse = sut.BulkCreateOrUpdate(entities, 1);

            // Assert
            bulkCreateOrUpdateResponse.ShouldNotHaveErrors();
            bulkCreateOrUpdateResponse.ResultObject.ShouldNotBeNull();
            bulkCreateOrUpdateResponse.ResultObject.Count().ShouldBe(1);
        }

        #endregion BulkCreateOrUpdate

        #region CreateOrUpdate

        [Fact]
        public void CreateOrUpdate_When_item_Id_Is_0_And_Create_Result_Has_Errors_Then_Returns_Null_With_Errors()
        {
            // Arrange
            var mockCreateConductor = new Mock<IRepositoryCreateConductor<Entity>>();
            var entity = new TestEntity() { Id = 0, Name = "Hello-world" };
            var createdByUserId = 1;

            mockCreateConductor.Setup(e => e.Create(
                It.IsAny<Entity>(),
                It.IsAny<long?>()
            )).Returns(new Result<Entity>
            {
                Errors = new List<IError>() {
                    new Error
                    {
                        Key     = BASIC_ERROR_KEY,
                        Message = BASIC_ERROR_MESSAGE
                    }},
                ResultObject = null
            });
            var sut = SetupSut(createConductor: mockCreateConductor);

            // Act
            var result = sut.CreateOrUpdate(entity, createdByUserId);

            // Assert
            result.ShouldHaveErrorsFor(BASIC_ERROR_KEY);
            result.ResultObject.ShouldBeNull();
        }

        [Fact]
        public void CreateOrUpdate_When_item_Id_Is_0_And_Create_Is_Successful_Then_Returns_Created_Object()
        {
            // Arrange
            var mockCreateConductor = new Mock<IRepositoryCreateConductor<Entity>>();
            var entity = new TestEntity { Id = 0, Name = "Hello-world" };
            var created = new TestEntity { Id = 1, Name = "Hello-world" };
            var createdByUserId = 1;

            mockCreateConductor.Setup(e => e.Create(
                It.IsAny<Entity>(),
                It.IsAny<long?>()
            )).Returns(new Result<Entity>
            {
                ResultObject = created
            });
            var sut = SetupSut(createConductor: mockCreateConductor);

            // Act
            var result = sut.CreateOrUpdate(entity, createdByUserId);

            // Assert
            result.ShouldNotHaveErrors();
            result.ResultObject.ShouldBe(created);
        }

        [Fact]
        public void CreateOrUpdate_When_item_Id_Is_Greater_Than_0_And_Update_Has_Errors_Then_Returns_Null_With_Errors()
        {
            // Arrange
            var mockUpdateConductor = new Mock<IRepositoryUpdateConductor<Entity>>();
            var entityToUpdate = new TestEntity { Id = 1, Name = "Hello-world" };
            var createdByUserId = 1;

            mockUpdateConductor.Setup(e => e.Update(
                It.IsAny<Entity>(),
                It.IsAny<long?>()
            )).Returns(new Result<bool>
            {
                Errors = new List<IError>() {
                    new Error
                    {
                        Key     = BASIC_ERROR_KEY,
                        Message = BASIC_ERROR_MESSAGE
                    }
                },
                ResultObject = false
            });
            var sut = SetupSut(updateConductor: mockUpdateConductor);

            // Act
            var result = sut.CreateOrUpdate(entityToUpdate, createdByUserId);

            // Assert
            result.ShouldHaveErrorsFor(BASIC_ERROR_KEY);
            result.ResultObject.ShouldBeNull();
        }
        [Fact]
        public void CreateOrUpdate_When_item_Id_Is_Greater_Than_0_and_Update_Is_Successful_Then_Returns_Updated_Item()
        {
            // Arrange
            var mockUpdateConductor = new Mock<IRepositoryUpdateConductor<Entity>>();
            var entityToUpdate = new TestEntity { Id = 1, Name = "Hello-world" };
            var createdByUserId = 1;

            mockUpdateConductor.Setup(e => e.Update(
                It.IsAny<Entity>(),
                It.IsAny<long?>()
            )).Returns(new Result<bool>
            {
                ResultObject = true
            });
            var sut = SetupSut(updateConductor: mockUpdateConductor);

            // Act
            var result = sut.CreateOrUpdate(entityToUpdate, createdByUserId);

            // Assert
            result.ShouldNotHaveErrors();
            result.ResultObject.ShouldBe(entityToUpdate);
        }

        [Fact]
        public void CreateOrUpdate_When_Exists_Items_To_Update_And_No_Items_To_Create_And_Update_HasErrors_Then_Returns_Empty_List_And_Error()
        {
            // Arrange
            var mockUpdateConductor = new Mock<IRepositoryUpdateConductor<Entity>>();
            var mockCreateConductor = new Mock<IRepositoryCreateConductor<Entity>>();
            var entities = new List<Entity>() {
                new TestEntity { Id = 1, Name = "Test-1" },
                new TestEntity { Id = 2, Name = "Test-2" }
            };
            var currentUserId = 1;
            mockUpdateConductor.Setup(e => e.Update(
                It.IsAny<IEnumerable<Entity>>(),
                It.IsAny<long?>()
            )).Returns(new Result<bool>
            {
                Errors = new List<IError>() {
                    new Error
                    {
                        Key = BASIC_ERROR_KEY,
                        Message = BASIC_ERROR_MESSAGE
                    }
                },
                ResultObject = false
            });
            mockCreateConductor.Setup(e => e.Create(
                It.IsAny<IEnumerable<Entity>>(),
                It.IsAny<long?>()
            )).Returns(new Result<List<Entity>>
            {
                ResultObject = null
            });

            var sut = SetupSut(
                createConductor: mockCreateConductor,
                updateConductor: mockUpdateConductor);

            // Act
            var result = sut.CreateOrUpdate(entities, currentUserId);

            // Assert
            result.ShouldHaveErrors();
            result.ResultObject.ShouldBeEmpty<Entity>();
        }

        [Fact]
        public void CreateOrUpdate_When_Items_To_Update_And_No_Items_To_Create_And_Update_Is_Successful_Then_Returns_Null()
        {
            // Arrange
            var mockUpdateConductor = new Mock<IRepositoryUpdateConductor<Entity>>();
            var mockCreateConductor = new Mock<IRepositoryCreateConductor<Entity>>();
            var entities = new List<Entity>() {
                new TestEntity { Id = 1, Name = "Test-1" },
                new TestEntity { Id = 2, Name = "Test-2" }
            };
            var currentUserId = 1;
            mockUpdateConductor.Setup(e => e.Update(
                It.IsAny<IEnumerable<Entity>>(),
                It.IsAny<long?>()
            )).Returns(new Result<bool>
            {
                ResultObject = true
            });
            mockCreateConductor.Setup(e => e.Create(
                It.IsAny<IEnumerable<Entity>>(),
                It.IsAny<long?>()
            )).Returns(new Result<List<Entity>>
            {
                ResultObject = null
            });

            var sut = SetupSut(
                createConductor: mockCreateConductor,
                updateConductor: mockUpdateConductor);

            // Act
            var result = sut.CreateOrUpdate(entities, currentUserId);

            // Assert
            result.ShouldNotHaveErrors();
            result.ResultObject.ShouldBeEmpty();
        }

        [Fact]
        public void CreateOrUpdate_When_Items_To_Update_Do_Not_Exist_And_Items_To_Create_Exist_And_Create_Has_Errors_Then_Returns_Null_With_Error()
        {
            // Arrange
            var mockUpdateConductor = new Mock<IRepositoryUpdateConductor<Entity>>();
            var mockCreateConductor = new Mock<IRepositoryCreateConductor<Entity>>();
            var entities = new List<Entity>() {
                new TestEntity { Id = 0, Name = "Test-1" },
                new TestEntity { Id = 0, Name = "Test-2" }
            };
            var currentUserId = 1;
            mockUpdateConductor.Setup(e => e.Update(
                It.IsAny<IEnumerable<Entity>>(),
                It.IsAny<long?>()
            )).Returns(new Result<bool>
            {
                ResultObject = true
            });
            mockCreateConductor.Setup(e => e.Create(
                It.IsAny<IEnumerable<Entity>>(),
                It.IsAny<long?>()
            )).Returns(new Result<List<Entity>>
            {
                Errors = new List<IError>() {
                    new Error() {
                    Key     = BASIC_ERROR_KEY,
                    Message = BASIC_ERROR_MESSAGE
                }},
                ResultObject = null
            });

            var sut = SetupSut(
                createConductor: mockCreateConductor,
                updateConductor: mockUpdateConductor);

            // Act
            var result = sut.CreateOrUpdate(entities, currentUserId);

            // Assert

            result.ShouldHaveErrorsFor(BASIC_ERROR_KEY);
            result.ResultObject.ShouldBeEmpty();
        }

        [Fact]
        public void CreateOrUpdate_When_Items_To_Update_Do_Not_Exist_And_Items_To_Create_Exist_And_Create_is_Successful_Then_Returns_Created_Entities()
        {
            // Arrange
            var mockUpdateConductor = new Mock<IRepositoryUpdateConductor<Entity>>();
            var mockCreateConductor = new Mock<IRepositoryCreateConductor<Entity>>();
            var entities = new List<Entity>() {
                new TestEntity { Id = 0, Name = "Test-1" },
                new TestEntity { Id = 0, Name = "Test-2" }
            };
            var createdEntities = new List<Entity>() {
                new TestEntity { Id = 1, Name = "Test-1" },
                new TestEntity { Id = 2, Name = "Test-2" }
            };
            var currentUserId = 1;
            mockUpdateConductor.Setup(e => e.Update(
                It.IsAny<IEnumerable<Entity>>(),
                It.IsAny<long?>()
            )).Returns(new Result<bool>
            {
                ResultObject = true
            });
            mockCreateConductor.Setup(e => e.Create(
                It.IsAny<IEnumerable<Entity>>(),
                It.IsAny<long?>()
            )).Returns(new Result<List<Entity>>
            {
                ResultObject = createdEntities
            });

            var sut = SetupSut(
                createConductor: mockCreateConductor,
                updateConductor: mockUpdateConductor);

            // Act
            var result = sut.CreateOrUpdate(entities, currentUserId);

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
            var entities = new List<Entity>();
            var mockDeleteConductor = new Mock<IRepositoryDeleteConductor<Entity>>();
            mockDeleteConductor.Setup(
                m => m.Delete(It.IsAny<IEnumerable<Entity>>(), It.IsAny<long?>(), It.IsAny<long>(), It.IsAny<bool>()
            )).ReturnsBasicErrorResult();
            var sut = SetupSut(deleteConductor: mockDeleteConductor);

            // Act
            var result = sut.Delete(entities, null, 100, true);

            // Assert
            result.ShouldHaveErrorsFor(BASIC_ERROR_KEY);
            result.ResultObject.ShouldBeFalse();
        }

        [Fact]
        public void Delete_When_Delete_Succeeds_Then_Returns_True()
        {
            // Arrange
            var entities = new List<Entity>();
            var mockDeleteConductor = new Mock<IRepositoryDeleteConductor<Entity>>();
            mockDeleteConductor.Setup(
                m => m.Delete(It.IsAny<IEnumerable<Entity>>(), It.IsAny<long?>(), It.IsAny<long>(), It.IsAny<bool>()
            )).ReturnsGivenResult(true);
            var sut = SetupSut(deleteConductor: mockDeleteConductor);

            // Act
            var result = sut.Delete(entities, null, 100, true);

            // Assert
            result.ShouldNotHaveErrors();
            result.ResultObject.ShouldBeTrue();
        }

        #endregion Delete

        #region findAll

        /// <summary>
        /// moke class used in groupBySelector of tests below
        /// </summary>
        internal class GroupingResult
        {
            public object Key { get; set; }
            public object Value { get; set; }

        }

        /// <summary>
        /// moke class used on findAll tests below
        /// </summary>
        internal class FindAllMokedEntity : Entity
        {
            public string Name { get; set; }
            public decimal Age { get; set; }
        }

        [Fact]
        public void FindAll_GroupBy_When_FindAll_HasErrors_Then_Returns_An_Errors()
        {
            // Arrange
            var entities = new List<Entity>();
            var mockReadConductor = new Mock<IRepositoryReadConductor<Entity>>();
            mockReadConductor.Setup(
                m => m.FindAll<long>(
                    It.IsAny<Expression<Func<Entity, bool>>>(), // filter
                    It.IsAny<Func<IQueryable<Entity>, IOrderedQueryable<Entity>>>(), // orderBy
                    It.IsAny<Expression<Func<Entity, long>>>(), // groupBy
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
                includeProperties: null,
                skip: null,
                take: null,
                ignoreQueryFilters: false,
                asNoTracking: false
            );

            // Assert
            result.ShouldHaveErrorsFor(BASIC_ERROR_KEY);
            result.ResultObject.ShouldBeNull();
        }

        [Fact]
        public void FindAll_GroupBy_When_FindAll_Not_Find_Anyting_And_Succeeds_Then_Returns_An_Empty_IQueryable()
        {
            // Arrange
            var entities = new List<Entity>();
            var mockReadConductor = new Mock<IRepositoryReadConductor<Entity>>();
            mockReadConductor.Setup(
                m => m.FindAll<long>(
                    It.IsAny<Expression<Func<Entity, bool>>>(), // filter
                    It.IsAny<Func<IQueryable<Entity>, IOrderedQueryable<Entity>>>(), // orderBy
                    It.IsAny<Expression<Func<Entity, long>>>(), // groupBy
                    It.IsAny<string>(), // includeProperties
                    It.IsAny<int?>(), // skip
                    It.IsAny<int?>(), // take
                    It.IsAny<bool?>(), // ignoreQueryFilters
                    It.IsAny<bool>() // asNoTracking
            )).Returns(new Result<IQueryable<IGrouping<long, Entity>>>());
            var sut = SetupSut(readConductor: mockReadConductor);

            // Act
            var result = sut.FindAll<long>(
                filter: o => o.Id == 1,
                orderBy: o => o.OrderBy(x => x.Id),
                groupBy: o => o.Id,
                includeProperties: null,
                skip: null,
                take: null,
                ignoreQueryFilters: false,
                asNoTracking: false
            );

            // Assert
            result.ShouldNotHaveErrors();
            result.ResultObject.ShouldBeNull();
        }

        [Fact]
        public void FindAll_GroupBy_When_FindAll_Find_Something_And_Succeeds_Then_Returns_An_IQueryable()
        {
            // Arrange           
            List<FindAllMokedEntity> mokedEntityList =
                new List<FindAllMokedEntity> {
                    new FindAllMokedEntity { Id = 0, },
                    new FindAllMokedEntity { Id = 1, },
                    new FindAllMokedEntity { Id = 2, },
                    new FindAllMokedEntity { Id = 3, }
                };
            var query = mokedEntityList.AsQueryable().GroupBy(entity => entity.Id);

            var mockReadConductor = new Mock<IRepositoryReadConductor<Entity>>();
            mockReadConductor.Setup(
                m => m.FindAll<long>(
                    It.IsAny<Expression<Func<Entity, bool>>>(), // filter
                    It.IsAny<Func<IQueryable<Entity>, IOrderedQueryable<Entity>>>(), // orderBy
                    It.IsAny<Expression<Func<Entity, long>>>(), // groupBy
                    It.IsAny<string>(), // includeProperties
                    It.IsAny<int?>(), // skip
                    It.IsAny<int?>(), // take
                    It.IsAny<bool?>(), // ignoreQueryFilters
                    It.IsAny<bool>() // asNoTracking
            )).Returns(new Result<IQueryable<IGrouping<long, Entity>>>(query));
            var sut = SetupSut(readConductor: mockReadConductor);

            // Act
            var result = sut.FindAll<long>(
                filter: o => o.Id > 0,
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
            result.ResultObject.ShouldNotBeNull();
        }

        [Fact]
        public void FindAll_GroupBy_With_Selector_When_FindAll_HasErrors_Then_Returns_An_Errors()
        {
            // Arrange
            var entities = new List<Entity>();
            var mockReadConductor = new Mock<IRepositoryReadConductor<Entity>>();
            mockReadConductor.Setup(
                m => m.FindAll<long, GroupingResult>(
                    It.IsAny<Expression<Func<Entity, bool>>>(), // filter
                    It.IsAny<Func<IQueryable<Entity>, IOrderedQueryable<Entity>>>(), // orderBy
                    It.IsAny<Expression<Func<Entity, long>>>(), // groupBy
                    It.IsAny<Expression<Func<long, IEnumerable<Entity>, GroupingResult>>>(), // groupBySelector
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
                includeProperties: null,
                skip: null,
                take: null,
                ignoreQueryFilters: false,
                asNoTracking: false
            );

            // Assert
            result.ShouldHaveErrorsFor(BASIC_ERROR_KEY);
            result.ResultObject.ShouldBeNull();
        }

        [Fact]
        public void FindAll_GroupBy_With_Selector_When_FindAll_Not_Find_Anyting_And_Succeeds_Then_Returns_An_Empty_IQueryable()
        {
            // Arrange
            var entities = new List<Entity>();
            var mockReadConductor = new Mock<IRepositoryReadConductor<Entity>>();
            mockReadConductor.Setup(
                m => m.FindAll<long, GroupingResult>(
                    It.IsAny<Expression<Func<Entity, bool>>>(), // filter
                    It.IsAny<Func<IQueryable<Entity>, IOrderedQueryable<Entity>>>(), // orderBy
                    It.IsAny<Expression<Func<Entity, long>>>(), // groupBy
                    It.IsAny<Expression<Func<long, IEnumerable<Entity>, GroupingResult>>>(), // groupBySelector
                    It.IsAny<string>(), // includeProperties
                    It.IsAny<int?>(), // skip
                    It.IsAny<int?>(), // take
                    It.IsAny<bool?>(), // ignoreQueryFilters
                    It.IsAny<bool>() // asNoTracking
            )).Returns(new Result<IQueryable<GroupingResult>>());
            var sut = SetupSut(readConductor: mockReadConductor);

            // Act
            var result = sut.FindAll<long, GroupingResult>(
                filter: o => o.Id == 1,
                orderBy: o => o.OrderBy(x => x.Id),
                groupBy: o => o.Id,
                groupBySelector: (o, k) => new GroupingResult { Key = o, Value = k.Count() },
                includeProperties: null,
                skip: null,
                take: null,
                ignoreQueryFilters: false,
                asNoTracking: false
            );

            // Assert
            result.ShouldNotHaveErrors();
            result.ResultObject.ShouldBeNull();
        }


        [Fact]
        public void FindAll_GroupBy_With_Selector_When_FindAll_Find_Something_And_Succeeds_Then_Returns_An_IQueryable()
        {
            // Arrange           
            List<FindAllMokedEntity> mokedEntityList =
                new List<FindAllMokedEntity> {
                    new FindAllMokedEntity { Id = 0, },
                    new FindAllMokedEntity { Id = 1, },
                    new FindAllMokedEntity { Id = 2, },
                    new FindAllMokedEntity { Id = 3, }
                };
            var query = mokedEntityList.AsQueryable().GroupBy(
                entity => Math.Floor(entity.Age),
                (age, list) => new GroupingResult
                {
                    Key = age,
                    Value = list.Count()
                });

            var mockReadConductor = new Mock<IRepositoryReadConductor<Entity>>();
            mockReadConductor.Setup(
                m => m.FindAll<long, GroupingResult>(
                    It.IsAny<Expression<Func<Entity, bool>>>(), // filter
                    It.IsAny<Func<IQueryable<Entity>, IOrderedQueryable<Entity>>>(), // orderBy
                    It.IsAny<Expression<Func<Entity, long>>>(), // groupBy
                    It.IsAny<Expression<Func<long, IEnumerable<Entity>, GroupingResult>>>(), // groupBySelector
                    It.IsAny<string>(), // includeProperties
                    It.IsAny<int?>(), // skip
                    It.IsAny<int?>(), // take
                    It.IsAny<bool?>(), // ignoreQueryFilters
                    It.IsAny<bool>() // asNoTracking
            )).Returns(new Result<IQueryable<GroupingResult>>(query));
            var sut = SetupSut(readConductor: mockReadConductor);

            // Act
            var result = sut.FindAll<long, GroupingResult>(
                filter: o => o.Id > 0,
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
            result.ResultObject.ShouldNotBeNull();
        }

        #endregion findAll
    }
}

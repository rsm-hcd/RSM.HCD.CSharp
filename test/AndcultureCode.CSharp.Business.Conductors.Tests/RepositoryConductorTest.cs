using System.Collections.Generic;
using System.Linq;
using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Core.Interfaces.Conductors;
using AndcultureCode.CSharp.Core.Models;
using AndcultureCode.CSharp.Core.Models.Entities;
using AndcultureCode.CSharp.Testing;
using Moq;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace AndcultureCode.CSharp.Business.Conductors.Tests
{
    public class RepositoryConductorTest : UnitTestBase
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
            Mock<IRepositoryReadConductor<Entity>>   readConductor   = null,
            Mock<IRepositoryUpdateConductor<Entity>> updateConductor = null,
            Mock<IRepositoryDeleteConductor<Entity>> deleteConductor = null
        )
        {
            return new RepositoryConductor<Entity>(
                createConductor?.Object,
                readConductor?.Object,
                updateConductor?.Object,
                deleteConductor?.Object
            );
        }

        #region CreateOrUpdate

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
            entities.Add(new TestEntity() { Id = 1, Name = "hello-world" });
            mockUpdateConductor.Setup(e => e.BulkUpdate(
                It.IsAny<IEnumerable<Entity>>(),
                It.IsAny<long?>()
            )).Returns(new Result<bool>
            {
                Errors = new List<IError> {
                        new Error(){
                            Key     = BASIC_ERROR_KEY,
                            Message = BASIC_ERROR_MESSAGE}
                    },
                ResultObject = false
            });

            var sut = SetupSut(
                updateConductor: mockUpdateConductor
            );

            // Act
            var bulkCreateOrUpdateResponse = sut.BulkCreateOrUpdate(entities.AsEnumerable(), 1);

            // Assert
            bulkCreateOrUpdateResponse.HasErrors.ShouldBeTrue();
            bulkCreateOrUpdateResponse.Errors.FirstOrDefault().Key.ShouldBe(BASIC_ERROR_KEY);
        }

        [Fact]
        public void BulkCreateOrUpdate_When_BulkCreate_Has_Errors_Then_Result_Has_Errors_For_BulkCreate()
        {
            // Arrange
            var mockUpdateConductor = new Mock<IRepositoryUpdateConductor<Entity>>();
            var mockCreateConductor = new Mock<IRepositoryCreateConductor<Entity>>();

            var entities = new List<Entity>();
            var entity   = new TestEntity() { Id = 0, Name = "hello-world" };
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
                        new Error(){
                            Key     = BASIC_ERROR_KEY,
                            Message = BASIC_ERROR_MESSAGE}
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
            bulkCreateOrUpdateResponse.HasErrors.ShouldBeTrue();
            bulkCreateOrUpdateResponse.Errors.FirstOrDefault().Key.ShouldBe(BASIC_ERROR_KEY);
        }
        [Fact]
        public void BulkCreateOrUpdate_When_BulkCreate_Returns_Null_Then_Result_Has_Errors()
        {
            // Arrange
            var mockUpdateConductor = new Mock<IRepositoryUpdateConductor<Entity>>();
            var mockCreateConductor = new Mock<IRepositoryCreateConductor<Entity>>();

            var entities = new List<Entity>();
            var entity   = new TestEntity() { Id = 0, Name = "hello-world" };
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
                        new Error(){
                            Key     = BASIC_ERROR_KEY,
                            Message = BASIC_ERROR_MESSAGE}
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
            bulkCreateOrUpdateResponse.HasErrors.ShouldBeTrue();
            bulkCreateOrUpdateResponse.Errors.FirstOrDefault().Key.ShouldBe(BASIC_ERROR_KEY);
        }
        [Fact]
        public void BulkCreateOrUpdate_When_CreateResult_Is_Not_Null_Then_Returns_List_With_Entity()
        {
            // Arrange
            var mockUpdateConductor = new Mock<IRepositoryUpdateConductor<Entity>>();
            var mockCreateConductor = new Mock<IRepositoryCreateConductor<Entity>>();

            var entities = new List<Entity>();
            var entity   = new TestEntity() { Id = 0, Name = "hello-world" };
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
            bulkCreateOrUpdateResponse.HasErrors.ShouldBeFalse();
            bulkCreateOrUpdateResponse.ResultObject.ShouldNotBeNull();
            bulkCreateOrUpdateResponse.ResultObject.Count().ShouldBe(1);
        }


        #endregion
        #region CreateOrUpdate
        [Fact]
        public void CreateOrUpdate_When_item_Id_Is_0_And_Create_Result_Has_Errors_Then_Returns_Null_With_Errors()
        {
            // Arrange
            var mockCreateConductor = new Mock<IRepositoryCreateConductor<Entity>>();
            var entity              = new TestEntity() { Id = 0, Name = "Hello-world" };
            var createdByUserId     = 1;

            mockCreateConductor.Setup(e => e.Create(
                It.IsAny<Entity>(),
                It.IsAny<long?>()
            )).Returns(new Result<Entity>
            {
                Errors = new List<IError>() {
                    new Error() {
                    Key     = BASIC_ERROR_KEY,
                    Message = BASIC_ERROR_MESSAGE
                }},
                ResultObject = null
            });
            var sut = SetupSut(createConductor: mockCreateConductor);
            // Act
            var result = sut.CreateOrUpdate(entity, createdByUserId);

            // Assert
            result.HasErrors.ShouldBeTrue();
            result.Errors.FirstOrDefault().Key.ShouldBe(BASIC_ERROR_KEY);
            result.ResultObject.ShouldBeNull();
        }
        [Fact]
        public void CreateOrUpdate_When_item_Id_Is_0_And_Create_Is_Successful_Then_Returns_Created_Object()
        {
            // Arrange
            var mockCreateConductor = new Mock<IRepositoryCreateConductor<Entity>>();
            var entity              = new TestEntity() { Id = 0, Name = "Hello-world" };
            var created             = new TestEntity() { Id = 1, Name = "Hello-world" };
            var createdByUserId     = 1;

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
            result.HasErrors.ShouldBeFalse();
            result.ResultObject.ShouldBe(created);
        }
        [Fact]
        public void CreateOrUpdate_When_item_Id_Is_Greater_Than_0_And_Update_Has_Errors_Then_Returns_Null_With_Errors()
        {
            // Arrange
            var mockUpdateConductor = new Mock<IRepositoryUpdateConductor<Entity>>();
            var entityToUpdate      = new TestEntity() { Id = 1, Name = "Hello-world" };
            var createdByUserId     = 1;

            mockUpdateConductor.Setup(e => e.Update(
                It.IsAny<Entity>(),
                It.IsAny<long?>()
            )).Returns(new Result<bool>
            {
                Errors = new List<IError>() {
                    new Error() {
                    Key     = BASIC_ERROR_KEY,
                    Message = BASIC_ERROR_MESSAGE
                }},
                ResultObject = false
            });
            var sut = SetupSut(updateConductor: mockUpdateConductor);
            // Act
            var result = sut.CreateOrUpdate(entityToUpdate, createdByUserId);

            // Assert
            result.HasErrors.ShouldBeTrue();
            result.Errors.FirstOrDefault().Key.ShouldBe(BASIC_ERROR_KEY);
            result.ResultObject.ShouldBeNull();
        }
        [Fact]
        public void CreateOrUpdate_When_item_Id_Is_Greater_Than_0_and_Update_Is_Successful_Then_Returns_Updated_Item()
        {
            // Arrange
            var mockUpdateConductor = new Mock<IRepositoryUpdateConductor<Entity>>();
            var entityToUpdate = new TestEntity() { Id = 1, Name = "Hello-world" };
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
            result.HasErrors.ShouldBeFalse();
            result.ResultObject.ShouldBe(entityToUpdate);
        }

        [Fact]
        public void CreateOrUpdate_When_Exists_Items_To_Update_And_No_Items_To_Create_And_Update_HasErrors_Then_Returns_Empty_List_And_Error()
        {
            // Arrange
            var mockUpdateConductor = new Mock<IRepositoryUpdateConductor<Entity>>();
            var mockCreateConductor = new Mock<IRepositoryCreateConductor<Entity>>();
            var entities = new List<Entity>() {
                new TestEntity() { Id = 1, Name = "Test-1" },
                new TestEntity() { Id = 2, Name = "Test-2" }
            };
            var currentUserId = 1;
            mockUpdateConductor.Setup(e => e.Update(
                It.IsAny<IEnumerable<Entity>>(),
                It.IsAny<long?>()
            )).Returns(new Result<bool> {
                Errors = new List<IError>() {
                    new Error() {
                        Key = BASIC_ERROR_KEY,
                        Message = BASIC_ERROR_MESSAGE
                    }
                },
                ResultObject = false
            });
            mockCreateConductor.Setup(e => e.Create(
                It.IsAny<IEnumerable<Entity>>(),
                It.IsAny<long?>()
            )).Returns(new Result<List<Entity>> {
                ResultObject = null
            });
            
            var sut = SetupSut(
                createConductor: mockCreateConductor,
                updateConductor: mockUpdateConductor);

            // Act
            var result = sut.CreateOrUpdate(entities, currentUserId);
            
            // Assert
            result.HasErrors.ShouldBeTrue();
            result.ResultObject.ShouldBeEmpty<Entity>();
        }
        [Fact]
        public void CreateOrUpdate_When_Items_To_Update_And_No_Items_To_Create_And_Update_Is_Successful_Then_Returns_Null()
        {
            // Arrange
            var mockUpdateConductor = new Mock<IRepositoryUpdateConductor<Entity>>();
            var mockCreateConductor = new Mock<IRepositoryCreateConductor<Entity>>();
            var entities = new List<Entity>() {
                new TestEntity() { Id = 1, Name = "Test-1" },
                new TestEntity() { Id = 2, Name = "Test-2" }
            };
            var currentUserId = 1;
            mockUpdateConductor.Setup(e => e.Update(
                It.IsAny<IEnumerable<Entity>>(),
                It.IsAny<long?>()
            )).Returns(new Result<bool> {
                ResultObject = true
            });
            mockCreateConductor.Setup(e => e.Create(
                It.IsAny<IEnumerable<Entity>>(),
                It.IsAny<long?>()
            )).Returns(new Result<List<Entity>> {
                ResultObject = null
            });
            
            var sut = SetupSut(
                createConductor: mockCreateConductor,
                updateConductor: mockUpdateConductor);

            // Act
            var result = sut.CreateOrUpdate(entities, currentUserId);
            
            // Assert
            result.HasErrors.ShouldBeFalse();
            result.ResultObject.ShouldBeEmpty();
        }
        [Fact]
        public void CreateOrUpdate_When_Items_To_Update_Do_Not_Exist_And_Items_To_Create_Exist_And_Create_Has_Errors_Then_Returns_Null_With_Error()
        {
            // Arrange
            var mockUpdateConductor = new Mock<IRepositoryUpdateConductor<Entity>>();
            var mockCreateConductor = new Mock<IRepositoryCreateConductor<Entity>>();
            var entities = new List<Entity>() {
                new TestEntity() { Id = 0, Name = "Test-1" },
                new TestEntity() { Id = 0, Name = "Test-2" }
            };
            var currentUserId = 1;
            mockUpdateConductor.Setup(e => e.Update(
                It.IsAny<IEnumerable<Entity>>(),
                It.IsAny<long?>()
            )).Returns(new Result<bool> {
                ResultObject = true
            });
            mockCreateConductor.Setup(e => e.Create(
                It.IsAny<IEnumerable<Entity>>(),
                It.IsAny<long?>()
            )).Returns(new Result<List<Entity>> {
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
            result.HasErrors.ShouldBeTrue();
            result.Errors.FirstOrDefault().Key.ShouldBe(BASIC_ERROR_KEY);
            result.ResultObject.ShouldBeEmpty();
        }
        
        [Fact]
        public void CreateOrUpdate_When_Items_To_Update_Do_Not_Exist_And_Items_To_Create_Exist_And_Create_is_Successful_Then_Returns_Created_Entities()
        {
            // Arrange
            var mockUpdateConductor = new Mock<IRepositoryUpdateConductor<Entity>>();
            var mockCreateConductor = new Mock<IRepositoryCreateConductor<Entity>>();
            var entities = new List<Entity>() {
                new TestEntity() { Id = 0, Name = "Test-1" },
                new TestEntity() { Id = 0, Name = "Test-2" }
            };
            var createdEntities = new List<Entity>() {
                new TestEntity() { Id = 1, Name = "Test-1" },
                new TestEntity() { Id = 2, Name = "Test-2" }
            };
            var currentUserId = 1;
            mockUpdateConductor.Setup(e => e.Update(
                It.IsAny<IEnumerable<Entity>>(),
                It.IsAny<long?>()
            )).Returns(new Result<bool> {
                ResultObject = true
            });
            mockCreateConductor.Setup(e => e.Create(
                It.IsAny<IEnumerable<Entity>>(),
                It.IsAny<long?>()
            )).Returns(new Result<List<Entity>> {
                ResultObject = createdEntities
            });
            
            var sut = SetupSut(
                createConductor: mockCreateConductor,
                updateConductor: mockUpdateConductor);

            // Act
            var result = sut.CreateOrUpdate(entities, currentUserId);
        
            // Assert
            result.HasErrors.ShouldBeFalse();
            result.ResultObject.ShouldBe(createdEntities);
        }

        #endregion
    }
}

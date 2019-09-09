
using AndcultureCode.CSharp.Testing;
using Xunit;
using Xunit.Abstractions;
using Moq;
using System;
using AndcultureCode.CSharp.Core.Interfaces.Entity;
using System.Collections.Generic;
using AndcultureCode.CSharp.Core.Models;
using AndcultureCode.CSharp.Core.Interfaces;
using System.Linq;
using Shouldly;
using AndcultureCode.CSharp.Testing.Extensions;
using AndcultureCode.CSharp.Core.Interfaces.Data;

namespace AndcultureCode.CSharp.Business.Conductors.Tests
{
    public class RepositoryCreateConductorTest : UnitTestBase
    {
        #region Setup
        public RepositoryCreateConductorTest(ITestOutputHelper output) : base(output)
        {
        }
        public class TestEntity : IEntity
        {
            public long Id { get; set; }
            public string name { get; set; }
            public long userId { get; set; }
        }

        #endregion

        #region BulkCreate

        [Fact]
        public void BulkCreate_When_Multiple_Items_And_User_Id_Returns_Multiple_Items()
        {
            // Arrange
            var currentUserId = 1;
            var entity1 = new TestEntity()
            {
                Id = 1,
                name = "test",
                userId = currentUserId
            };
            var entity2 = new TestEntity()
            {
                Id = 2,
                name = "test",
                userId = currentUserId
            };


            var entities = new List<TestEntity> {entity1, entity2};
            IResult<List<TestEntity>> givenResult = new Result<List<TestEntity>>(entities);
            var mockRepository = new Mock<IRepository<TestEntity>>();
            mockRepository.Setup(x => x.BulkCreate(It.IsAny<IEnumerable<TestEntity>>(), It.IsAny<long>()))
                          .Returns(givenResult);
            var sut = new RepositoryCreateConductor<TestEntity>(mockRepository.Object);
            
            // Act
            var result = sut.BulkCreate(entities, currentUserId);
        
            // Assert
            result.ShouldNotHaveErrors();
            result.ResultObject.Count.ShouldBe(2);
        }
        
        [Fact]
        public void BulkCreate_When_Repository_Has_Errors_Then_Returns_Null_And_Errors()
        {
            // Arrange
            var currentUserId = 1;
            var entity1 = new TestEntity()
            {
                Id = 1,
                name = "test",
                userId = currentUserId
            };
            var entity2 = new TestEntity()
            {
                Id = 2,
                name = "test",
                userId = currentUserId
            };

            var entities = new List<TestEntity> {entity1, entity2};
            IResult<List<TestEntity>> newGiven = new Result<List<TestEntity>>(entities);

            var mockRepository = new Mock<IRepository<TestEntity>>();
            mockRepository.Setup(x => x.BulkCreate(It.IsAny<IEnumerable<TestEntity>>(), It.IsAny<long>()))
                          .Returns(newGiven);
            var sut = new RepositoryCreateConductor<TestEntity>(mockRepository.Object);
            
            // Act
            var result = sut.BulkCreate(entities, currentUserId);
        
            // Assert
            result.ShouldNotHaveErrors();
            result.ResultObject.Count.ShouldBe(2);
        }
        
        #endregion

    }
}
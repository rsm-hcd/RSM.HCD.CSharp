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
using System.Threading.Tasks;

namespace AndcultureCode.CSharp.Conductors.Tests.RepositoryConductorTests
{
    public class BulkCreateAsyncShould : ProjectUnitTest
    {
        #region Setup

        public BulkCreateAsyncShould(ITestOutputHelper output) : base(output)
        {
        }

        private IRepositoryConductor<UserStub> SetupSut(
            IRepositoryMock<UserStub> repositoryMock
        )
        {
            var repositoryCreateConductor = new RepositoryCreateConductor<UserStub>(repositoryMock.Object);
            return new RepositoryConductor<UserStub>(
                createConductor: repositoryCreateConductor,
                deleteConductor: null,
                readConductor: null,
                updateConductor: null
            );
        }

        #endregion Setup

        [Fact]
        public async Task Throw_Argument_Null_Exception_When_Given_Null_Input()
        {
            // Arrange 
            var repositoryMock = new IRepositoryMock<UserStub>();
            var respositoryConductor = SetupSut(repositoryMock);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => respositoryConductor.BulkCreateAsync(null));
        }

        [Fact]
        public async Task Throw_Argument_Exception_When_Given_Empty_Input()
        {
            // Arrange 
            var repositoryMock = new IRepositoryMock<UserStub>();
            var respositoryConductor = SetupSut(repositoryMock);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => respositoryConductor.BulkCreateAsync(new List<UserStub>()));
        }

    }
}

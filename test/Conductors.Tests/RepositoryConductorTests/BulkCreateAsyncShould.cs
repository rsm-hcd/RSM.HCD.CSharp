using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AndcultureCode.CSharp.Core.Interfaces.Conductors;
using AndcultureCode.CSharp.Core.Models.Errors;
using AndcultureCode.CSharp.Testing.Models.Stubs;
using Xunit;
using Xunit.Abstractions;

namespace AndcultureCode.CSharp.Conductors.Tests.RepositoryConductorTests
{
    public class BulkCreateAsyncShould : ProjectUnitTest
    {
        public BulkCreateAsyncShould(ITestOutputHelper output) : base(output)
        {
        }

        private IRepositoryConductor<UserStub> SetupSut(
            RepositoryMock<UserStub> repositoryMock
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

        [Fact]
        public async Task Throw_Argument_Null_Exception_When_Given_Null_Input()
        {
            // Arrange 
            var repositoryMock = new RepositoryMock<UserStub>();
            var respositoryConductor = SetupSut(repositoryMock);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => respositoryConductor.BulkCreateAsync(null));
        }

        [Fact]
        public async Task Throw_Argument_Exception_When_Given_Empty_Input()
        {
            // Arrange 
            var repositoryMock = new RepositoryMock<UserStub>();
            var respositoryConductor = SetupSut(repositoryMock);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => respositoryConductor.BulkCreateAsync(new List<UserStub>()));
        }

        [Fact]
        public async Task Throw_OperationCanceledException_If_Canceled()
        {
            // Arrange 
            var repositoryMock = new RepositoryMock<UserStub>();
            var respositoryConductor = SetupSut(repositoryMock);
            var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();
            // Act & Assert
            await Assert.ThrowsAsync<OperationCanceledException>(() => respositoryConductor.BulkCreateAsync(new List<UserStub>(), 5, cancellationToken));
        }

        [Fact]
        public async Task Succeed_When_Given_Proper_Input()
        {
            // Arrange 
            var userId = 5;
            var userStubs = new List<UserStub>()
            {
                new UserStub() { Id = userId }
            };

            var repositoryMock = new RepositoryMock<UserStub>()
                .BulkCreateAsync(new Result<List<UserStub>>(userStubs));
            var respositoryConductor = SetupSut(repositoryMock);
            

            // Act
            var result = await respositoryConductor.BulkCreateAsync(userStubs);
            // Assert
            Assert.Contains(result.ResultObject, x => x.Id == userId);
        }
    }
}

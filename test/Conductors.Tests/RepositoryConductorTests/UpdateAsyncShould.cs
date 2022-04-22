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
    public class UpdateAsyncShould : ProjectUnitTest
    {
        public UpdateAsyncShould(ITestOutputHelper output) : base(output)
        {
        }

        private IRepositoryConductor<UserStub> SetupSut(
            RepositoryMock<UserStub> repositoryMock
        )
        {
            var repositoryUpdateConductor = new RepositoryUpdateConductor<UserStub>(repositoryMock.Object);
            return new RepositoryConductor<UserStub>(
                createConductor: null,
                deleteConductor: null,
                readConductor: null,
                updateConductor: repositoryUpdateConductor
            );
        }

        [Fact]
        public async Task Succeed_When_Given_Single_Object()
        {
            // Arrange 
            var repositoryMock = new RepositoryMock<UserStub>()
                .UpdateAsync(new Result<bool>(true));
            var respositoryConductor = SetupSut(repositoryMock);
            var userStub = new UserStub();

            // Act
            var result = await respositoryConductor.UpdateAsync(userStub);

            // Assert
            Assert.True(result.ResultObject);
        }

        [Fact]
        public async Task Throw_OperationCanceledException_If_Single_Object_Is_Canceled()
        {
            // Arrange 
            var repositoryMock = new RepositoryMock<UserStub>();
            var respositoryConductor = SetupSut(repositoryMock);
            var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act & Assert
            await Assert.ThrowsAsync<OperationCanceledException>(() => respositoryConductor.UpdateAsync(new UserStub(), 5, cancellationToken));
        }

        [Fact]
        public async Task Succeed_When_Given_Collection_Of_Objects()
        {
            // Arrange 
            var repositoryMock = new RepositoryMock<UserStub>()
                .UpdateAsync(new Result<bool>(true));
            var respositoryConductor = SetupSut(repositoryMock);
            var userStubs = new List<UserStub>()
            {
                new UserStub()
            };

            // Act
            var result = await respositoryConductor.UpdateAsync(userStubs);

            // Assert
            Assert.True(result.ResultObject);
        }

        [Fact]
        public async Task Throw_OperationCanceledException_If_Collection_Of_Objects_Is_Canceled()
        {
            // Arrange 
            var repositoryMock = new RepositoryMock<UserStub>();
            var respositoryConductor = SetupSut(repositoryMock);
            var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act & Assert
            await Assert.ThrowsAsync<OperationCanceledException>(() => respositoryConductor.UpdateAsync(new List<UserStub>(), 5, cancellationToken));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RSM.HCD.CSharp.Core.Interfaces.Conductors;
using RSM.HCD.CSharp.Core.Models.Errors;
using RSM.HCD.CSharp.Testing.Models.Stubs;
using Xunit;
using Xunit.Abstractions;

namespace RSM.HCD.CSharp.Conductors.Tests.RepositoryConductorTests
{
    public class DeleteAsyncShould : ProjectUnitTest
    {
        public DeleteAsyncShould(ITestOutputHelper output) : base(output)
        {
        }

        private IRepositoryConductor<UserStub> SetupSut(
            RepositoryMock<UserStub> repositoryMock
        )
        {
            var repositoryDeleteConductor = new RepositoryDeleteConductor<UserStub>(repositoryMock.Object);
            return new RepositoryConductor<UserStub>(
                createConductor: null,
                deleteConductor: repositoryDeleteConductor,
                readConductor: null,
                updateConductor: null
            );
        }

        [Fact]
        public async Task Succeed_When_Given_Proper_Id()
        {
            // Arrange
            var repositoryMock = new RepositoryMock<UserStub>()
                .DeleteAsync(new Result<bool>(true));
            var respositoryConductor = SetupSut(repositoryMock);


            // Act
            var result = await respositoryConductor.DeleteAsync(5);

            // Assert
            Assert.True(result.ResultObject);
        }

        [Fact]
        public async Task Throw_OperationCanceledException_If_Canceled_With_Valid_Id()
        {
            // Arrange
            var repositoryMock = new RepositoryMock<UserStub>();
            var respositoryConductor = SetupSut(repositoryMock);
            var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act & Assert
            await Assert.ThrowsAsync<OperationCanceledException>(() => respositoryConductor.DeleteAsync(5, 5, true, cancellationToken));
        }

        [Fact]
        public async Task Succeed_When_Given_Proper_Object()
        {
            // Arrange
            var repositoryMock = new RepositoryMock<UserStub>()
                .DeleteAsync(new Result<bool>(true));
            var respositoryConductor = SetupSut(repositoryMock);
            var userStub = new UserStub();

            // Act
            var result = await respositoryConductor.DeleteAsync(userStub);

            // Assert
            Assert.True(result.ResultObject);
        }

        [Fact]
        public async Task Throw_OperationCanceledException_If_Canceled_With_Valid_Object()
        {
            // Arrange
            var userStub = new UserStub();
            var repositoryMock = new RepositoryMock<UserStub>();
            var respositoryConductor = SetupSut(repositoryMock);
            var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act & Assert
            await Assert.ThrowsAsync<OperationCanceledException>(() => respositoryConductor.DeleteAsync(userStub, 5, true, cancellationToken));
        }

        [Fact]
        public async Task Succeed_When_Given_Proper_List_Of_Objects()
        {
            // Arrange
            var repositoryMock = new RepositoryMock<UserStub>()
                .DeleteAsync(new Result<bool>(true));
            var respositoryConductor = SetupSut(repositoryMock);
            var userStubs = new List<UserStub>() { new UserStub() };

            // Act
            var result = await respositoryConductor.DeleteAsync(userStubs);

            // Assert
            Assert.True(result.ResultObject);
        }

        [Fact]
        public async Task Throw_OperationCanceledException_If_Canceled_With_Valid_List_Of_Objects()
        {
            // Arrange
            var userStubs = new List<UserStub>() { new UserStub() };
            var repositoryMock = new RepositoryMock<UserStub>();
            var respositoryConductor = SetupSut(repositoryMock);
            var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();

            // Act & Assert
            await Assert.ThrowsAsync<OperationCanceledException>(() => respositoryConductor.DeleteAsync(userStubs, 5, 5, true, cancellationToken));
        }

    }
}

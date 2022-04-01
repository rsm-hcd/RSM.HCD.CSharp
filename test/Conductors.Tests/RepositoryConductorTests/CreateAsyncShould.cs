using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AndcultureCode.CSharp.Core.Interfaces.Conductors;
using AndcultureCode.CSharp.Testing.Models.Stubs;
using Xunit;
using Xunit.Abstractions;

namespace AndcultureCode.CSharp.Conductors.Tests.RepositoryConductorTests
{
    public class CreateAsyncShould : ProjectUnitTest
    {
        public CreateAsyncShould(ITestOutputHelper output) : base(output)
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
            UserStub userStub = null;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => respositoryConductor.CreateAsync(userStub));
        }

        [Fact]
        public async Task Throw_Argument_Null_Exception_When_Given_Null_List_Input()
        {
            // Arrange 
            var repositoryMock = new RepositoryMock<UserStub>();
            var respositoryConductor = SetupSut(repositoryMock);
            IEnumerable<UserStub> userStub = null;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => respositoryConductor.CreateAsync(userStub));
        }

        [Fact]
        public async Task Throw_Argument_Exception_When_Given_Empty_Input()
        {
            // Arrange 
            var repositoryMock = new RepositoryMock<UserStub>();
            var respositoryConductor = SetupSut(repositoryMock);
            IEnumerable<UserStub> userStubs = new List<UserStub>();

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => respositoryConductor.CreateAsync(userStubs));
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
            var userStub = new UserStub();
            // Act & Assert
            await Assert.ThrowsAsync<OperationCanceledException>(() => respositoryConductor.CreateAsync(userStub, 5, cancellationToken));
        }
    }
}

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
    public class RestoreAsyncShould : ProjectUnitTest
    {
        public RestoreAsyncShould(ITestOutputHelper output) : base(output)
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
        public async Task Succeed_When_Given_Proper_Input()
        {
            // Arrange
            var repositoryMock = new RepositoryMock<UserStub>()
                .RestoreAsync(new Result<bool>(true));
            var respositoryConductor = SetupSut(repositoryMock);

            // Act
            var result = await respositoryConductor.RestoreAsync(new UserStub());

            // Assert
            Assert.True(result.ResultObject);
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
            await Assert.ThrowsAsync<OperationCanceledException>(() => respositoryConductor.RestoreAsync(5, cancellationToken));
        }

    }
}

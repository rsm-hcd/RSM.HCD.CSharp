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
    public class BulkUpdateAsyncShould : ProjectUnitTest
    {
        public BulkUpdateAsyncShould(ITestOutputHelper output) : base(output)
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
        public async Task Succeed_When_Given_Proper_Input()
        {
            // Arrange 
            var repositoryMock = new RepositoryMock<UserStub>()
                .BulkUpdateAsync(new Result<bool>(true));
            var respositoryConductor = SetupSut(repositoryMock);
            var userStubs = new List<UserStub>()
            {
                new UserStub()
            };

            // Act
            var result = await respositoryConductor.BulkUpdateAsync(userStubs);

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
            await Assert.ThrowsAsync<OperationCanceledException>(() => respositoryConductor.BulkUpdateAsync(new List<UserStub>(), 5, cancellationToken));
        }
    }
}

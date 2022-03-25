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
    public class BulkCreateDistinctAsyncShould : ProjectUnitTest
    {
        public BulkCreateDistinctAsyncShould(ITestOutputHelper output) : base(output)
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

        [Fact]
        public async Task Throw_Stop_If_Canceled()
        {
            // Arrange 
            var repositoryMock = new IRepositoryMock<UserStub>();
            var respositoryConductor = SetupSut(repositoryMock);
            var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            cancellationTokenSource.Cancel();
            // Act & Assert
            await Assert.ThrowsAsync<OperationCanceledException>(() => respositoryConductor.BulkCreateAsync(new List<UserStub>(), 5, cancellationToken));
        }
    }
}

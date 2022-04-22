using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Core.Interfaces.Data;
using AndcultureCode.CSharp.Core.Interfaces.Entity;
using Moq;

namespace AndcultureCode.CSharp.Conductors.Tests.RepositoryConductorTests
{
    internal sealed class RepositoryMock<T> : Mock<IRepository<T>>
        where T : class, IEntity
    {
        public RepositoryMock<T> BulkCreateAsync(IResult<List<T>> output)
        {
            Setup(x => x.BulkCreateAsync(It.IsAny<IEnumerable<T>>(), null, It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(output));
            return this;
        }

        public RepositoryMock<T> BulkDeleteAsync(IResult<bool> output)
        {
            Setup(x => x.BulkDeleteAsync(It.IsAny<IEnumerable<T>>(), It.IsAny<long?>(), It.IsAny<bool>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(output));
            return this;
        }

        public RepositoryMock<T> DeleteAsync(IResult<bool> output)
        {
            Setup(x => x.DeleteAsync(It.IsAny<long>(), It.IsAny<long?>(), It.IsAny<bool>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(output));
            Setup(x => x.DeleteAsync(It.IsAny<IEnumerable<T>>(), It.IsAny<long?>(), It.IsAny<long>(), It.IsAny<bool>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(output));
            Setup(x => x.DeleteAsync(It.IsAny<T>(), It.IsAny<long?>(), It.IsAny<bool>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(output));
            return this;
        }

        public RepositoryMock<T> RestoreAsync(IResult<bool> output)
        {
            Setup(x => x.RestoreAsync(It.IsAny<T>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(output));
            Setup(x => x.RestoreAsync(It.IsAny<long>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(output));
            return this;
        }

        public RepositoryMock<T> BulkUpdateAsync(IResult<bool> output)
        {
            Setup(x => x.BulkUpdateAsync(It.IsAny<IEnumerable<T>>(), It.IsAny<long?>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(output));
            return this;
        }

        public RepositoryMock<T> UpdateAsync(IResult<bool> output)
        {
            Setup(x => x.UpdateAsync(It.IsAny<IEnumerable<T>>(), It.IsAny<long?>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(output));
            Setup(x => x.UpdateAsync(It.IsAny<T>(), It.IsAny<long?>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(output));
            return this;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AndcultureCode.CSharp.Core.Interfaces;
using AndcultureCode.CSharp.Core.Interfaces.Conductors;
using AndcultureCode.CSharp.Core.Interfaces.Data;
using AndcultureCode.CSharp.Core.Interfaces.Entity;
using Moq;

namespace AndcultureCode.CSharp.Conductors.Tests.RepositoryConductorTests
{


    internal sealed class IRepositoryMock<T> : Mock<IRepository<T>>
        where T : class, IEntity
    {
        public IRepositoryMock<T> BulkCreateAsync(IResult<List<T>> output, Action<long> callback)
        {
            Setup(x => x.BulkCreateAsync(It.IsAny<IEnumerable<T>>(), null))
                .Returns(Task.FromResult(output));
            return this;
        }
    }
}

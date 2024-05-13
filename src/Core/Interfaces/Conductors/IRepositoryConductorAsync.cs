using System;
using System.Collections.Generic;
using System.Text;

namespace RSM.HCD.CSharp.Core.Interfaces.Conductors
{
    public partial interface IRepositoryConductor<T> : IConductor,
        IRepositoryCreateConductor<T>,
        IRepositoryDeleteConductor<T>,
        IRepositoryReadConductor<T>,
        IRepositoryUpdateConductor<T>
    where T : Models.Entities.Entity
    {

    }
}

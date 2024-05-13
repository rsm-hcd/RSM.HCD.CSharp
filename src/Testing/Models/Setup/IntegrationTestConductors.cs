using RSM.HCD.CSharp.Core.Interfaces.Conductors;
using RSM.HCD.CSharp.Core.Interfaces.Data;
using RSM.HCD.CSharp.Core.Models.Entities;

namespace RSM.HCD.CSharp.Testing.Models.Setup
{
    public class IntegrationTestConductors<T> where T : Entity
    {
        public IRepositoryConductor<T> Conductor { get; set; }
        public IRepositoryCreateConductor<T> Create { get; set; }
        public IRepositoryDeleteConductor<T> Delete { get; set; }
        public IRepositoryReadConductor<T> Read { get; set; }
        public IRepository<T> Repository { get; set; }
        public IRepositoryUpdateConductor<T> Update { get; set; }
    }
}

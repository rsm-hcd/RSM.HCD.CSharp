using AndcultureCode.CSharp.Core.Interfaces.Conductors;
using AndcultureCode.CSharp.Core.Interfaces.Data;
using AndcultureCode.CSharp.Core.Models.Entities;

namespace AndcultureCode.CSharp.Testing.Models.Setup
{
    public class IntegrationTestConductors<T> where T : Entity
    {
        public IRepositoryConductor<T>       Conductor  { get; set; }
        public IRepositoryCreateConductor<T> Create     { get; set; }
        public IRepositoryDeleteConductor<T> Delete     { get; set; }
        public IRepositoryReadConductor<T>   Read       { get; set; }
        public IRepository<T>                Repository { get; set; }
        public IRepositoryUpdateConductor<T> Update     { get; set; }
    }
}
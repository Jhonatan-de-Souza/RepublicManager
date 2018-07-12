using RepublicManager.Api.Core.Domain;
using RepublicManager.Api.Core.Repositories;

namespace RepublicManager.Api.Persistance.Repositories
{
    public class ContaAReceberRepositorio : RepositorioBase<ContaAReceber>, IContaAReceberRepositorio
    {
        public ContaAReceberRepositorio(RepublicManagerContext republicManagerContext) : base(republicManagerContext)
        {
        }
    }
}
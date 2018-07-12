using RepublicManager.Api.Core.Domain;
using RepublicManager.Api.Core.Repositories;

namespace RepublicManager.Api.Persistance.Repositories
{
    public class ContaAPagarRepositorio : RepositorioBase<ContaAPagar>, IContaAPagarRepositorio
    {
        public ContaAPagarRepositorio(RepublicManagerContext republicManagerContext) : base(republicManagerContext)
        {
        }
    }
}
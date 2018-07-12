using RepublicManager.Api.Core.Domain;
using RepublicManager.Api.Core.Repositories;

namespace RepublicManager.Api.Persistance.Repositories
{
    public class RegraRepositorio : RepositorioBase<Regra>, IRegraRepositorio
    {
        public RegraRepositorio(RepublicManagerContext republicManagerContext) : base(republicManagerContext)
        {
        }
    }
}

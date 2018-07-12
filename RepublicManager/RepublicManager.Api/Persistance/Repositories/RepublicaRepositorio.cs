using RepublicManager.Api.Core.Domain;
using RepublicManager.Api.Core.Repositories;

namespace RepublicManager.Api.Persistance.Repositories
{
    public class RepublicaRepositorio : RepositorioBase<Republica>, IRepublicaRepositorio
    {
        public RepublicaRepositorio(RepublicManagerContext republicManagerContext) : base(republicManagerContext)
        {
        }

       
    }
}
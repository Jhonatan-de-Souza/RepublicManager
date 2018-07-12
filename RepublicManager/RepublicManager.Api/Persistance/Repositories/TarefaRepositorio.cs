using RepublicManager.Api.Core.Domain;
using RepublicManager.Api.Core.Repositories;

namespace RepublicManager.Api.Persistance.Repositories
{
    public class TarefaRepositorio : RepositorioBase<Tarefa>, ITarefaRepositorio
    {
        public TarefaRepositorio(RepublicManagerContext republicManagerContext) : base(republicManagerContext)
        {
        }
    }
}

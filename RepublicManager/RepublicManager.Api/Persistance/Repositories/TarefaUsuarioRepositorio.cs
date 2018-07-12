using RepublicManager.Api.Core.Domain;
using RepublicManager.Api.Core.Repositories;

namespace RepublicManager.Api.Persistance.Repositories
{
    public class TarefaUsuarioRepositorio : RepositorioBase<TarefaUsuario>, ITarefaUsuarioRepositorio
    {
        public TarefaUsuarioRepositorio(RepublicManagerContext republicManagerContext) : base(republicManagerContext)
        {
        }
    }
}
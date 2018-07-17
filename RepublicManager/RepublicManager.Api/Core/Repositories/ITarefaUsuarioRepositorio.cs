using System.Collections.Generic;
using System.Threading.Tasks;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Core.Repositories
{
    public interface ITarefaUsuarioRepositorio : IRepositorioBase<TarefaUsuario>
    {
        Task<IEnumerable<TarefaUsuario>> GetAllWithTarefaEUsuarioAsync();
        Task<TarefaUsuario> GetByIdWithTarefaEUsuarioAsync(int id);
    }
}

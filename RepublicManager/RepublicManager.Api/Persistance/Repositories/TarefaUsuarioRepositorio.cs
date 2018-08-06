using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepublicManager.Api.Core.Domain;
using RepublicManager.Api.Core.Repositories;

namespace RepublicManager.Api.Persistance.Repositories
{
    public class TarefaUsuarioRepositorio : RepositorioBase<TarefaUsuario>, ITarefaUsuarioRepositorio
    {
        private readonly RepublicManagerContext _republicManagerContext;
        public TarefaUsuarioRepositorio(RepublicManagerContext republicManagerContext) : base(republicManagerContext)
        {
            _republicManagerContext = republicManagerContext;
        }

        public async Task<IEnumerable<TarefaUsuario>> GetAllWithTarefaEUsuarioAsync()
        {
            return await _republicManagerContext.TarefasUsuario
                .Include(x => x.Tarefa)
                .Include(x => x.Usuario).ToListAsync();
        }

        public async Task<TarefaUsuario> GetByIdWithTarefaEUsuarioAsync(int id,int id2)
        {
            return await _republicManagerContext.TarefasUsuario
                .Where(x => x.TarefaId == id && x.UsuarioId == id2)
                .Include(x => x.Tarefa).Include(x => x.Usuario).FirstOrDefaultAsync();
        }
    }
}
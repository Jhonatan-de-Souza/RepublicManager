using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepublicManager.Api.Core.Domain;
using RepublicManager.Api.Core.Repositories;

namespace RepublicManager.Api.Persistance.Repositories
{
    public class UsuarioRepositorio : RepositorioBase<Usuario>,IUsuarioRepositorio
    {
        private readonly RepublicManagerContext _republicManagerContext;

        public UsuarioRepositorio(RepublicManagerContext republicManagerContext) : base(republicManagerContext)
        {
            _republicManagerContext = republicManagerContext;
        }

        public async Task<IEnumerable<Usuario>> GetallTEste()
        {
            return await _republicManagerContext.Usuario.Include(x => x.Conta).ThenInclude(x => x.ContasAPagar).ThenInclude(x => x.TipoConta).ToListAsync();
        }
    }
}

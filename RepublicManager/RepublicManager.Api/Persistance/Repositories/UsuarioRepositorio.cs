using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<Usuario>> GetAllUsuarioWithAllInformation()
        {
            return await _republicManagerContext.Usuario
                .Include(x => x.Conta)
                    .ThenInclude(x => x.ContasAPagar)
                        .ThenInclude(x => x.TipoConta)
                .Include(x => x.Conta)
                    .ThenInclude(x => x.ContasAReceber)
                        .ThenInclude(x => x.TipoConta)
                .OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<Usuario> GetByIdUsuarioWithAllInformation(int id)
        {
            return await _republicManagerContext.Usuario
                .Include(x => x.Conta)
                    .ThenInclude(x => x.ContasAPagar)
                        .ThenInclude(x => x.TipoConta)
                .Include(x => x.Conta)
                    .ThenInclude(x => x.ContasAReceber)
                        .ThenInclude(x => x.TipoConta)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepublicManager.Api.Core.Domain;
using RepublicManager.Api.Core.Repositories;

namespace RepublicManager.Api.Persistance.Repositories
{
    public class RegraRepositorio : RepositorioBase<Regra>, IRegraRepositorio
    {
        private readonly RepublicManagerContext _republicManagerContext;

        public RegraRepositorio(RepublicManagerContext republicManagerContext) : base(republicManagerContext)
        {
            _republicManagerContext = republicManagerContext;
        }

        public async Task<IEnumerable<Regra>> GetRegraWithRepublica()
        {
            return await _republicManagerContext.Regras.Include(x => x.Republica).ToListAsync();
        }
    }
}

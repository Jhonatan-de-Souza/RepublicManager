using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepublicManager.Api.Core.Domain;
using RepublicManager.Api.Core.Repositories;

namespace RepublicManager.Api.Persistance.Repositories
{
    public class ContaAReceberRepositorio : RepositorioBase<ContaAReceber>, IContaAReceberRepositorio
    {
        private readonly RepublicManagerContext _republicManagerContext;
        public ContaAReceberRepositorio(RepublicManagerContext republicManagerContext) : base(republicManagerContext)
        {
            _republicManagerContext = republicManagerContext;
        }

        public async Task<IEnumerable<ContaAReceber>> GetAllWithTipoContaAsync()
        {
            return await _republicManagerContext.ContasAReceber
                .Include(x => x.TipoConta)
                .ToListAsync();
        }

        public async Task<ContaAReceber> GetByIdWithTipoContaAsync(int id)
        {
            return await _republicManagerContext.ContasAReceber
                .Where(x => x.Id == id)
                .Include(x => x.TipoConta)
                .FirstOrDefaultAsync();
        }
    }
}
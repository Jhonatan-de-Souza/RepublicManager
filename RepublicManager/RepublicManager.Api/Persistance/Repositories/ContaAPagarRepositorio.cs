using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepublicManager.Api.Core.Domain;
using RepublicManager.Api.Core.Repositories;

namespace RepublicManager.Api.Persistance.Repositories
{
    public class ContaAPagarRepositorio : RepositorioBase<ContaAPagar>, IContaAPagarRepositorio
    {
        private readonly RepublicManagerContext _republicManagerContext;
        public ContaAPagarRepositorio(RepublicManagerContext republicManagerContext) : base(republicManagerContext)
        {
            _republicManagerContext = republicManagerContext;
        }

        public async Task<IEnumerable<ContaAPagar>> GetAllWithTipoContaAsync()
        {
            return await _republicManagerContext.ContasAPagar
                .Include(x => x.TipoConta)
                .ToListAsync();
        }

        public async Task<ContaAPagar> GetByIdWithTipoContaAsync(int id)
        {
            return await _republicManagerContext.ContasAPagar
                .Where(x => x.Id == id)
                .Include(x => x.TipoConta)
                .FirstOrDefaultAsync();
        }
    }
}
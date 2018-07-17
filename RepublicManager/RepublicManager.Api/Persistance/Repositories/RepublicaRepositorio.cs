using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepublicManager.Api.Core.Domain;
using RepublicManager.Api.Core.Repositories;

namespace RepublicManager.Api.Persistance.Repositories
{
    public class RepublicaRepositorio : RepositorioBase<Republica>, IRepublicaRepositorio
    {
        private readonly RepublicManagerContext _republicManagerContext;

        public RepublicaRepositorio(RepublicManagerContext republicManagerContext) : base(republicManagerContext)
        {
            _republicManagerContext = republicManagerContext;
        }

        public async Task<Republica> GetByIdWithRegrasEUsuariosEAvisosECarrinhosDeCompraAsync(int id)
        {
            return await _republicManagerContext.Republica
                .Where(x => x.Id == id)
                .Include(x => x.Regras)
                .Include(x => x.Usuarios)
                .Include(x => x.Avisos)
                .Include(x => x.CarrinhosDeCompra).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Republica>> GetRepublicaWithRegrasEUsuariosEAvisosECarrinhosDeCompraAsync()
        {
            return await _republicManagerContext.Republica
                .Include(x => x.Regras)
                .Include(x => x.Usuarios)
                .Include(x => x.Avisos)
                .Include(x => x.CarrinhosDeCompra).ToListAsync();
            
        }

        public Task<IEnumerable<Republica>> GetRepublicaWithRegrasEuariosECarriAvisosEUsnhosDeCompraAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
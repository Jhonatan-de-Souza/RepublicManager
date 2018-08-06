using System.Collections.Generic;
using System.Threading.Tasks;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Core.Repositories
{
    public interface IRepublicaRepositorio : IRepositorioBase<Republica>
    {
        Task<IEnumerable<Republica>> GetRepublicaWithRegrasEUsuariosEAvisosECarrinhosDeCompraAsync();
        Task<Republica> GetByIdWithRegrasEUsuariosEAvisosECarrinhosDeCompraAsync(int id);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Core.Repositories
{
    public interface IContaAPagarRepositorio : IRepositorioBase<ContaAPagar>
    {
        Task<IEnumerable<ContaAPagar>> GetAllWithTipoContaAsync();
        Task<ContaAPagar> GetByIdWithTipoContaAsync(int id);
    }
}

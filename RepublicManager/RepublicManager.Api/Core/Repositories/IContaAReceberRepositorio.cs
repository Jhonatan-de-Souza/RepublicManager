using System.Collections.Generic;
using System.Threading.Tasks;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Core.Repositories
{
    public interface IContaAReceberRepositorio : IRepositorioBase<ContaAReceber>
    {
        Task<IEnumerable<ContaAReceber>> GetAllWithTipoContaAsync();
        Task<ContaAReceber> GetByIdWithTipoContaAsync(int id);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Core.Repositories
{
    public interface IContaRepositorio : IRepositorioBase<Conta>
    {
        Task<IEnumerable<Conta>> GetAllContaWithPagarEReceber();
        Task<Conta> GetByIdContaWithPagarEReceber(int id);
    }
}

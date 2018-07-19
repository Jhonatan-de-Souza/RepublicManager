using System.Collections.Generic;
using System.Threading.Tasks;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Core.Repositories
{
    public interface IUsuarioRepositorio : IRepositorioBase<Usuario>
    {

        Task<IEnumerable<Usuario>> GetallTEste();
    }


}

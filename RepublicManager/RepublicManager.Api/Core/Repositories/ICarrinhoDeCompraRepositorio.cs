using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Core.Repositories
{
    public interface ICarrinhoDeCompraRepositorio : IRepositorioBase<CarrinhoDeCompra>
    {
        Task<IEnumerable<CarrinhoDeCompra>> GetCarrinhoWithProdutosAsync();
        void teste();
    }
}

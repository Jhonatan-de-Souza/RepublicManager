using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepublicManager.Api.Core.Domain;
using RepublicManager.Api.Core.Repositories;

namespace RepublicManager.Api.Persistance.Repositories
{
    public class CarrinhoDeCompraRepositorio : RepositorioBase<CarrinhoDeCompra>,ICarrinhoDeCompraRepositorio
    {
        private readonly RepublicManagerContext _republicManagerContext;

        public CarrinhoDeCompraRepositorio(RepublicManagerContext republicManagerContext) : base(republicManagerContext)
        {
            _republicManagerContext = republicManagerContext;
        }


        public async Task<IEnumerable<CarrinhoDeCompra>> GetAllWithProdutosAsync()
        {
            return  await _republicManagerContext.CarrinhoDeCompra.Include(x => x.Produtos).ToListAsync();
                
        }

        public async Task<CarrinhoDeCompra> GetByIdWithProdutosAsync(int id)
        {
            return await _republicManagerContext.CarrinhoDeCompra
                .Where(x => x.Id == id)
                .Include(x => x.Produtos).FirstOrDefaultAsync();
        }
    }
}


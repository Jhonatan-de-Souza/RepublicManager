using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepublicManager.Api.Core.Domain;
using RepublicManager.Api.Core.Repositories;

namespace RepublicManager.Api.Persistance.Repositories
{
    public class CarrinhoDeCompraRepositorio : RepositorioBase<CarrinhoDeCompra>,ICarrinhoDeCompraRepositorio
    {
        public CarrinhoDeCompraRepositorio(RepublicManagerContext republicManagerContext) : base(republicManagerContext)
        {
        }
    }
}

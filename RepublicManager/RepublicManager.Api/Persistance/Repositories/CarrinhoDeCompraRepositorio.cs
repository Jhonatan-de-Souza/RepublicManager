using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using RepublicManager.Api.Core.Domain;
using RepublicManager.Api.Core.Repositories;

namespace RepublicManager.Api.Persistance.Repositories
{
    public class CarrinhoDeCompraRepositorio : RepositorioBase<CarrinhoDeCompra>,ICarrinhoDeCompraRepositorio
    {
        private readonly RepublicManagerContext _republicManagerContext;

        public CarrinhoDeCompraRepositorio(RepublicManagerContext republicManagerContext) : base(republicManagerContext)
        {
        }

        public Task<IEnumerable<CarrinhoDeCompra>> GetCarrinhoWithProdutosAsync()
        {
            
        }

        public void teste()
        {
            throw new NotImplementedException();
        }
    }
}

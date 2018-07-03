using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepublicManager.Api.Core.Repositories;

namespace RepublicManager.Api.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IRepublicaRepositorio Republicas { get; }
        IProdutoRepositorio Produtos { get; }
        ICarrinhoDeCompraRepositorio CarrinhoDeCompras { get; }
        IAvisoRepositorio AvisoRepositorio { get; }
        Task CompleteAsync();
    }
}

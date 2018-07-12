using System;
using System.Threading.Tasks;
using RepublicManager.Api.Core.Repositories;

namespace RepublicManager.Api.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IRepublicaRepositorio Republicas { get; }
        IProdutoRepositorio Produtos { get; }
        ICarrinhoDeCompraRepositorio CarrinhoDeCompras { get; }
        IAvisoRepositorio Avisos { get; }
        IUsuarioRepositorio Usuarios { get; }
        IRegraRepositorio Regras { get; }
        ITarefaRepositorio Tarefas { get; }
        ITarefaUsuarioRepositorio TarefasUsuario { get; }
        IContaRepositorio ContaRepositorio { get; }
        IContaAPagarRepositorio ContaAPagarRepositorio { get; }
        IContaAReceberRepositorio ContaAReceberRepositorio { get; }
        ITipoContaRepositorio TipoContaRepositorio { get; }
        Task CompleteAsync();
    }
}

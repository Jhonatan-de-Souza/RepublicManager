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
        IContaRepositorio Contas { get; }
        IContaAPagarRepositorio ContasAPagar { get; }
        IContaAReceberRepositorio ContasAReceber { get; }
        ITipoContaRepositorio TipoContas { get; }
        IUserRepositorio Users { get; }
        Task CompleteAsync();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepublicManager.Api.Core;
using RepublicManager.Api.Core.Repositories;
using RepublicManager.Api.Persistance.Repositories;

namespace RepublicManager.Api.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RepublicManagerContext _context;

        //The repositories used in the application must be set here , Example Below
        public IRepublicaRepositorio Republicas { get; set; }
        public IProdutoRepositorio Produtos { get; set; }
        public ICarrinhoDeCompraRepositorio CarrinhoDeCompras { get; set; }
        public IAvisoRepositorio Avisos { get; set; }
        public IUsuarioRepositorio Usuarios { get; set; }
        public IRegraRepositorio Regras { get; set; }
        public ITarefaRepositorio Tarefas { get; set; }
        public ITarefaUsuarioRepositorio TarefasUsuario { get; set; }
        //public  Type { get; set; }

        //here the unit of work will instaniate the repositories and use it across all of the application
        public UnitOfWork(RepublicManagerContext context)
        {
            _context = context;
            //Example Below
            Republicas = new RepublicaRepositorio(_context);
            Produtos = new ProdutoRepositorio(_context);
            CarrinhoDeCompras = new CarrinhoDeCompraRepositorio(_context);
            Usuarios = new UsuarioRepositorio(_context);
            Avisos = new AvisoRepositorio(_context);
            Regras = new RegraRepositorio(_context);
            Tarefas = new TarefaRepositorio(_context);


        }
        public async  Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RepublicManager.Api.Core;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ProdutoController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;


        public ProdutoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<Produto> GetAll()
        {
            return _unitOfWork.Produtos.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _unitOfWork.Produtos.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Produto item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _unitOfWork.Produtos.Add(item);
            _unitOfWork.Complete();

            /*O método CreatedAtRoute retorna a resposta 201, a qual é a resposta padrão para
             um método HTTP POST que cria um novo recurso no servidor. CreatedAtRoute também 
             adiciona um cabeçalho Location ao response, que especifica a URI do novo item tarefa 
             recem criado. (Consulte 10.2.2 201 */

            return CreatedAtRoute(new { id = item.Id }, item);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Produto item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var produto = _unitOfWork.Produtos.Find(id);
            if (produto == null)
            {
                return NotFound();
            }

            produto.Descricao = item.Descricao;
            produto.Valor = item.Valor;
            produto.CarrinhoDeCompraId = item.CarrinhoDeCompraId;
            produto.UsuarioId = item.UsuarioId;

            produto.CriadoPor = item.CriadoPor;
            produto.DataRegistro = item.DataRegistro;
            produto.isAtivo = item.isAtivo;

            _unitOfWork.Produtos.Update(produto);
            _unitOfWork.Complete();
            return new NoContentResult();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var produto = _unitOfWork.Produtos.Find(id);
            if (produto == null)
            {
                return NotFound();
            }

            _unitOfWork.Produtos.Remove(id);
            _unitOfWork.Complete();
            return new NoContentResult();
        }
    }
}
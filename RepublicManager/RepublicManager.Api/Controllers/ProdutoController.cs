using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RepublicManager.Api.Core;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Controllers
{
    [Route("api/[controller]")]
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

        [HttpGet("{id}", Name = "GetTarefa")]
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

            return CreatedAtRoute("GetTarefa", new { id = item.ProdutoId }, item);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Produto item)
        {
            if (item == null || item.ProdutoId != id)
            {
                return BadRequest();
            }

            var Produto = _unitOfWork.Produtos.Find(id);
            if (Produto == null)
            {
                return NotFound();
            }

            Produto.Descricao = item.Descricao;
            Produto.Valor = item.Valor;
            Produto.CarrinhoDeCompraId = item.CarrinhoDeCompraId;
            Produto.UsuarioId = item.UsuarioId;

            _unitOfWork.Produtos.Update(Produto);
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
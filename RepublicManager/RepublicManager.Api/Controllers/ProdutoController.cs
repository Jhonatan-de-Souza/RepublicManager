using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RepublicManager.Api.Core;
using RepublicManager.Api.Core.Domain;
using RepublicManager.Api.Helpers;

namespace RepublicManager.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ProdutoController : Controller
    {


        private readonly IUnitOfWork _unitOfWork;


        public ProdutoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/Avisoz
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var produtos = await _unitOfWork.Produtos.GetAllAsync();
            if (produtos == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(produtos);
            }
        }

        // GET: api/produto/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var produto = await _unitOfWork.Produtos.GetByIdAsync(id);
            return Ok(produto);
        }

        //POST: api/produto
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Produto produto)
        {
            if (produto == null)
            {
                return NotFound();
            }
            try
            {
                if (ModelState.IsValid)
                    _unitOfWork.Produtos.Add(produto);
                await _unitOfWork.CompleteAsync();

                return Ok(produto);
            }
            catch (Exception exception)
            {
                logError.LogErrorWithSentry(exception);
                return BadRequest();
            }

        }
        // PUT: api/produto/5
        /*[HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody]Produto Produto)
        {
            try
            {
                var produtoEdit = await _unitOfWork.Produtos.GetByIdAsync(id);

                if (ModelState.IsValid)
                    produtoEdit = produto;
                await _unitOfWork.CompleteAsync();

                return Ok(produto);
            }
            catch (Exception e)
            {
                logError.LogErrorWithSentry(e);
                return BadRequest();
            }
        }*/

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var produto = await _unitOfWork.Produtos.GetByIdAsync(id);
                if (produto != null)
                    produto.isAtivo = false;
                await _unitOfWork.CompleteAsync();
                return Ok(produto);
            }
            catch (Exception e)
            {
                logError.LogErrorWithSentry(e);
                return BadRequest();
            }
        }
    }
}
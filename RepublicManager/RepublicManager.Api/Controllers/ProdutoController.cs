using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepublicManager.Api.Core;
using RepublicManager.Api.Core.Domain;
using RepublicManager.Api.Core.Resources;
using RepublicManager.Api.Helpers;

namespace RepublicManager.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    public class ProdutoController : Controller
    {


        private readonly IUnitOfWork _unitOfWork;


        public ProdutoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/Produtoz
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var produtos = await _unitOfWork.Produtos.GetAllAsync();
            List<ProdutoResource> produtoResource = new List<ProdutoResource>();

            if (produtos == null)
            {
                return NoContent();
            }
            foreach (var produto in produtos)
            {
                if (produto.IsAtivo == true)
                {
                    produtoResource.Add(ProdutoMapper.ModelToResource(produto));
                }
            }
            return Ok(produtoResource);
        }
        // GET: api/Produto/5

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var produto = await _unitOfWork.Produtos.GetByIdAsync(id);
            if (produto.IsAtivo == true)
            {
                return Ok(ProdutoMapper.ModelToResource(produto));
            }
            else
            {
                return NoContent();
            }
        }

        //POST: api/Produto
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]ProdutoResource produtoResource)
        {
            if (produtoResource == null)
            {
                return NotFound();
            }
            try
            {
                var produto = new Produto();
                if (ModelState.IsValid)
                    produto = ProdutoMapper.ResourceToModel(produtoResource,produto);
                _unitOfWork.Produtos.Add(produto);


                //var carrinhoDeCompra = await _unitOfWork.CarrinhoDeCompras.GetByIdAsync(produto.CarrinhoDeCompraId);
                //CarrinhoDeCompraMapper
                //    .ResourceToModel(CarrinhoDeCompraMapper.ModelToResource(carrinhoDeCompra), carrinhoDeCompra);
               
                await _unitOfWork.CompleteAsync();

                return Ok(produto);
            }
            catch (Exception exception)
            {
                LogError.LogErrorWithSentry(exception);
                return BadRequest();
            }

        }
        // PUT: api/Produto/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody]ProdutoResource produtoResource)
        {
            try
            {
                var produto = await _unitOfWork.Produtos.GetByIdAsync(id);

                if (ModelState.IsValid)
                {
                   
                    produto = ProdutoMapper.ResourceToModel(produtoResource,produto);
                    await _unitOfWork.CompleteAsync();
                    ProdutoMapper.ModelToResource(produto);
                }
                return Ok(produto);
            }
            catch (Exception e)
            {
                LogError.LogErrorWithSentry(e);
                return BadRequest(ModelState);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var produto = await _unitOfWork.Produtos.GetByIdAsync(id);
                if (produto != null)
                    produto.IsAtivo = false;
                await _unitOfWork.CompleteAsync();
                return Ok(produto);
            }
            catch (Exception e)
            {
                LogError.LogErrorWithSentry(e);
                return BadRequest();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RepublicManager.Api.Core;
using RepublicManager.Api.Core.Domain;
using RepublicManager.Api.Core.Resources;
using RepublicManager.Api.Helpers;

namespace RepublicManager.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CarrinhoDeCompraController : Controller
    {


        private readonly IUnitOfWork _unitOfWork;


        public CarrinhoDeCompraController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/CarrinhoDeCompraz
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var carrinhoDeCompras = await _unitOfWork.CarrinhoDeCompras.GetAllWithProdutosAsync();
                List<CarrinhoDeCompraResource> carrinhoDeCompraResource = new List<CarrinhoDeCompraResource>();

            if (carrinhoDeCompras == null)
            {
                return NoContent();
            }

            foreach (var carrinhoDeCompra in carrinhoDeCompras)
            {
                if (carrinhoDeCompra.IsAtivo)
                {
                    carrinhoDeCompraResource.Add(CarrinhoDeCompraMapper.ModelToResource(carrinhoDeCompra));
                }
            }

            return Ok(carrinhoDeCompraResource);
                }
            catch (Exception exception)
            {
                LogError.LogErrorWithSentry(exception);
                return BadRequest();
            }
        }

        
        // GET: api/CarrinhoDeCompra/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var carrinhoDeCompra = await _unitOfWork.CarrinhoDeCompras.GetByIdWithProdutosAsync(id);
            if (carrinhoDeCompra.IsAtivo)
            {
                return Ok(CarrinhoDeCompraMapper.ModelToResource(carrinhoDeCompra));
            }

            return NoContent();
        }

        //POST: api/CarrinhoDeCompra
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CarrinhoDeCompraResource carrinhoDeCompraResource)
        {
            if (carrinhoDeCompraResource == null)
            {
                return NotFound();
            }
            try
            {
                var carrinhoDeCompra = new CarrinhoDeCompra();
                if (ModelState.IsValid)
                    carrinhoDeCompra = CarrinhoDeCompraMapper.ResourceToModel(carrinhoDeCompraResource,carrinhoDeCompra);
                _unitOfWork.CarrinhoDeCompras.Add(carrinhoDeCompra);
                await _unitOfWork.CompleteAsync();

                return Ok(carrinhoDeCompra);
            }
            catch (Exception exception)
            {
                LogError.LogErrorWithSentry(exception);
                return BadRequest();
            }

        }
        // PUT: api/CarrinhoDeCompra/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody]CarrinhoDeCompraResource carrinhoDeCompraResource)
        {
            try
            {
                var carrinhoDeCompra = await _unitOfWork.CarrinhoDeCompras.GetByIdAsync(id);

                if (ModelState.IsValid)
                {
                    
                    carrinhoDeCompra = CarrinhoDeCompraMapper.ResourceToModel(carrinhoDeCompraResource,carrinhoDeCompra);
                    await _unitOfWork.CompleteAsync();
                    CarrinhoDeCompraMapper.ModelToResource(carrinhoDeCompra);
                }
                return Ok(carrinhoDeCompra);
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
                var carrinhoDeCompra = await _unitOfWork.CarrinhoDeCompras.GetByIdAsync(id);
                if (carrinhoDeCompra != null)
                    carrinhoDeCompra.IsAtivo = false;
                await _unitOfWork.CompleteAsync();
                return Ok(carrinhoDeCompra);
            }
            catch (Exception e)
            {
                LogError.LogErrorWithSentry(e);
                return BadRequest();
            }
        }
    }
}

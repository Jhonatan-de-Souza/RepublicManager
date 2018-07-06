using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RepublicManager.Api.Core;
using RepublicManager.Api.Core.Domain;
using RepublicManager.Api.Helpers;
using RepublicManager.Api.Resources;

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
            var carrinhoDeCompras = await _unitOfWork.CarrinhoDeCompras.GetAllAsync();
            List<CarrinhoDeCompraResource> carrinhoDeCompraResource = new List<CarrinhoDeCompraResource>();

            if (carrinhoDeCompras == null)
            {
                return NoContent();
            }
            foreach (var carrinhoDeCompra in carrinhoDeCompras)
            {
                carrinhoDeCompraResource.Add(CarrinhoDeCompraMapper.ModelToResource(carrinhoDeCompra));
            }
            return Ok(carrinhoDeCompraResource);
        }

        // GET: api/CarrinhoDeCompra/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var carrinhoDeCompra = await _unitOfWork.CarrinhoDeCompras.GetByIdAsync(id);
            return Ok(CarrinhoDeCompraMapper.ModelToResource(carrinhoDeCompra));
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
                    carrinhoDeCompra = CarrinhoDeCompraMapper.ResourceToModel(carrinhoDeCompraResource);
                _unitOfWork.CarrinhoDeCompras.Add(carrinhoDeCompra);
                await _unitOfWork.CompleteAsync();

                return Ok(carrinhoDeCompra);
            }
            catch (Exception exception)
            {
                logError.LogErrorWithSentry(exception);
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
                    _unitOfWork.CarrinhoDeCompras.SetModifiedState(carrinhoDeCompra);
                    carrinhoDeCompra = CarrinhoDeCompraMapper.ResourceToModel(carrinhoDeCompraResource);
                    await _unitOfWork.CompleteAsync();
                    CarrinhoDeCompraMapper.ModelToResource(carrinhoDeCompra);
                }
                return Ok(carrinhoDeCompra);
            }
            catch (Exception e)
            {
                logError.LogErrorWithSentry(e);
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
                    carrinhoDeCompra.isAtivo = false;
                await _unitOfWork.CompleteAsync();
                return Ok(carrinhoDeCompra);
            }
            catch (Exception e)
            {
                logError.LogErrorWithSentry(e);
                return BadRequest();
            }
        }
    }
}

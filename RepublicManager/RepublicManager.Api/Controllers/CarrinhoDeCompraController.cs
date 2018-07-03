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
    public class CarrinhoDeCompraController : Controller
    {


        private readonly IUnitOfWork _unitOfWork;


        public CarrinhoDeCompraController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/Avisoz
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var carrinhoDeCompras = await _unitOfWork.CarrinhoDeCompras.GetAllAsync();
            if (carrinhoDeCompras == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(carrinhoDeCompras);
            }
        }

        // GET: api/Aviso/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var aviso = await _unitOfWork.CarrinhoDeCompras.GetByIdAsync(id);
            return Ok(aviso);
        }

        //POST: api/Aviso
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CarrinhoDeCompra carrinhoDeCompra)
        {
            if (carrinhoDeCompra == null)
            {
                return NotFound();
            }
            try
            {
                if (ModelState.IsValid)
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
        // PUT: api/Aviso/5
        /*[HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody]CarrinhoDeCompra carrinhoDeCompra)
        {
            try
            {
                var carrinhoDeCompraEdit = await _unitOfWork.CarrinhoDeCompras.GetByIdAsync(id);

                if (ModelState.IsValid)
                    carrinhoDeCompraEdit = carrinhoDeCompra;
                await _unitOfWork.CompleteAsync();

                return Ok(carrinhoDeCompra);
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
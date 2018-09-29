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
    public class TipoContaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TipoContaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/TipoContaz
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tipoContas = await _unitOfWork.TipoContas.GetAllAsync();
            List<TipoContaResource> tipoContaResource = new List<TipoContaResource>();

            if (tipoContas == null)
            {
                return NoContent();
            }
            foreach (var tipoConta in tipoContas)
            {
                tipoContaResource.Add(TipoContaMapper.ModelToResource(tipoConta));
            }
            return Ok(tipoContaResource);
        }

        // GET: api/TipoConta/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            var tipoConta = await _unitOfWork.TipoContas.GetByIdAsync(id);
            if (tipoConta == null)
            {
                return NotFound();
            }
            return Ok(TipoContaMapper.ModelToResource(tipoConta));
        }

        //POST: api/TipoConta
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]TipoContaResource tipoContaResource)
        {
            if (tipoContaResource == null)
            {
                return NotFound();
            }
            try
            {
                var tipoConta = new TipoConta();
                if (ModelState.IsValid)
                    tipoConta = TipoContaMapper.ResourceToModel(tipoContaResource, tipoConta);
                _unitOfWork.TipoContas.Add(tipoConta);
                await _unitOfWork.CompleteAsync();

                return Ok(tipoConta);
            }
            catch (Exception exception)
            {
                LogError.LogErrorWithSentry(exception);
                return BadRequest();
            }

        }
        // PUT: api/TipoConta/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody]TipoContaResource tipoContaResource)
        {
            try
            {
                var tipoConta = await _unitOfWork.TipoContas.GetByIdAsync(id);

                if (ModelState.IsValid)
                {
                    tipoConta = TipoContaMapper.ResourceToModel(tipoContaResource, tipoConta);
                    await _unitOfWork.CompleteAsync();
                    TipoContaMapper.ModelToResource(tipoConta);
                }
                return Ok(tipoConta);
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
                var tipoConta = await _unitOfWork.TipoContas.GetByIdAsync(id);
                if (tipoConta != null)
                    tipoConta.IsAtivo = false;
                await _unitOfWork.CompleteAsync();
                return Ok(tipoConta);
            }
            catch (Exception e)
            {
                LogError.LogErrorWithSentry(e);
                return BadRequest();
            }
        }
    }
}

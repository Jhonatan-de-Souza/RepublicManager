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
    public class ContaAPagarController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContaAPagarController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/ContasAPagarz
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var contasAPagars = await _unitOfWork.ContasAPagar.GetAllWithTipoContaAsync();
            List<ContaAPagarResource> contasAPagarResource = new List<ContaAPagarResource>();

            if (contasAPagars == null)
            {
                return NoContent();
            }
            foreach (var contasAPagar in contasAPagars)
            {
                contasAPagarResource.Add(ContaAPagarMapper.ModelToResource(contasAPagar));
            }
            return Ok(contasAPagarResource);
        }

        // GET: api/ContasAPagar/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            var contasAPagar = await _unitOfWork.ContasAPagar.GetByIdWithTipoContaAsync(id);
            if (contasAPagar == null)
            {
                return NotFound();
            }
            return Ok(ContaAPagarMapper.ModelToResource(contasAPagar));
        }

        //POST: api/ContasAPagar
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]ContaAPagarResource contasAPagarResource)
        {
            if (contasAPagarResource == null)
            {
                return NotFound();
            }
            try
            {
                var contasAPagar = new ContaAPagar();
                if (ModelState.IsValid)
                    contasAPagar = ContaAPagarMapper.ResourceToModel(contasAPagarResource, contasAPagar);
                _unitOfWork.ContasAPagar.Add(contasAPagar);
                await _unitOfWork.CompleteAsync();

                return Ok(contasAPagar);
            }
            catch (Exception exception)
            {
                LogError.LogErrorWithSentry(exception);
                return BadRequest();
            }

        }
        // PUT: api/ContasAPagar/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody]ContaAPagarResource contasAPagarResource)
        {
            try
            {
                var contasAPagar = await _unitOfWork.ContasAPagar.GetByIdAsync(id);

                if (ModelState.IsValid)
                {
                    contasAPagar = ContaAPagarMapper.ResourceToModel(contasAPagarResource, contasAPagar);
                    await _unitOfWork.CompleteAsync();

                    contasAPagar.TipoConta = await _unitOfWork.TipoContas.GetByIdAsync(contasAPagar.TipoContaId);
                    ContaAPagarMapper.ModelToResource(contasAPagar);
                }
                return Ok(contasAPagar);
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
                var contasAPagar = await _unitOfWork.ContasAPagar.GetByIdAsync(id);
                if (contasAPagar != null)
                    contasAPagar.IsAtivo = false;
                await _unitOfWork.CompleteAsync();
                return Ok(contasAPagar);
            }
            catch (Exception e)
            {
                LogError.LogErrorWithSentry(e);
                return BadRequest();
            }
        }
    }
}

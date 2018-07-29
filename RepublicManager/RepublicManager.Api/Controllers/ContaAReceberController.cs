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
    public class ContaAReceberController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContaAReceberController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/ContaAReceberz
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var contaARecebers = await _unitOfWork.ContasAReceber.GetAllWithTipoContaAsync();
            List<ContaAReceberResource> contaAReceberResource = new List<ContaAReceberResource>();

            if (contaARecebers == null)
            {
                return NoContent();
            }
            foreach (var contaAReceber in contaARecebers)
            {
                contaAReceberResource.Add(ContaAReceberMapper.ModelToResource(contaAReceber));
            }
            return Ok(contaAReceberResource);
        }

        // GET: api/ContaAReceber/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            var contaAReceber = await _unitOfWork.ContasAReceber.GetByIdWithTipoContaAsync(id);
            if (contaAReceber == null)
            {
                return NotFound();
            }
            return Ok(ContaAReceberMapper.ModelToResource(contaAReceber));
        }

        //POST: api/ContaAReceber
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]ContaAReceberResource contaAReceberResource)
        {
            if (contaAReceberResource == null)
            {
                return NotFound();
            }
            try
            {
                var contaAReceber = new ContaAReceber();
                if (ModelState.IsValid)
                    contaAReceber = ContaAReceberMapper.ResourceToModel(contaAReceberResource, contaAReceber);
                _unitOfWork.ContasAReceber.Add(contaAReceber);
                await _unitOfWork.CompleteAsync();

                return Ok(contaAReceber);
            }
            catch (Exception exception)
            {
                LogError.LogErrorWithSentry(exception);
                return BadRequest();
            }

        }
        // PUT: api/ContaAReceber/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody]ContaAReceberResource contaAReceberResource)
        {
            try
            {
                var contaAReceber = await _unitOfWork.ContasAReceber.GetByIdAsync(id);

                if (ModelState.IsValid)
                {
                    contaAReceber = ContaAReceberMapper.ResourceToModel(contaAReceberResource, contaAReceber);
                    await _unitOfWork.CompleteAsync();
                    contaAReceber.TipoConta = await _unitOfWork.TipoContas.GetByIdAsync(contaAReceber.TipoContaId);
                    ContaAReceberMapper.ModelToResource(contaAReceber);
                }
                return Ok(contaAReceber);
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
                var contaAReceber = await _unitOfWork.ContasAReceber.GetByIdAsync(id);
                if (contaAReceber != null)
                    contaAReceber.IsAtivo = false;
                await _unitOfWork.CompleteAsync();
                return Ok(contaAReceber);
            }
            catch (Exception e)
            {
                LogError.LogErrorWithSentry(e);
                return BadRequest();
            }
        }
    }
}

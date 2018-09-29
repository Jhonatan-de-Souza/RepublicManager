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
    public class ContaController : Controller
    {


        private readonly IUnitOfWork _unitOfWork;


        public ContaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/Contaz
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var contas = await _unitOfWork.Contas.GetAllContaWithPagarEReceberEUsuario();
                List<ContaResource> contaResource = new List<ContaResource>();

                if (contas == null)
                {
                    return NoContent();
                }

                foreach (var conta in contas)
                {
                    if (conta.IsAtivo)
                    {
                        contaResource.Add(ContaMapper.ModelToResource(conta));
                    }
                }

                return Ok(contaResource);
            }
            catch (Exception exception)
            {
                LogError.LogErrorWithSentry(exception);
                return BadRequest();
            }
        }


        // GET: api/Conta/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var conta = await _unitOfWork.Contas.GetByIdContaWithPagarEReceber(id);
            if (conta.IsAtivo)
            {
                return Ok(ContaMapper.ModelToResource(conta));
            }

            return NoContent();
        }

        //POST: api/Conta
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]ContaResource contaResource)
        {
            if (contaResource == null)
            {
                return NotFound();
            }
            try
            {
                var conta = new Conta();
                if (ModelState.IsValid)
                    conta = ContaMapper.ResourceToModel(contaResource, conta);
                _unitOfWork.Contas.Add(conta);
                await _unitOfWork.CompleteAsync();

                Usuario u = await _unitOfWork.Usuarios.GetByIdAsync(conta.UsuarioId);
                u.ContaId = conta.Id;
                _unitOfWork.Usuarios.Update(u);
                await _unitOfWork.CompleteAsync();

                ContaMapper.ModelToResource(conta);
                
                return Ok(conta);
            }
            catch (Exception exception)
            {
                LogError.LogErrorWithSentry(exception);
                return BadRequest();
            }

        }
        // PUT: api/Conta/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody]ContaResource contaResource)
        {
            try
            {
                var conta = await _unitOfWork.Contas.GetByIdAsync(id);

                if (ModelState.IsValid)
                {

                    conta = ContaMapper.ResourceToModel(contaResource, conta);
                    await _unitOfWork.CompleteAsync();
                    ContaMapper.ModelToResource(conta);
                }
                return Ok(conta);
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
                var conta = await _unitOfWork.Contas.GetByIdAsync(id);
                if (conta != null)
                    conta.IsAtivo = false;
                await _unitOfWork.CompleteAsync();
                return Ok(conta);
            }
            catch (Exception e)
            {
                LogError.LogErrorWithSentry(e);
                return BadRequest();
            }
        }
    }
}

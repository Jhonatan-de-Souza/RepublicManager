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
    public class RegraController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegraController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Regraz
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regras = await _unitOfWork.Regras.GetAllAsync();
            List<RegraResource> regraResource = new List<RegraResource>();

            if (regras == null)
            {
                return NoContent();
            }
            foreach (var regra in regras)
            {
                if (regra.IsAtivo == true)
                {
                    regraResource.Add(RegraMapper.ModelToResource(regra));
                }
            }
            return Ok(regraResource);
        }

        // GET: api/Regra/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var regra = await _unitOfWork.Regras.GetByIdAsync(id);
            if (regra.IsAtivo == true)
            {
                return Ok(RegraMapper.ModelToResource(regra));
            }
            else
            {
                return NoContent();
            }

        }

        //POST: api/Regra
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]RegraResource regraResource)
        {
            if (regraResource == null)
            {
                return NotFound();
            }
            try
            {
                var regra = new Regra();
                if (ModelState.IsValid)
                    regra = RegraMapper.ResourceToModel(regraResource, regra);
                _unitOfWork.Regras.Add(regra);
                await _unitOfWork.CompleteAsync();

                return Ok(regra);
            }
            catch (Exception exception)
            {
                LogError.LogErrorWithSentry(exception);
                return BadRequest();
            }

        }
        // PUT: api/Regra/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody]RegraResource regraResource)
        {
            try
            {
                var regra = await _unitOfWork.Regras.GetByIdAsync(id);

                if (ModelState.IsValid)
                {
                    regra = RegraMapper.ResourceToModel(regraResource, regra);
                    await _unitOfWork.CompleteAsync();
                    RegraMapper.ModelToResource(regra);
                }
                return Ok(regra);
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
                var regra = await _unitOfWork.Regras.GetByIdAsync(id);
                if (regra != null)
                    regra.IsAtivo = false;
                await _unitOfWork.CompleteAsync();
                return Ok(regra);
            }
            catch (Exception e)
            {
                LogError.LogErrorWithSentry(e);
                return BadRequest();
            }
        }
    }
}

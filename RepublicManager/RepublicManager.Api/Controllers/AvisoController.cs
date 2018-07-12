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
    public class AvisoController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AvisoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
       
        // GET: api/Avisoz
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var avisos =  await _unitOfWork.Avisos.GetAllAsync();
            List<AvisoResource> avisoResource = new List<AvisoResource>();

            if (avisos == null)
            {
                return NoContent();
            }
            foreach (var aviso in avisos)
            {
                avisoResource.Add(AvisoMapper.ModelToResource(aviso));
            }
            return Ok(avisoResource);
        }

        // GET: api/Aviso/5
        [HttpGet("{id}")]
        public async Task<IActionResult>Get(int id)
        {
            
            var aviso = await _unitOfWork.Avisos.GetByIdAsync(id);
            if (aviso == null)
            {
                return NotFound();
            }
            return Ok(AvisoMapper.ModelToResource(aviso));
        }

        //POST: api/Aviso
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]AvisoResource avisoResource)
        {
            if (avisoResource == null)
            {
                return NotFound();
            }
            try
            {
                var aviso = new Aviso();
                if (ModelState.IsValid)
                    aviso = AvisoMapper.ResourceToModel(avisoResource,aviso);
                    _unitOfWork.Avisos.Add(aviso);
                    await _unitOfWork.CompleteAsync();

                    return Ok(aviso);
            }
            catch (Exception exception)
            {
                LogError.LogErrorWithSentry(exception);
                return BadRequest();
            }
           
        }
        // PUT: api/Aviso/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody]AvisoResource avisoResource)
        {
            try
            {
                var aviso = await _unitOfWork.Avisos.GetByIdAsync(id);

                if (ModelState.IsValid)
                {
                    aviso = AvisoMapper.ResourceToModel(avisoResource,aviso);
                    await _unitOfWork.CompleteAsync();
                    AvisoMapper.ModelToResource(aviso);
                }
                return Ok(aviso);
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
                var aviso = await _unitOfWork.Avisos.GetByIdAsync(id);
                if (aviso != null)
                    aviso.IsAtivo = false;
                    await _unitOfWork.CompleteAsync();
                    return Ok(aviso);
            }
            catch (Exception e)
            {
                LogError.LogErrorWithSentry(e);
                return BadRequest();
            }
        }
    }
}

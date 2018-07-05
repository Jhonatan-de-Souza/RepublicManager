using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepublicManager.Api.Core;
using RepublicManager.Api.Core.Domain;
using RepublicManager.Api.Helpers;
using RepublicManager.Api.Resources;
using RepublicManager.Api.Resources.Mapping;
using SharpRaven;
using SharpRaven.Data;

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
            else
            {
                foreach (var aviso in avisos)
                {
                    avisoResource.Add(ConvertModelToResource.AvisoToAvisoResource(aviso));
                }
                return Ok(avisoResource);
            }
        }

        // GET: api/Aviso/5
        [HttpGet("{id}")]
        public async Task<IActionResult>Get(int id)
        {
            var aviso = await _unitOfWork.Avisos.GetByIdAsync(id);
            var avisoResource = new AvisoResource()
            {
                Descricao = aviso.Descricao,
                DataAviso = aviso.DataAviso,
                isAtivo = aviso.isAtivo,
                Id = aviso.Id,
                CriadoPor = aviso.CriadoPor,
                DataRegistro = aviso.DataRegistro
            };

            
            return Ok(avisoResource);
        }

        //POST: api/Aviso
       [HttpPost]
        public async Task<IActionResult> Create([FromBody]Aviso aviso)
        {
            if (aviso == null)
            {
                return NotFound();
            }
            try
            {
                if (ModelState.IsValid)
                    _unitOfWork.Avisos.Add(aviso);
                    await _unitOfWork.CompleteAsync();

                    return Ok(aviso);
            }
            catch (Exception exception)
            {
                logError.LogErrorWithSentry(exception);
                return BadRequest();
            }
           
        }
        // PUT: api/Aviso/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody]Aviso aviso)
        {
            try
            {
                var avisoToEdit = await _unitOfWork.Avisos.GetByIdAsync(id);
                //_unitOfWork.Avisos.SetModifiedState(avisoToEdit);

                if (ModelState.IsValid)
                    avisoToEdit.Descricao = aviso.Descricao;
                    //avisoToEdit = aviso;
                    await _unitOfWork.CompleteAsync();

                    return Ok(avisoToEdit);
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
                var aviso = await _unitOfWork.Avisos.GetByIdAsync(id);
                if (aviso != null)
                    aviso.isAtivo = false;
                    await _unitOfWork.CompleteAsync();
                    return Ok(aviso);
            }
            catch (Exception e)
            {
                logError.LogErrorWithSentry(e);
                return BadRequest();
            }
        }
    }
}

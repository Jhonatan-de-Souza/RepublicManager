using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepublicManager.Api.Core;
using RepublicManager.Api.Core.Domain;

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
            var avisos =  await _unitOfWork.AvisoRepositorio.GetAllAsync();
            return Ok(avisos);
        }

        // GET: api/Aviso/5
        [HttpGet("{id}")]
        public async Task<IActionResult>Get(int id)
        {
            var aviso = await _unitOfWork.AvisoRepositorio.GetByIdAsync(id);
            return Ok(aviso);
        }

        //POST: api/Aviso
       [HttpPost]
        public async Task<IActionResult> Create([FromBody]Aviso aviso)
        {
            if (aviso == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.AvisoRepositorio.Add(aviso);
                await _unitOfWork.CompleteAsync();
                return Ok(aviso);
            }
            else
            {
                return BadRequest();
            }
        }


        // PUT: api/Aviso/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody]Aviso aviso)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.CompleteAsync();
                return Ok(aviso);
            }
            else
            {
                return BadRequest();
            }
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var aviso = await _unitOfWork.AvisoRepositorio.GetByIdAsync(id);
            if (aviso != null)
            {
                aviso.isAtivo = false;
                await _unitOfWork.CompleteAsync();
                return Ok(aviso);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

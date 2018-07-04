﻿using System;
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
    public class RepublicaController : Controller
    {


        private readonly IUnitOfWork _unitOfWork;


        public RepublicaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/Avisoz
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var republicas = await _unitOfWork.Republicas.GetAllAsync();
            if (republicas == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(republicas);
            }
        }

        // GET: api/produto/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var republica = await _unitOfWork.Republicas.GetByIdAsync(id);
            return Ok(republica);
        }

        //POST: api/produto
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Republica republica)
        {
            if (republica == null)
            {
                return NotFound();
            }
            try
            {
                if (ModelState.IsValid)
                    _unitOfWork.Republicas.Add(republica);
                await _unitOfWork.CompleteAsync();

                return Ok(republica);
            }
            catch (Exception exception)
            {
                logError.LogErrorWithSentry(exception);
                return BadRequest();
            }

        }
        // PUT: api/produto/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody]Republica entity)
        {
            try
            {
                var republica = _unitOfWork.Republicas.GetByIdAsync(id);
                
                await _unitOfWork.Republicas.SaveEntity(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(entity);
        }

       

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var republica = await _unitOfWork.Republicas.GetByIdAsync(id);
                if (republica != null)
                    republica.isAtivo = false;
                await _unitOfWork.CompleteAsync();
                return Ok(republica);
            }
            catch (Exception e)
            {
                logError.LogErrorWithSentry(e);
                return BadRequest();
            }
        }
    }
}
 
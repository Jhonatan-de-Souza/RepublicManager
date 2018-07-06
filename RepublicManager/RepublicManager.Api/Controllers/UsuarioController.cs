﻿using System;
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
    public class UsuarioController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Usuarioz
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var usuarios = await _unitOfWork.Usuarios.GetAllAsync();
            List<UsuarioResource> usuarioResource = new List<UsuarioResource>();

            if (usuarios == null)
            {
                return NoContent();
            }
            foreach (var usuario in usuarios)
            {
                if (usuario.isAtivo == true)
                {
                    usuarioResource.Add(UsuarioMapper.ModelToResource(usuario));
                }
            }
            return Ok(usuarioResource);
        }

        // GET: api/Usuario/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var usuario = await _unitOfWork.Usuarios.GetByIdAsync(id);
            if (usuario.isAtivo == true)
            {
                return Ok(UsuarioMapper.ModelToResource(usuario));
            }
            else
            {
                return NoContent();
            }
        }

        //POST: api/Usuario
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]UsuarioResource usuarioResource)
        {
            if (usuarioResource == null)
            {
                return NotFound();
            }
            try
            {
                var usuario = new Usuario();
                if (ModelState.IsValid)
                    usuario = UsuarioMapper.ResourceToModel(usuarioResource, usuario);
                _unitOfWork.Usuarios.Add(usuario);
                await _unitOfWork.CompleteAsync();

                return Ok(usuario);
            }
            catch (Exception exception)
            {
                logError.LogErrorWithSentry(exception);
                return BadRequest();
            }

        }
        // PUT: api/Usuario/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody]UsuarioResource usuarioResource)
        {
            try
            {
                var usuario = await _unitOfWork.Usuarios.GetByIdAsync(id);

                if (ModelState.IsValid)
                {
                    usuario = UsuarioMapper.ResourceToModel(usuarioResource, usuario);
                    await _unitOfWork.CompleteAsync();
                    UsuarioMapper.ModelToResource(usuario);
                }
                return Ok(usuario);
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
                var usuario = await _unitOfWork.Usuarios.GetByIdAsync(id);
                if (usuario != null)
                    usuario.isAtivo = false;
                await _unitOfWork.CompleteAsync();
                return Ok(usuario);
            }
            catch (Exception e)
            {
                logError.LogErrorWithSentry(e);
                return BadRequest();
            }
        }
    }
}
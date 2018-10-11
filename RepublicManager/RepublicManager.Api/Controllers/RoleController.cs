using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using RepublicManager.Api.Core;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Produces("application/json")]
    [Authorize]
    [Route("api/[controller]")]
    public class RoleController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _unitOfWork.Roles.GetAllAsync();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var role = await _unitOfWork.Roles.GetByIdAsync(id);
            return Ok(role);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Role role)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Roles.Add(role);
                await _unitOfWork.CompleteAsync();
                return Ok(role);
            }

            return BadRequest("Objeto enviado está imcompleto ou incorreto");

        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody]Role role)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Roles.Update(role);
                await _unitOfWork.CompleteAsync();
                return Ok(role);
            }

            return BadRequest("Objeto enviado está imcompleto ou incorreto");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var role = await _unitOfWork.Roles.GetByIdAsync(id);
            if (role != null)
            {
                _unitOfWork.Roles.Remove(role.Id);
                await _unitOfWork.CompleteAsync();
                return Ok("Objeto Excluido com sucesso!");
            }

            return Ok("Essa Permissão não está cadastrada no sistema.");
        }
}
}
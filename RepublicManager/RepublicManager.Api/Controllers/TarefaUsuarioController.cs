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
    public class TarefaUsuarioController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TarefaUsuarioController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/TarefaUsuarioz
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tarefaUsuarios = await _unitOfWork.TarefasUsuario.GetAllAsync();
            List<TarefaUsuarioResource> tarefaUsuarioResource = new List<TarefaUsuarioResource>();

            if (tarefaUsuarios == null)
            {
                return NoContent();
            }
            foreach (var tarefaUsuario in tarefaUsuarios)
            {
                tarefaUsuarioResource.Add(TarefaUsuarioMapper.ModelToResource(tarefaUsuario));
            }
            return Ok(tarefaUsuarioResource);
        }

        // GET: api/TarefaUsuario/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var tarefaUsuario = await _unitOfWork.TarefasUsuario.GetByIdAsync(id);
            return Ok(TarefaUsuarioMapper.ModelToResource(tarefaUsuario));
        }

        //POST: api/TarefaUsuario
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]TarefaUsuarioResource tarefaUsuarioResource)
        {
            if (tarefaUsuarioResource == null)
            {
                return NotFound();
            }
            try
            {
                var tarefaUsuario = new TarefaUsuario();
                if (ModelState.IsValid)
                    tarefaUsuario = TarefaUsuarioMapper.ResourceToModel(tarefaUsuarioResource, tarefaUsuario);
                _unitOfWork.TarefasUsuario.Add(tarefaUsuario);
                await _unitOfWork.CompleteAsync();

                return Ok(tarefaUsuario);
            }
            catch (Exception exception)
            {
                LogError.LogErrorWithSentry(exception);
                return BadRequest();
            }

        }
        // PUT: api/TarefaUsuario/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody]TarefaUsuarioResource tarefaUsuarioResource)
        {
            try
            {
                var tarefaUsuario = await _unitOfWork.TarefasUsuario.GetByIdAsync(id);

                if (ModelState.IsValid)
                {
                    tarefaUsuario = TarefaUsuarioMapper.ResourceToModel(tarefaUsuarioResource, tarefaUsuario);
                    await _unitOfWork.CompleteAsync();
                    TarefaUsuarioMapper.ModelToResource(tarefaUsuario);
                }
                return Ok(tarefaUsuario);
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
                var tarefaUsuario = await _unitOfWork.TarefasUsuario.GetByIdAsync(id);
                if (tarefaUsuario != null)
                    tarefaUsuario.IsAtivo = false;
                await _unitOfWork.CompleteAsync();
                return Ok(tarefaUsuario);
            }
            catch (Exception e)
            {
                LogError.LogErrorWithSentry(e);
                return BadRequest();
            }
        }
    }
}

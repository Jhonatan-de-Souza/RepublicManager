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
    public class TarefaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TarefaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Tarefaz
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tarefas = await _unitOfWork.Tarefas.GetAllAsync();
            List<TarefaResource> tarefaResource = new List<TarefaResource>();

            if (tarefas == null)
            {
                return NoContent();
            }
            foreach (var tarefa in tarefas)
            {
                tarefaResource.Add(TarefaMapper.ModelToResource(tarefa));
            }
            return Ok(tarefaResource);
        }

        // GET: api/Tarefa/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var tarefa = await _unitOfWork.Tarefas.GetByIdAsync(id);
            return Ok(TarefaMapper.ModelToResource(tarefa));
        }

        //POST: api/Tarefa
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]TarefaResource tarefaResource)
        {
            if (tarefaResource == null)
            {
                return NotFound();
            }
            try
            {
                var tarefa = new Tarefa();
                if (ModelState.IsValid)
                    tarefa = TarefaMapper.ResourceToModel(tarefaResource, tarefa);
                _unitOfWork.Tarefas.Add(tarefa);
                await _unitOfWork.CompleteAsync();

                return Ok(tarefa);
            }
            catch (Exception exception)
            {
                LogError.LogErrorWithSentry(exception);
                return BadRequest();
            }

        }
        // PUT: api/Tarefa/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody]TarefaResource tarefaResource)
        {
            try
            {
                var tarefa = await _unitOfWork.Tarefas.GetByIdAsync(id);

                if (ModelState.IsValid)
                {
                    tarefa = TarefaMapper.ResourceToModel(tarefaResource, tarefa);
                    await _unitOfWork.CompleteAsync();
                    TarefaMapper.ModelToResource(tarefa);
                }
                return Ok(tarefa);
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
                var tarefa = await _unitOfWork.Tarefas.GetByIdAsync(id);
                if (tarefa != null)
                    tarefa.IsAtivo = false;
                await _unitOfWork.CompleteAsync();
                return Ok(tarefa);
            }
            catch (Exception e)
            {
                LogError.LogErrorWithSentry(e);
                return BadRequest();
            }
        }
    }
}

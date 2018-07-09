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
    public class RepublicaController : Controller
    {


        private readonly IUnitOfWork _unitOfWork;


        public RepublicaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/republicaz
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var republicas = await _unitOfWork.Republicas.GetAllAsync();
            List<RepublicaResource> repbiblicaResource = new List<RepublicaResource>();

            if (republicas == null)
            {
                return NoContent();
            }
            foreach (var republica in republicas)
            {
                if (republica.IsAtivo == true)
                {
                    repbiblicaResource.Add(RepublicaMapper.ModelToResource(republica));
                }
            }
            return Ok(repbiblicaResource);

        }

        // GET: api/produto/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var republica = await _unitOfWork.Republicas.GetByIdAsync(id);
            if (republica.IsAtivo == true)
            {
                return Ok(RepublicaMapper.ModelToResource(republica));
            }
            else
            {
                return NoContent();
            }
        }

        //POST: api/produto
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]RepublicaResource republicaResource)
        {
            if (republicaResource == null)
            {
                return NotFound();
            }
            try
            {
                var republica = new Republica();
                if (ModelState.IsValid)
                    republica = RepublicaMapper.ResourceToModel(republicaResource,republica);
                _unitOfWork.Republicas.Add(republica);
                await _unitOfWork.CompleteAsync();

                return Ok(republica);
            }
            catch (Exception exception)
            {
                LogError.LogErrorWithSentry(exception);
                return BadRequest();
            }

        }
        // PUT: api/Republica/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody]RepublicaResource republicaResource)
        {
            try
            {
                var republica = await _unitOfWork.Republicas.GetByIdAsync(id);

                if (ModelState.IsValid)
                {
                   
                    republica = RepublicaMapper.ResourceToModel(republicaResource,republica);
                    await _unitOfWork.CompleteAsync();
                    RepublicaMapper.ModelToResource(republica);

                   
                }
                return Ok(republica);
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
                var republica = await _unitOfWork.Republicas.GetByIdAsync(id);
                if (republica != null)
                    republica.IsAtivo = false;
                await _unitOfWork.CompleteAsync();
                return Ok(republica);
            }
            catch (Exception e)
            {
                LogError.LogErrorWithSentry(e);
                return BadRequest();
            }
        }
    }
}

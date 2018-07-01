using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RepublicManager.Api.Core;
using RepublicManager.Api.Core.Domain;
using RepublicManager.Api.Core.Repositories;

namespace RepublicManager.Api.Controllers
{
    [Route("api/[controller]")]
    public class RepublicaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;


        public RepublicaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<Republica> GetAll()
        {
            return _unitOfWork.Republicas.GetAll();
        }

        [HttpGet("{id}", Name = "GetTarefa")]
        public IActionResult GetById(int id)
        {
            var item = _unitOfWork.Republicas.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Republica item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _unitOfWork.Republicas.Add(item);
            _unitOfWork.Complete();

            /*O método CreatedAtRoute retorna a resposta 201, a qual é a resposta padrão para
             um método HTTP POST que cria um novo recurso no servidor. CreatedAtRoute também 
             adiciona um cabeçalho Location ao response, que especifica a URI do novo item tarefa 
             recem criado. (Consulte 10.2.2 201 */

            return CreatedAtRoute("GetTarefa", new { id = item.RepublicaId }, item);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Republica item)
        {
            if (item == null || item.RepublicaId != id)
            {
                return BadRequest();
            }

            var republica = _unitOfWork.Republicas.Find(id);
            if (republica == null)
            {
                return NotFound();
            }

            republica.Nome = item.Nome;
            republica.Vagas = item.Vagas;

            _unitOfWork.Republicas.Update(republica);
            _unitOfWork.Complete();
            return new NoContentResult();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var republica = _unitOfWork.Republicas.Find(id);
            if (republica == null)
            {
                return NotFound();
            }

            _unitOfWork.Republicas.Remove(id);
            _unitOfWork.Complete();
            return new NoContentResult();
        }
    }
}
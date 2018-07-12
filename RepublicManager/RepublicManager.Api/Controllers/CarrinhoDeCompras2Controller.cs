using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepublicManager.Api.Core.Domain;
using RepublicManager.Api.Persistance;

namespace RepublicManager.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/CarrinhoDeCompras2")]
    public class CarrinhoDeCompras2Controller : Controller
    {
        private readonly RepublicManagerContext _context;

        public CarrinhoDeCompras2Controller(RepublicManagerContext context)
        {
            _context = context;
        }

        // GET: api/CarrinhoDeCompras2
        [HttpGet]
        public OkObjectResult GetCarrinhoDeCompra()
        {
            var test = _context.CarrinhoDeCompra.Include(x => x.Produtos).ToList();
            return Ok(test);
        }

        // GET: api/CarrinhoDeCompras2/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarrinhoDeCompra([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var carrinhoDeCompra = await _context.CarrinhoDeCompra.SingleOrDefaultAsync(m => m.Id == id);

            if (carrinhoDeCompra == null)
            {
                return NotFound();
            }

            return Ok(carrinhoDeCompra);
        }

        // PUT: api/CarrinhoDeCompras2/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarrinhoDeCompra([FromRoute] int id, [FromBody] CarrinhoDeCompra carrinhoDeCompra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != carrinhoDeCompra.Id)
            {
                return BadRequest();
            }

            _context.Entry(carrinhoDeCompra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarrinhoDeCompraExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CarrinhoDeCompras2
        [HttpPost]
        public async Task<IActionResult> PostCarrinhoDeCompra([FromBody] CarrinhoDeCompra carrinhoDeCompra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CarrinhoDeCompra.Add(carrinhoDeCompra);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarrinhoDeCompra", new { id = carrinhoDeCompra.Id }, carrinhoDeCompra);
        }

        // DELETE: api/CarrinhoDeCompras2/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarrinhoDeCompra([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var carrinhoDeCompra = await _context.CarrinhoDeCompra.SingleOrDefaultAsync(m => m.Id == id);
            if (carrinhoDeCompra == null)
            {
                return NotFound();
            }

            _context.CarrinhoDeCompra.Remove(carrinhoDeCompra);
            await _context.SaveChangesAsync();

            return Ok(carrinhoDeCompra);
        }

        private bool CarrinhoDeCompraExists(int id)
        {
            return _context.CarrinhoDeCompra.Any(e => e.Id == id);
        }
    }
}
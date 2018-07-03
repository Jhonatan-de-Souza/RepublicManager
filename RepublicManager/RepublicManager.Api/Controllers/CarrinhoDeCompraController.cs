//using System.Collections.Generic;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using RepublicManager.Api.Core;
//using RepublicManager.Api.Core.Domain;

//namespace RepublicManager.Api.Controllers
//{
//    [Route("api/[controller]")]
//    public class CarrinhoDeCompraController : Controller
//    {


//        private readonly IUnitOfWork _unitOfWork;


//        public CarrinhoDeCompraController(IUnitOfWork unitOfWork)
//        {
//            _unitOfWork = unitOfWork;
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetAll()
//        {
//            var carrinhoDeCompras = await _unitOfWork.CarrinhoDeCompras.GetAllAsync();
//            return Ok(carrinhoDeCompras);
//        }

//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetById(int id)
//        {
//            var carrinhoDeCompra = await _unitOfWork.CarrinhoDeCompras.GetByIdAsync(id);
//            if (carrinhoDeCompra == null)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                return Ok(carrinhoDeCompra);
//            }
//            else
//            {
//                return BadRequest();
//            }
//        }

//        [HttpPost]
//        public async Task<IActionResult> Create([FromBody] CarrinhoDeCompra carrinhoDeCompra)
//        {
//            if (carrinhoDeCompra == null)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                _unitOfWork.CarrinhoDeCompras.Add(carrinhoDeCompra);
//                await _unitOfWork.CompleteAsync();
//                return CreatedAtRoute("GetById", new { id = carrinhoDeCompra.Id }, carrinhoDeCompra);
//            }
//            else
//            {
//                return BadRequest();
//            }
//        }


//        [HttpPut("{id}")]
//        public async Task<IActionResult> Update(int id, [FromBody] CarrinhoDeCompra carrinhoDeCompra)
//        {
//            if (carrinhoDeCompra == null || carrinhoDeCompra.Id != id)
//            {
//                return BadRequest();
//            }

//            var carrinhoDeCompraFromDb = _unitOfWork.CarrinhoDeCompras.GetByIdAsync(id);
//            if (carrinhoDeCompraFromDb == null)
//            {
//                return NotFound();
//            }

//            carrinhoDeCompraFromDb.RepublicaId = carrinhoDeCompra.RepublicaId;
//            carrinhoDeCompraFromDb.ListaProdutos = carrinhoDeCompra.ListaProdutos;
//            carrinhoDeCompraFromDb.CriadoPor = carrinhoDeCompra.CriadoPor;
//            carrinhoDeCompraFromDb.DataRegistro = carrinhoDeCompra.DataRegistro;
//            carrinhoDeCompraFromDb.isAtivo = carrinhoDeCompra.isAtivo;

//            _unitOfWork.CarrinhoDeCompras.Update(carrinhoDeCompra);
//            _unitOfWork.Complete();
//            return new NoContentResult();
//        }


//        [HttpDelete("{id}")]
//        public IActionResult Delete(int id)
//        {
//            var carrinhoDeCompra = _unitOfWork.CarrinhoDeCompras.GetByIdAsync(id);
//            if (carrinhoDeCompra == null)
//            {
//                return NotFound();
//            }

//            _unitOfWork.CarrinhoDeCompras.Remove(id);
//            _unitOfWork.Complete();
//            return new NoContentResult();
//        }
//    }
//}
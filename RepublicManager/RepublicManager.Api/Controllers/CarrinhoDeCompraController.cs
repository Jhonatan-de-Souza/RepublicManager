﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RepublicManager.Api.Core;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Controllers
{
    [Route("api/[controller]")]
    public class CarrinhoDeCompraController : Controller
    {
       
       
        private readonly IUnitOfWork _unitOfWork;


        public CarrinhoDeCompraController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<CarrinhoDeCompra> GetAll()
        {
            return _unitOfWork.CarrinhoDeCompras.GetAllAsync();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _unitOfWork.CarrinhoDeCompras.GetByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CarrinhoDeCompra item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _unitOfWork.CarrinhoDeCompras.Add(item);
            _unitOfWork.Complete();

       
            return CreatedAtRoute( new { id = item.Id }, item);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CarrinhoDeCompra item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var carrinhoDeCompra = _unitOfWork.CarrinhoDeCompras.GetByIdAsync(id);
            if (carrinhoDeCompra == null)
            {
                return NotFound();
            }

            carrinhoDeCompra.RepublicaId = item.RepublicaId;
            carrinhoDeCompra.ListaProdutos = item.ListaProdutos;
            carrinhoDeCompra.CriadoPor = item.CriadoPor;
            carrinhoDeCompra.DataRegistro = item.DataRegistro;
            carrinhoDeCompra.isAtivo = item.isAtivo;

            _unitOfWork.CarrinhoDeCompras.Update(carrinhoDeCompra);
            _unitOfWork.Complete();
            return new NoContentResult();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var carrinhoDeCompra = _unitOfWork.CarrinhoDeCompras.GetByIdAsync(id);
            if (carrinhoDeCompra == null)
            {
                return NotFound();
            }

            _unitOfWork.CarrinhoDeCompras.Remove(id);
            _unitOfWork.Complete();
            return new NoContentResult();
        }
    }
}
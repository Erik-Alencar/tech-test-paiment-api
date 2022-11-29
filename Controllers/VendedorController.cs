
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tech_test_paiment_api.Context;
using tech_test_paiment_api.Entities;

namespace tech_test_paiment_api.Controllers
{
    
    [ApiController]
    [Route("controller")]
    public class VendedorController : ControllerBase
    {
        private readonly PagamentoContext _context;

        public VendedorController(PagamentoContext context)
        {
            _context = context;
        }

        [HttpPost("CriarVendedor")]
        public IActionResult Create(Vendedor vendedor)
        {
            _context.Add(vendedor);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterVendedorPorId), new { id = vendedor.Id }, vendedor);
        }

        [HttpGet("vendedor/{id}")]
        public IActionResult ObterVendedorPorId(int id)
        {
            var vendedor = _context.Vendedores.Find(id);
            if (vendedor == null)
                return NotFound();

            return Ok(vendedor);
        }

        [HttpPut("vendedor/{id}")]
        public IActionResult Atualizar(int id, Vendedor vendedor)
        {
            var vendedorBanco = _context.Vendedores.Find(id);

            if (vendedorBanco == null)
                return NotFound();

            vendedorBanco.Nome = vendedor.Nome;
            vendedorBanco.Cpf = vendedor.Cpf;
            vendedorBanco.Email = vendedor.Email;
            vendedorBanco.Telefone = vendedor.Telefone;

            _context.Vendedores.Update(vendedorBanco);
            _context.SaveChanges();

            return Ok(vendedorBanco);
        }

        [HttpDelete("vendedor/{id}")]
        public IActionResult Deletar(int id)
        {
            var contatoBanco = _context.Vendedores.Find(id);

            if (contatoBanco == null)
                return NotFound();

            _context.Vendedores.Remove(contatoBanco);
            _context.SaveChanges();

            return NoContent();
         }
    }
    
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tech_test_paiment_api.Context;
using tech_test_paiment_api.Entities;

namespace tech_test_paiment_api.Controllers
{
    
  [ApiController]
    [Route("controller")]
    public class VendaController : ControllerBase
    {
        private readonly PagamentoContext _context;

        public VendaController(PagamentoContext context)
        {
            _context = context;
        }

        [HttpPost("CriarVenda")]
        public IActionResult Create(Venda venda, int idVendedor, int idProduto)
        {

            venda.Status = "Aguardando pagamento";
            venda.Data = DateTime.Now.ToLongDateString();
            venda.Vendedor = _context.Vendedores.Find(idVendedor);
            venda.Produto = _context.Produtos.Where(produto => produto.Id == idProduto).ToList();  
            _context.Add(venda);

            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterProdutoPorId), new { id = venda.Id }, venda);
        }

        [HttpGet("venda/{id}")]
        public IActionResult ObterProdutoPorId(int id)
        {
            var venda = _context.Vendas.Find(id);
            if (venda == null)
                return NotFound();

            return Ok(venda);
        }

        [HttpPut("venda/{id}")]
        public IActionResult Atualizar(int id, Venda venda)
        {
            var vendaBanco = _context.Vendas.Find(id);

            if (vendaBanco == null)
                return NotFound();

            vendaBanco.Vendedor = venda.Vendedor;
            vendaBanco.Produto = venda.Produto;
            vendaBanco.Data = venda.Data;
            if ((venda.Status == "Pagamento aprovado") | (venda.Status == "Enviado para transportadora") | (venda.Status == "Entregue") | (venda.Status == "Cancelada"))
            {
                vendaBanco.Status = venda.Status;
                _context.Vendas.Update(vendaBanco);
                _context.SaveChanges();

                return Ok(vendaBanco);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpDelete("venda/{id}")]
        public IActionResult Deletar(int id)
        {
            var vendaBanco = _context.Vendas.Find(id);

            if (vendaBanco == null)
                return NotFound();

            _context.Vendas.Remove(vendaBanco);
            _context.SaveChanges();

            return NoContent();
        }


    }
    
}
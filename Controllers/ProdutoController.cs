using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tech_test_paiment_api.Context;
using tech_test_paiment_api.Entities;

namespace tech_test_paiment_api.Controllers
{
    public class ProdutoController :   ControllerBase
    {
        private readonly PagamentoContext _context;

        public ProdutoController(PagamentoContext context)
        {
            _context = context;
        }

        [HttpPost("CriarProduto")]
        public IActionResult Create(Produto produto)
        {
            _context.Add(produto);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterProdutoPorId), new { id = produto.Id }, produto);
        }

        [HttpGet("produto/{id}")]
        public IActionResult ObterProdutoPorId(int id)
        {
            var produto = _context.Produtos.Find(id);
            if (produto == null)
                return NotFound();

            return Ok(produto);
        }

        [HttpPut("produto/{id}")]
        public IActionResult Atualizar(int id, Produto produto)
        {
            var produtoBanco = _context.Produtos.Find(id);

            if (produtoBanco == null)
                return NotFound();

            produtoBanco.Nome = produto.Nome;
            produtoBanco.Valor = produto.Valor;
            produtoBanco.Quantidade = produto.Quantidade;


            _context.Produtos.Update(produtoBanco);
            _context.SaveChanges();

            return Ok(produtoBanco);
        }

        [HttpDelete("produto/{id}")]
        public IActionResult Deletar(int id)
        {
            var produtoBanco = _context.Produtos.Find(id);

            if (produtoBanco == null)
                return NotFound();

            _context.Produtos.Remove(produtoBanco);
            _context.SaveChanges();

            return NoContent();
        }

    }
    
}
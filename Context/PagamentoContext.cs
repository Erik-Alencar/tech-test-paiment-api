using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tech_test_paiment_api.Entities;

namespace tech_test_paiment_api.Context
{
    public class PagamentoContext:DbContext 
    {
        public PagamentoContext(DbContextOptions<PagamentoContext> options): base(options)
        {

        }
         public DbSet<Produto> Produtos {get; set;}
         public DbSet<Venda> Vendas {get; set;}
         public DbSet<Vendedor> Vendedores {get; set;}
    }
}
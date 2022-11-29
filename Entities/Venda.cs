using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tech_test_paiment_api.Entities
{
    public class Venda
    {
          public int Id { get; set; }

        public Vendedor Vendedor { get; set; }

        public List<Produto> Produto { get; set; }

        public string Data { get; set; }

        public string Status { get; set; }

    }
}
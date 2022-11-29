using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tech_test_paiment_api.Entities
{
    public class Vendedor
    {
        public int Id {get; set;}
        public string Nome {get; set;}
        public string Cpf {get; set;}
        public string Email {get; set;}
        public string Telefone {get; set;}
    }
}
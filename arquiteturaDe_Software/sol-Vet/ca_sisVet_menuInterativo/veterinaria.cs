using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ca_sisVet_menuInterativo
{
    internal class Especies
    {
        public string nome { get; set; }
        public int id { get; set; }
    }
    internal class Animal
    {
        public string nome { get; set; }
        public string data_nascimento { get; set; }
        public int id { get; set; }
        public string apelido { get; set; }
        public string observacoes { get; set; }
    }
    internal class Cliente
    {
        public string nome { get; set; }
        public string cpf { get; set; }
        public int id { get; set; }
        public string email { get; set; }
        public string data_cadastro { get; set; }
    }
}

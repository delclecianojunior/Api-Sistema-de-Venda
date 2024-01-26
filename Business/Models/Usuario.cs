using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class Usuario : Entity
    {
        public string Nome { get; set; }
        public DateTime Data_Nascimento { get; set; }
        public string CPF { get; set; }
        public string Senha { get; set; } 
        public byte[] SenhaHash { get; set; } = new byte[0];
        public byte[] SenhaSalt { get; set; } = new byte[0];
        public string Email { get; set; }

        //Relacionamento com Venda
        public List<Venda> Vendas { get; set; }
    }
}

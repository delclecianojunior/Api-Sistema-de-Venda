using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class Vendedor : Entity
    {
        public string Nome { get; set; }
        public decimal PercentualComissao { get; set; }

        // Relacionamento com Produtos
        public List<Produto> Produtos { get; set; }

        //Relacionamento com Venda
        public List<Venda> Vendas { get; set; }

        // Relacionamento com Comissoes
        public List<Comissao> Comissoes { get; set; }
    }
}

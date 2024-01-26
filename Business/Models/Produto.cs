using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class Produto : Entity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }

        // Relacionamento com Vendedor
        public Guid? VendedorId { get; set; } 
        public Vendedor Vendedor { get; set; }

        //Relacioanmentos com ItensVenda (Associacao entre Venda e Produto)
        public List<ItemVenda> ItensVenda { get; set; }
    }
}

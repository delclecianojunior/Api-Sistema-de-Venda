using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class ItemVenda : Entity
    {
        public Guid VendaId { get; set; }
        public Venda Venda { get; set; }
        public Guid ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
    }
}

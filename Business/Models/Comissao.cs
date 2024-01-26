using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class Comissao : Entity
    {
        public Guid VendedorId { get; set; }
        public Vendedor Vendedor { get; set; }

        public Guid VendaId { get; set; }
        public Venda Venda { get; set; }

        public decimal ValorComissao { get; set; }

        public DateTime DataCalculo { get; set; }
    }
}

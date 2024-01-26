using Business.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class Venda : Entity
    {
        public DateTime DataVenda { get; set; }

        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public Guid VendedorId { get; set; }
        public Vendedor Vendedor { get; set; }

        //Relacionamento com ItensVenda
        public List<ItemVenda> ItensVenda { get; set; }

        // Relacionamento com Comissoes
        public List<Comissao> Comissoes { get; set; }

        public StatusVenda Status { get; set; }
    }
}

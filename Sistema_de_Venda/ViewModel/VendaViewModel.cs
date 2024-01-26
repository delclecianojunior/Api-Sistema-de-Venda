using Business.Models;
using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Venda.ViewModel
{
    public class VendaViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public DateTime DataVenda { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public Guid UsuarioId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public Guid VendedorId { get; set; }
        public List<ItemVendaViewModel> ItensVenda { get; set; }
    }
}

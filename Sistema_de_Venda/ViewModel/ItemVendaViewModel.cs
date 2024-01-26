using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Venda.ViewModel
{
    public class ItemVendaViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public Guid ProdutoId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero.")]
        public int Quantidade { get; set; }
    }
}

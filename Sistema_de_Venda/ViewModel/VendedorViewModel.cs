using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Venda.ViewModel
{
    public class VendedorViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal PercentualComissao { get; set; }
    }
}

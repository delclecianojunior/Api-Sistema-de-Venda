using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Venda.ViewModel
{
    public class ComissaoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid VendedorId { get; set; }
        public Guid VendaId { get; set; }
        public decimal ValorComissao { get; set; }
        public DateTime DataCalculo { get; set; }
    }
}

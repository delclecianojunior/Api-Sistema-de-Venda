using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Venda.ViewModel
{
    public class UsuarioViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [ScaffoldColumn(false)]
        public DateTime Data_Nascimento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string CPF { get; set; }

        public string Senha { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Email { get; set; }

    }
}

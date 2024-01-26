namespace Sistema_de_Venda.DTO
{
    public class VendedorDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal PercentualComissao { get; set; }
        public List<ProdutoDTO> Produtos { get; set; }
    }
}

using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(500)");

            builder.Property(p => p.Preco)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            // Relacionamento com Vendedor
            builder.HasOne(p => p.Vendedor)
                .WithMany(v => v.Produtos)
                .HasForeignKey(p => p.VendedorId);

            builder.ToTable("Produtos");
        }
    }
}

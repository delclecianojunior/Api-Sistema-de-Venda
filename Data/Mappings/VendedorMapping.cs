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
    public class VendedorMapping : IEntityTypeConfiguration<Vendedor>
    {
        public void Configure(EntityTypeBuilder<Vendedor> builder)
        {
            builder.HasKey(v => v.Id);

            builder.Property(v => v.Nome).
                IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(v => v.PercentualComissao)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            // Relacionamento com Produtos
            builder.HasMany(v => v.Produtos)
                .WithOne(p => p.Vendedor)
                .HasForeignKey(p => p.VendedorId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Vendedores");
        }
    }
}

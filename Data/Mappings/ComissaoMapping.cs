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
    public class ComissaoMapping : IEntityTypeConfiguration<Comissao>
    {
        public void Configure(EntityTypeBuilder<Comissao> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.ValorComissao)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(c => c.DataCalculo)
                .IsRequired();

            builder.HasOne(c => c.Vendedor)
                .WithMany(v => v.Comissoes)
                .HasForeignKey(c => c.VendedorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Venda)
                .WithMany(vn => vn.Comissoes)
                .HasForeignKey(c => c.VendaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Comissoes");
        }
    }
}

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
    public class VendaMapping : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.HasKey(v => v.Id);

            builder.Property(v => v.DataVenda)
               .IsRequired();

            // Relacionamento com Usuario
            builder.HasOne(v => v.Usuario)
               .WithMany(u => u.Vendas) 
               .HasForeignKey(v => v.UsuarioId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            // Relacionamento com Vendedor
            builder.HasOne(v => v.Vendedor)
                .WithMany(v => v.Vendas)
                .HasForeignKey(v => v.VendedorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Relacionamento com ItemVenda
            builder.HasMany(v => v.ItensVenda)
                .WithOne(iv => iv.Venda)
                .HasForeignKey(iv => iv.VendaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Vendas");
        }
    }
}

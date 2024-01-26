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
    public class ItemVendaMapping : IEntityTypeConfiguration<ItemVenda>
    {
        public void Configure(EntityTypeBuilder<ItemVenda> builder)
        {
            builder.HasKey(iv => iv.Id);

            builder.Property(iv => iv.Quantidade)
                .IsRequired();

            // Relacionamento com Venda
            builder.HasOne(iv => iv.Venda)
                .WithMany(v => v.ItensVenda)
                .HasForeignKey(iv => iv.VendaId)
                .IsRequired();

            // Relacionamento com Produto
            builder.HasOne(iv => iv.Produto)
                .WithMany(p => p.ItensVenda)
                .HasForeignKey(iv => iv.ProdutoId)
                .IsRequired();

            builder.ToTable("ItensVenda");
        }
    }
}

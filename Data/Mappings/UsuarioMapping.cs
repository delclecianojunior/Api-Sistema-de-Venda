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
    internal class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
           builder.HasKey(u => u.Id);
            
           builder.Property(u => u.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");
            
            builder.Property(u => u.Data_Nascimento)
                .IsRequired();

            builder.Property(u => u.CPF)
                .IsRequired();

            builder.Property(u => u.Senha)
                .IsRequired();

            builder.Property(u => u.Email)
                .IsRequired();

            builder.ToTable("Usuarios");
        }
    }
}

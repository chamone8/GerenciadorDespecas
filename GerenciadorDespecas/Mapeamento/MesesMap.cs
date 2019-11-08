using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GerenciadorDespecas.Models;


namespace GerenciadorDespecas.Mapeamento
{
    public class MesesMap : IEntityTypeConfiguration<Meses>
    {
        public void Configure( EntityTypeBuilder<Meses> builder)
        {
            builder.HasKey(d => d.MesId);//define a primary key
            builder.Property(d => d.MesId).ValueGeneratedNever();
            builder.Property(d => d.Nome).HasMaxLength(50).IsRequired();

            builder.HasMany(d => d.despesas).WithOne(d => d.Meses).HasForeignKey(d => d.MesId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(d => d.salario).WithOne(d => d.Meses).HasForeignKey<Salario>(d => d.MesId).OnDelete(DeleteBehavior.Cascade);
            builder.ToTable("Meses");
        }

    }
}

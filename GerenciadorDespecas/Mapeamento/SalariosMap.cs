using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GerenciadorDespecas.Models;

namespace GerenciadorDespecas.Mapeamento
{
    public class SalariosMap : IEntityTypeConfiguration<Salario>
    {
        public void Configure(EntityTypeBuilder<Salario> builder)
        {
            builder.HasKey(s => s.SalarioId);
            builder.Property(s => s.Valor).IsRequired();

            builder.HasOne(s => s.Meses).WithOne(s => s.salario).HasForeignKey<Salario>(s => s.SalarioId);

            builder.ToTable("Salario");
        }
    }
}

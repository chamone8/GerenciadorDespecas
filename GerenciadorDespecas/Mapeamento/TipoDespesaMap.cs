using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciadorDespecas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorDespecas.Mapeamento
{
    public class TipoDespesaMap : IEntityTypeConfiguration<TipoDespesas>
    {
        //classe para mapear a class TipoDespesas no banco
        public void Configure(EntityTypeBuilder<TipoDespesas> builder)
        {
           
            builder.HasKey(td => td.TipoDespesaId); //define o TipoId Como Primary key
            builder.Property(td => td.Nome).HasMaxLength(50).IsRequired();//define que o nome tem 50 caracteres no banco e é obrigatorio
            builder.HasMany(td => td.despesas).WithOne(td => td.TipoDespesas).HasForeignKey(td => td.TipoDespesaId); // aqui definimos a foreankey

            builder.ToTable("TipoDespesas");


        }
    }
}

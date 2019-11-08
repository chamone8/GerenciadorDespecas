using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciadorDespecas.Mapeamento;

namespace GerenciadorDespecas.Models
{
    public class Contexto : DbContext
    {
        public DbSet<Salario> salarios { get; set; }
        public DbSet<Meses> meses { get; set; }
        public DbSet<Despesas> despesas { get; set; }
        public DbSet<TipoDespesas> tipoDespesas { get; set; }
        public Contexto(DbContextOptions<Contexto> op) : base(op)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TipoDespesaMap());
            modelBuilder.ApplyConfiguration(new DespesasMap());
            modelBuilder.ApplyConfiguration(new SalariosMap());
            modelBuilder.ApplyConfiguration(new MesesMap());
        }


    }
}

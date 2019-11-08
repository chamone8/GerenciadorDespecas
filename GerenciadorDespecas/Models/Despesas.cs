using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDespecas.Models
{
    public class Despesas
    {
        public int DespesaId { get; set; }
        public int MesId { get; set; }
        public Meses Meses { get; set; }
        public int TipoDespesaId { get; set; }
        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Range(0, double.MaxValue, ErrorMessage = "Maximo de 50 caracteres")]
        public double Valor { get; set; }
        public TipoDespesas TipoDespesas { get; set; }
    }
}

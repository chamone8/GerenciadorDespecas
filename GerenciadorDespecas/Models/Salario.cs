using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDespecas.Models
{
    public class Salario
    {
        public int SalarioId { get; set; }
        [Required(ErrorMessage ="Campo Obrigatorio")]
        [Range(0,double.MaxValue, ErrorMessage ="Maximo de 50 caracteres")]
        public double Valor { get; set; }
        public int MesId { get; set; }
        public Meses Meses { get; set; }


    }
}

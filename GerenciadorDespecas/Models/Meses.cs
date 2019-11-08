using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDespecas.Models
{
    public class Meses
    {
        public int MesId { get; set; }

        public string Nome { get; set; }

        public ICollection<Despesas> despesas { get; set; }



        public Salario salario { get; set; }
    }
}
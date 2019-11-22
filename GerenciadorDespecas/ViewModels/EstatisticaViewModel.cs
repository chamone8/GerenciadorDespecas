using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDespecas.ViewModels
{
    public class EstatisticaViewModel
    {
        public int QuantidadeDespesas { get; set; }
        public double MenorDespesa { get; set; }
        public double MaiorDespesa { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDespecas.Models
{
    public class TipoDespesas
    {
        public int TipoDespesaId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres.")]
        [Remote("TipoDespesaExiste","TipoDespesas")]
        public string Nome { get; set; }


        public ICollection<Despesas> despesas { get; set; }
    }
}

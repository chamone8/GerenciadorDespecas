using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciadorDespecas.Models;
using GerenciadorDespecas.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDespecas.ViewComponents
{
    public class EstatisticaViewComponent : ViewComponent
    {
        private readonly Contexto _contexto;

        public EstatisticaViewComponent(Contexto contexto)
        {
            _contexto = contexto;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            EstatisticaViewModel estatistica = new EstatisticaViewModel();
            estatistica.MenorDespesa = _contexto.despesas.Min(x => x.Valor);
            estatistica.MaiorDespesa = _contexto.despesas.Max(x => x.Valor);
            estatistica.QuantidadeDespesas = _contexto.despesas.Count();
            return View(estatistica);

        }
    } 
}

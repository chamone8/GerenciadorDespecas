using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GerenciadorDespecas.Models;
using X.PagedList;
using GerenciadorDespecas.ViewModels;

namespace GerenciadorDespecas.Controllers
{
    public class DespesasController : Controller
    {
        private readonly Contexto _context;

        public DespesasController(Contexto context)
        {
            _context = context;
        }

        // GET: Despesas
        public async Task<IActionResult> Index(int? pagina)
        {
            const int itensPgina = 10;
            int numeroPagina = (pagina ?? 1);
            ViewData["Meses"] = new SelectList(_context.meses.Where(x => x.MesId == x.salario.MesId),"MesId","Nome");
            var contexto = _context.despesas.Include(d => d.Meses).Include(d => d.TipoDespesas).OrderBy(d => d.MesId);
            return View(await contexto.ToPagedListAsync(numeroPagina, itensPgina));
        }

       
        // GET: Despesas/Create
        public IActionResult Create()
        {
            TempData["Confirmacao"] = "Despesa Cadastrada com sucesso!";
            ViewData["MesId"] = new SelectList(_context.meses, "MesId", "Nome");
            ViewData["TipoDespesaId"] = new SelectList(_context.tipoDespesas, "TipoDespesaId", "Nome");
            return View();
        }

        // POST: Despesas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DespesaId,MesId,TipoDespesaId,Valor")] Despesas despesas)
        {
            if (ModelState.IsValid)
            {

                TempData["Confirmacao"] = "Despesa Cadastrada com sucesso";
                _context.Add(despesas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MesId"] = new SelectList(_context.meses, "MesId", "Nome", despesas.MesId);
            ViewData["TipoDespesaId"] = new SelectList(_context.tipoDespesas, "TipoDespesaId", "Nome", despesas.TipoDespesaId);
            return View(despesas);
        }

        // GET: Despesas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var despesas = await _context.despesas.FindAsync(id);
            if (despesas == null)
            {
                return NotFound();
            }
            ViewData["MesId"] = new SelectList(_context.meses, "MesId", "Nome", despesas.MesId);
            ViewData["TipoDespesaId"] = new SelectList(_context.tipoDespesas, "TipoDespesaId", "Nome", despesas.TipoDespesaId);
            return View(despesas);
        }

        // POST: Despesas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DespesaId,MesId,TipoDespesaId,Valor")] Despesas despesas)
        {
            if (id != despesas.DespesaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                TempData["Confirmacao"] = "Despesa Editada com Sucesso";
                try
                {
                    _context.Update(despesas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DespesasExists(despesas.DespesaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MesId"] = new SelectList(_context.meses, "MesId", "Nome", despesas.MesId);
            ViewData["TipoDespesaId"] = new SelectList(_context.tipoDespesas, "TipoDespesaId", "Nome", despesas.TipoDespesaId);
            return View(despesas);
        }


        // POST: Despesas/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            TempData["Confirmacao"] = "Deletado com sucesso!!";
            var despesas = await _context.despesas.FindAsync(id);
            _context.despesas.Remove(despesas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DespesasExists(int id)
        {
            return _context.despesas.Any(e => e.DespesaId == id);
        }

        public JsonResult GastosTotaisMes(int mesId)
        {
            GastosTotaisViewModel gasto = new GastosTotaisViewModel();
            gasto.ValorTotalGasto = _context.despesas.Where(d => d.Meses.MesId == mesId).Sum(s => s.Valor);
            gasto.Salario = _context.salarios.Where(d => d.Meses.MesId == mesId).Select(s => s.Valor).FirstOrDefault();

            return Json(gasto);

        }

        public JsonResult GastosMes(int mesId)
        {
            var query = from despesas in _context.despesas
                        where despesas.Meses.MesId == mesId
                        group despesas by despesas.TipoDespesas.Nome into g
                        select new
                        {
                            TipoDespesas = g.Key,
                            valores = g.Sum(d => d.Valor)
                        };


            return Json(query);
        }

        public JsonResult GastosTotais()
        {
            var query = _context.despesas.
                OrderBy(m => m.Meses.MesId).
                GroupBy(m => m.Meses.MesId).
                Select(d => new { NomeMeses = d.Select(x => x.Meses.Nome).
                Distinct(), Valores = d.Sum(x => x.Valor) });
            return Json(query);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GerenciadorDespecas.Models;

namespace GerenciadorDespecas.Controllers
{
    public class MesesController : Controller
    {
        private readonly Contexto _context;

        public MesesController(Contexto context)
        {
            _context = context;
        }

        // GET: Meses
        public async Task<IActionResult> Index()
        {
            return View(await _context.meses.ToListAsync());
        }

        // GET: Meses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meses = await _context.meses
                .FirstOrDefaultAsync(m => m.MesId == id);
            if (meses == null)
            {
                return NotFound();
            }

            return View(meses);
        }

        // GET: Meses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Meses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MesId,Nome")] Meses meses)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meses);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(meses);
        }

        // GET: Meses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meses = await _context.meses.FindAsync(id);
            if (meses == null)
            {
                return NotFound();
            }
            return View(meses);
        }

        // POST: Meses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MesId,Nome")] Meses meses)
        {
            if (id != meses.MesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meses);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MesesExists(meses.MesId))
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
            return View(meses);
        }

        // GET: Meses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meses = await _context.meses
                .FirstOrDefaultAsync(m => m.MesId == id);
            if (meses == null)
            {
                return NotFound();
            }

            return View(meses);
        }

        // POST: Meses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meses = await _context.meses.FindAsync(id);
            _context.meses.Remove(meses);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MesesExists(int id)
        {
            return _context.meses.Any(e => e.MesId == id);
        }
    }
}

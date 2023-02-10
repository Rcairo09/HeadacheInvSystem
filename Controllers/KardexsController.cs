using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HeadacheInvSystem.Models;

namespace HeadacheInvSystem.Controllers
{
    public class KardexsController : Controller
    {
        private readonly ContolInventarioContext _context;

        public KardexsController(ContolInventarioContext context)
        {
            _context = context;
        }

        // GET: Kardexs
        public async Task<IActionResult> Index()
        {
            var contolInventarioContext = _context.Kardices.Include(k => k.Producto);
            return View(await contolInventarioContext.ToListAsync());
        }

        // GET: Kardexs/Details/5
        public async Task<IActionResult> Details(byte? id)
        {
            if (id == null || _context.Kardices == null)
            {
                return NotFound();
            }

            var kardex = await _context.Kardices
                .Include(k => k.Producto)
                .FirstOrDefaultAsync(m => m.KardexId == id);
            if (kardex == null)
            {
                return NotFound();
            }

            return View(kardex);
        }

        // GET: Kardexs/Create
        public IActionResult Create()
        {
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "ProductoNombre");
            return View();
        }

        // POST: Kardexs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(KardexSP d)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC ControlM.Documento {d.Producto}, {d.Unidades}");
            return RedirectToAction(nameof(Index));

        }

        // GET: Kardexs/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null || _context.Kardices == null)
            {
                return NotFound();
            }

            var kardex = await _context.Kardices.FindAsync(id);
            if (kardex == null)
            {
                return NotFound();
            }
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "ProductoId", kardex.ProductoId);
            return View(kardex);
        }

        // POST: Kardexs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, [Bind("KardexId,Fecha,ProductoId,Entradas,Salidas,Existencias,Compra,CostoPromedio,Debe,Haber,Saldo")] Kardex kardex)
        {
            if (id != kardex.KardexId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kardex);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KardexExists(kardex.KardexId))
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
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "ProductoId", kardex.ProductoId);
            return View(kardex);
        }

        // GET: Kardexs/Delete/5
        public async Task<IActionResult> Delete(byte? id)
        {
            if (id == null || _context.Kardices == null)
            {
                return NotFound();
            }

            var kardex = await _context.Kardices
                .Include(k => k.Producto)
                .FirstOrDefaultAsync(m => m.KardexId == id);
            if (kardex == null)
            {
                return NotFound();
            }

            return View(kardex);
        }

        // POST: Kardexs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            if (_context.Kardices == null)
            {
                return Problem("Entity set 'ContolInventarioContext.Kardices'  is null.");
            }
            var kardex = await _context.Kardices.FindAsync(id);
            if (kardex != null)
            {
                _context.Kardices.Remove(kardex);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KardexExists(byte id)
        {
          return _context.Kardices.Any(e => e.KardexId == id);
        }
    }
}

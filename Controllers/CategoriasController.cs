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
    public class CategoriasController : Controller
    {
        private readonly ContolInventarioContext _context;

        public CategoriasController(ContolInventarioContext context)
        {
            _context = context;
        }

        // GET: Categorias
        public async Task<IActionResult> Index()
        {
              return View(await _context.Categoria.ToListAsync());
        }

        // GET: Categorias/Details/5
        public async Task<IActionResult> Details(byte? id)
        {
            if (id == null || _context.Categoria == null)
            {
                return NotFound();
            }

            var categorium = await _context.Categoria
                .FirstOrDefaultAsync(m => m.CategoriaId == id);
            if (categorium == null)
            {
                return NotFound();
            }

            return View(categorium);
        }

        // GET: Categorias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoriasSP c)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC Entrada.Categorias {c.NombreCategoria}, {c.Descripcion}");
            if (_context.Categoria.Any(x => x.NombreCategoria == c.NombreCategoria))
            {
                ViewData["ErrorMessage"] = "El elemento ya existe";
                return View("VistaErrorCategorias");
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Categorias/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null || _context.Categoria == null)
            {
                return NotFound();
            }

            var categorium = await _context.Categoria.FindAsync(id);
            if (categorium == null)
            {
                return NotFound();
            }
            return View(categorium);
        }

        // POST: Categorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, [Bind("CategoriaId,NombreCategoria,Descripcion")] Categorium categorium)
        {
            if (id != categorium.CategoriaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categorium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriumExists(categorium.CategoriaId))
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
            return View(categorium);
        }

        // GET: Categorias/Delete/5
        public async Task<IActionResult> Delete(byte? id)
        {
            if (id == null || _context.Categoria == null)
            {
                return NotFound();
            }

            var categorium = await _context.Categoria
                .FirstOrDefaultAsync(m => m.CategoriaId == id);
            if (categorium == null)
            {
                return NotFound();
            }

            return View(categorium);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            if (_context.Categoria == null)
            {
                return Problem("Entity set 'ContolInventarioContext.Categoria'  is null.");
            }
            var categorium = await _context.Categoria.FindAsync(id);
            if (categorium != null)
            {
                _context.Categoria.Remove(categorium);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriumExists(byte id)
        {
          return _context.Categoria.Any(e => e.CategoriaId == id);
        }
    }
}

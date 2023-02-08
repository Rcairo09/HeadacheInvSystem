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
    public class ProductosController : Controller
    {
        private readonly ContolInventarioContext _context;

        public ProductosController(ContolInventarioContext context)
        {
            _context = context;
        }

        // GET: Productos
        public async Task<IActionResult> Index()
        {
            var contolInventarioContext = _context.Productos.Include(p => p.Categoria).Include(p => p.Proveedor);
            return View(await contolInventarioContext.ToListAsync());
        }

        // GET: Productos/Details/5
        public async Task<IActionResult> Details(byte? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.Categoria)
                .Include(p => p.Proveedor)
                .FirstOrDefaultAsync(m => m.ProductoId == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Productos/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "CategoriaId", "NombreCategoria");
            ViewData["ProveedorId"] = new SelectList(_context.Proveedors, "ProveedorId", "Nombre");
            return View();
        }

        // POST: Productos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Producto ps)
        {
            Producto? p = null;
            if (!ModelState.IsValid)
            {
                if (!await _context.Productos.AnyAsync(x => x.ProductoNombre == ps.ProductoNombre))
                {
                    await _context.Productos.AddAsync(ps);
                    await _context.SaveChangesAsync();
                    p = await _context.Productos.Where(x => x.ProductoNombre == ps.ProductoNombre).FirstOrDefaultAsync();
                    if (p != null)
                    {
                        return RedirectToAction("Details", new { id = p.ProductoId });
                    }
                    else
                    {
                        ViewData["ErrorMessage"] = "El elemento ya existe";
                        return View("VistaError");
                    }
                }

            }
            ViewData["ErrorMessage"] = "Ya existe un elemento con este nombre. Intente registrándolo bajo otro nombre, por favor.";
            return View("VistaErrorProductos");
        }

        // GET: Productos/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "CategoriaId", "NombreCategoria", producto.CategoriaId);
            ViewData["ProveedorId"] = new SelectList(_context.Proveedors, "ProveedorId", "Nombre", producto.ProveedorId);
            return View(producto);
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, [Bind("ProductoId,CategoriaId,ProveedorId,ProductoNombre,ProductoPrecioUnitario")] Producto producto)
        {
            if (id != producto.ProductoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.ProductoId))
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
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "CategoriaId", "NombreCategoria", producto.CategoriaId);
            ViewData["ProveedorId"] = new SelectList(_context.Proveedors, "ProveedorId", "Nombre", producto.ProveedorId);
            return View(producto);
        }

        // GET: Productos/Delete/5
        public async Task<IActionResult> Delete(byte? id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.Categoria)
                .Include(p => p.Proveedor)
                .FirstOrDefaultAsync(m => m.ProductoId == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            if (_context.Productos == null)
            {
                return Problem("Entity set 'ContolInventarioContext.Productos'  is null.");
            }
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(byte id)
        {
          return _context.Productos.Any(e => e.ProductoId == id);
        }
    }
}

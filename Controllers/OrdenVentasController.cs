using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HeadacheInvSystem.Models;
<<<<<<< HEAD
using System.Net;
=======
using Microsoft.AspNetCore.Authorization;
using System.Data;
>>>>>>> 2937f5a59dd3eca80e27c682aecf744aedeec090

namespace HeadacheInvSystem.Controllers
{
    [Authorize(Roles = "Vendedor,Administrador")]
    public class OrdenVentasController : Controller
    {
        private readonly ContolInventarioContext _context;

        public OrdenVentasController(ContolInventarioContext context)
        {
            _context = context;
        }

        // GET: OrdenVentas
        public async Task<IActionResult> Index()
        {
            var contolInventarioContext = _context.OrdenVenta.Include(o => o.Producto);
            return View(await contolInventarioContext.ToListAsync());
        }

        // GET: OrdenVentas/Details/5
        public async Task<IActionResult> Details(byte? id)
        {
            if (id == null || _context.OrdenVenta == null)
            {
                return NotFound();
            }

            var ordenVentum = await _context.OrdenVenta
                .Include(o => o.Producto)
                .FirstOrDefaultAsync(m => m.OrdenId == id);
            if (ordenVentum == null)
            {
                return NotFound();
            }

            return View(ordenVentum);
        }

        // GET: OrdenVentas/Create
        public IActionResult Create()
        {
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "ProductoNombre");
            return View();
        }

        // POST: OrdenVentas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrdenSP o)
        {
            var producto = _context.Kardices.SingleOrDefault(k => k.ProductoId == o.Producto);
            if (producto.Existencias < o.Unidades)
            {
                ViewData["ErrorMessage"] = "No hay suficientes unidades de este producto, para realizar la compra, solo hay: " + producto.Existencias;
                return View("ErrorVistaOrden");

            }
            var exist = producto.Existencias - o.Unidades == 0;
            if (exist)
            {
                try
                {
                    await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC Salida.VentaProducto {o.Nombre}, {o.Apellido}, {o.Producto}, {o.Unidades}, {o.Correo}");
                    return RedirectToAction(nameof(Index));
                }
                catch (ArgumentNullException ex)
                {
                    //code specifically for a ArgumentNullException
                }
                catch (WebException ex)
                {
                    //code specifically for a WebException
                }
                catch (Exception ex)
                {
                    //code for any other type of exception
                }
            }
            await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC Salida.VentaProducto {o.Nombre}, {o.Apellido}, {o.Producto}, {o.Unidades}, {o.Correo}");
            return RedirectToAction(nameof(Index));
        }

        // GET: OrdenVentas/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null || _context.OrdenVenta == null)
            {
                return NotFound();
            }

            var ordenVentum = await _context.OrdenVenta.FindAsync(id);
            if (ordenVentum == null)
            {
                return NotFound();
            }
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "ProductoNombre", ordenVentum.ProductoId);
            return View(ordenVentum);
        }

        // POST: OrdenVentas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, [Bind("OrdenId,ProductoId,NombreCliente,ApellidoCliente,Correo")] OrdenVentum ordenVentum)
        {
            if (id != ordenVentum.OrdenId)
            {
                return NotFound();
            }
            ModelState.Remove("Producto");
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordenVentum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdenVentumExists(ordenVentum.OrdenId))
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
            ViewData["ProductoId"] = new SelectList(_context.Productos, "ProductoId", "ProductoNombre", ordenVentum.ProductoId);
            return View(ordenVentum);
        }

        // GET: OrdenVentas/Delete/5
        public async Task<IActionResult> Delete(byte? id)
        {
            if (id == null || _context.OrdenVenta == null)
            {
                return NotFound();
            }

            var ordenVentum = await _context.OrdenVenta
                .Include(o => o.Producto)
                .FirstOrDefaultAsync(m => m.OrdenId == id);
            if (ordenVentum == null)
            {
                return NotFound();
            }

            return View(ordenVentum);
        }

        // POST: OrdenVentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            if (_context.OrdenVenta == null)
            {
                return Problem("Entity set 'ContolInventarioContext.OrdenVenta'  is null.");
            }
            var ordenVentum = await _context.OrdenVenta.FindAsync(id);
            if (ordenVentum != null)
            {
                _context.OrdenVenta.Remove(ordenVentum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdenVentumExists(byte id)
        {
          return _context.OrdenVenta.Any(e => e.OrdenId == id);
        }
    }
}

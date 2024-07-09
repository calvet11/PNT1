using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Context;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{// se reciben los datos del front , por cada controller hay una view
    public class CarritoDeComprasController : Controller
    {
        private readonly AutoServicioDatabaseContext _context;

        public CarritoDeComprasController(AutoServicioDatabaseContext context)
        {
            _context = context;
        }

        // GET: CarritoDeCompras
        public async Task<IActionResult> Index(string buscar, string filtro)
        {// lista a todos los usuarios o a los q busque.
            var autoServicioDatabaseContext = _context.CarritoDeCompra_1.Include(c => c.Cliente).Include(c => c.Producto);

            var usuarios = from c in autoServicioDatabaseContext select c;

            if (!String.IsNullOrEmpty(buscar))
            {
                usuarios = usuarios.Where(s => s.Cliente.NombreCompleto.Contains(buscar));
            }

            ViewData["FiltroFecha"] = filtro == "FechaAscendente" ? "FechaDescendente" : "FechaAscendente";

            switch (filtro)
            {
                case "FechaDescendente":
                    usuarios = usuarios.OrderByDescending(usuarios => usuarios.FechaCreacion);
                    break;
                case "FechaAscendente":
                    usuarios = usuarios.OrderBy(usuarios => usuarios.FechaCreacion);
                    break;
            }

            //return View(await autoServicioDatabaseContext.ToListAsync());
            return View(await usuarios.ToListAsync());
        }

        // GET: CarritoDeCompras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CarritoDeCompra_1 == null)
            {
                return NotFound();
            }

            var carritoDeCompra = await _context.CarritoDeCompra_1
                .Include(c => c.Cliente)
                .Include(c => c.Producto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carritoDeCompra == null)
            {
                return NotFound();
            }

            return View(carritoDeCompra);
        }

        // GET: CarritoDeCompras/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "NombreCompleto");
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "NombreProducto");
            return View();
        }

        // POST: CarritoDeCompras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteId,ProductoId,Cantidad,MetodoDePago,Total,FechaCreacion")] CarritoDeCompra carritoDeCompra)
        {
            var ProductoSeleccionado = _context.Productos.FirstOrDefault(p => p.Id == carritoDeCompra.ProductoId);
            carritoDeCompra.Total = ProductoSeleccionado.Precio * carritoDeCompra.Cantidad;

            if (ModelState.IsValid)
            {
                _context.Add(carritoDeCompra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "NombreCompleto", carritoDeCompra.ClienteId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "NombreProducto", carritoDeCompra.ProductoId);
            return View(carritoDeCompra);
        }

        // GET: CarritoDeCompras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CarritoDeCompra_1 == null)
            {
                return NotFound();
            }

            var carritoDeCompra = await _context.CarritoDeCompra_1.FindAsync(id);
            if (carritoDeCompra == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "NombreCompleto", carritoDeCompra.ClienteId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "NombreProducto", carritoDeCompra.ProductoId);
            return View(carritoDeCompra);
        }

        // POST: CarritoDeCompras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClienteId,ProductoId,Cantidad,MetodoDePago,Total,FechaCreacion")] CarritoDeCompra carritoDeCompra)
        {
            if (id != carritoDeCompra.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carritoDeCompra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarritoDeCompraExists(carritoDeCompra.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "NombreCompleto", carritoDeCompra.ClienteId);
            ViewData["ProductoId"] = new SelectList(_context.Productos, "Id", "NombreProducto", carritoDeCompra.ProductoId);
            return View(carritoDeCompra);
        }

        // GET: CarritoDeCompras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CarritoDeCompra_1 == null)
            {
                return NotFound();
            }

            var carritoDeCompra = await _context.CarritoDeCompra_1
                .Include(c => c.Cliente)
                .Include(c => c.Producto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carritoDeCompra == null)
            {
                return NotFound();
            }

            return View(carritoDeCompra);
        }

        // POST: CarritoDeCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CarritoDeCompra_1 == null)
            {
                return Problem("Entity set 'AutoServicioDatabaseContext.CarritoDeCompra_1'  is null.");
            }
            var carritoDeCompra = await _context.CarritoDeCompra_1.FindAsync(id);
            if (carritoDeCompra != null)
            {
                _context.CarritoDeCompra_1.Remove(carritoDeCompra);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarritoDeCompraExists(int id)
        {
          return (_context.CarritoDeCompra_1?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

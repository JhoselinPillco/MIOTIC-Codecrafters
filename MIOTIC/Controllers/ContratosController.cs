using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MIOTIC.Contexto;
using MIOTIC.Models;

namespace MIOTIC.Controllers
{
    public class ContratosController : Controller
    {
        private readonly MiContexto _context;

        public ContratosController(MiContexto context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var miContexto = _context.Contratos.Include(c => c.Cliente).Include(c => c.Usuario);
            return View(await miContexto.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contrato = await _context.Contratos
                .Include(c => c.Cliente)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contrato == null)
            {
                return NotFound();
            }

            return View(contrato);
        }

        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nombre");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Email");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Numero,NombreProyecto,FechaContrato,FechaEntrega,Costo,UsuarioId,ClienteId")] Contrato contrato)
        {
            if (ModelState.IsValid)
            {
               
                contrato.Numero = GetNumero();
                _context.Add(contrato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nombre", contrato.ClienteId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Email", contrato.UsuarioId);
            return View(contrato);
        }

        private int GetNumero()
        {
            if (_context.Contratos.ToList().Count > 0)
                return _context.Contratos.Max(i => i.Numero) + 1;
            return 1;
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contrato = await _context.Contratos.FindAsync(id);
            if (contrato == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nombre", contrato.ClienteId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Email", contrato.UsuarioId);
            return View(contrato);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreProyecto,FechaContrato,FechaEntrega,Costo,UsuarioId,ClienteId")] Contrato contrato)
        {
            if (id != contrato.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contrato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContratoExists(contrato.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nombre", contrato.ClienteId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Email", contrato.UsuarioId);
            return View(contrato);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contrato = await _context.Contratos
                .Include(c => c.Cliente)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contrato == null)
            {
                return NotFound();
            }

            return View(contrato);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contrato = await _context.Contratos.FindAsync(id);
            if (contrato != null)
            {
                _context.Contratos.Remove(contrato);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContratoExists(int id)
        {
            return _context.Contratos.Any(e => e.Id == id);
        }
    }
}

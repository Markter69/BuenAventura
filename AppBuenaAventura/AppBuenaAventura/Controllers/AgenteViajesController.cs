using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppBuenaAventura.Contexto;
using AppBuenaAventura.Models;

namespace AppBuenaAventura.Controllers
{
    public class AgenteViajesController : Controller
    {
        private readonly BuenaAventuraContext _context;

        public AgenteViajesController(BuenaAventuraContext context)
        {
            _context = context;
        }

        // GET: AgenteViajes
        public async Task<IActionResult> Index()
        {
            return View(await _context.AgentesViaje.ToListAsync());
        }

        // GET: AgenteViajes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenteViaje = await _context.AgentesViaje
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agenteViaje == null)
            {
                return NotFound();
            }

            return View(agenteViaje);
        }

        // GET: AgenteViajes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AgenteViajes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreCompletoAgen,Correo,Telefono,AgenciaId")] AgenteViaje agenteViaje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agenteViaje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(agenteViaje);
        }

        // GET: AgenteViajes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenteViaje = await _context.AgentesViaje.FindAsync(id);
            if (agenteViaje == null)
            {
                return NotFound();
            }
            return View(agenteViaje);
        }

        // POST: AgenteViajes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreCompletoAgen,Correo,Telefono,AgenciaId")] AgenteViaje agenteViaje)
        {
            if (id != agenteViaje.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agenteViaje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgenteViajeExists(agenteViaje.Id))
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
            return View(agenteViaje);
        }

        // GET: AgenteViajes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenteViaje = await _context.AgentesViaje
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agenteViaje == null)
            {
                return NotFound();
            }

            return View(agenteViaje);
        }

        // POST: AgenteViajes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agenteViaje = await _context.AgentesViaje.FindAsync(id);
            if (agenteViaje != null)
            {
                _context.AgentesViaje.Remove(agenteViaje);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgenteViajeExists(int id)
        {
            return _context.AgentesViaje.Any(e => e.Id == id);
        }
    }
}

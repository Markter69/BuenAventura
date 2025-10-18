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
    public class ReseñasController : Controller
    {
        private readonly BuenaAventuraContext _context;

        public ReseñasController(BuenaAventuraContext context)
        {
            _context = context;
        }

        // GET: Reseñas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reseñas.ToListAsync());
        }

        // GET: Reseñas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reseñas = await _context.Reseñas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reseñas == null)
            {
                return NotFound();
            }

            return View(reseñas);
        }

        // GET: Reseñas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reseñas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteId,AgenciaId,HotelId,AgenteId,Calificacion,Comentario,FechaReseña")] Reseñas reseñas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reseñas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reseñas);
        }

        // GET: Reseñas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reseñas = await _context.Reseñas.FindAsync(id);
            if (reseñas == null)
            {
                return NotFound();
            }
            return View(reseñas);
        }

        // POST: Reseñas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClienteId,AgenciaId,HotelId,AgenteId,Calificacion,Comentario,FechaReseña")] Reseñas reseñas)
        {
            if (id != reseñas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reseñas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReseñasExists(reseñas.Id))
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
            return View(reseñas);
        }

        // GET: Reseñas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reseñas = await _context.Reseñas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reseñas == null)
            {
                return NotFound();
            }

            return View(reseñas);
        }

        // POST: Reseñas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reseñas = await _context.Reseñas.FindAsync(id);
            if (reseñas != null)
            {
                _context.Reseñas.Remove(reseñas);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReseñasExists(int id)
        {
            return _context.Reseñas.Any(e => e.Id == id);
        }
    }
}

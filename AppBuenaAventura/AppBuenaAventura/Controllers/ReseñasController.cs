using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppBuenaAventura.Contexto;
using AppBuenaAventura.Models;

namespace AppBuenaAventura.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReseñasController : ControllerBase
    {
        private readonly BuenaAventuraContext _context;

        public ReseñasController(BuenaAventuraContext context)
        {
            _context = context;
        }

        // GET: api/Reseñas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reseñas>>> GetReseñas()
        {
            return await _context.Reseñas.ToListAsync();
        }

        // GET: api/Reseñas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reseñas>> GetReseñas(int id)
        {
            var reseñas = await _context.Reseñas.FindAsync(id);

            if (reseñas == null)
            {
                return NotFound();
            }

            return reseñas;
        }

        // PUT: api/Reseñas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReseñas(int id, Reseñas reseñas)
        {
            if (id != reseñas.Id)
            {
                return BadRequest();
            }

            _context.Entry(reseñas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReseñasExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Reseñas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reseñas>> PostReseñas(Reseñas reseñas)
        {
            _context.Reseñas.Add(reseñas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReseñas", new { id = reseñas.Id }, reseñas);
        }

        // DELETE: api/Reseñas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReseñas(int id)
        {
            var reseñas = await _context.Reseñas.FindAsync(id);
            if (reseñas == null)
            {
                return NotFound();
            }

            _context.Reseñas.Remove(reseñas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReseñasExists(int id)
        {
            return _context.Reseñas.Any(e => e.Id == id);
        }
    }
}

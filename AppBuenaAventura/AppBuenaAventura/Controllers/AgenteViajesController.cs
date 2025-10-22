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
    public class AgenteViajesController : ControllerBase
    {
        private readonly BuenaAventuraContext _context;

        public AgenteViajesController(BuenaAventuraContext context)
        {
            _context = context;
        }

        // GET: api/AgenteViajes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgenteViaje>>> GetAgentesViaje()
        {
            return await _context.AgentesViaje.ToListAsync();
        }

        // GET: api/AgenteViajes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AgenteViaje>> GetAgenteViaje(int id)
        {
            var agenteViaje = await _context.AgentesViaje.FindAsync(id);

            if (agenteViaje == null)
            {
                return NotFound();
            }

            return agenteViaje;
        }

        // PUT: api/AgenteViajes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgenteViaje(int id, AgenteViaje agenteViaje)
        {
            if (id != agenteViaje.Id)
            {
                return BadRequest();
            }

            _context.Entry(agenteViaje).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgenteViajeExists(id))
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

        // POST: api/AgenteViajes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AgenteViaje>> PostAgenteViaje(AgenteViaje agenteViaje)
        {
            _context.AgentesViaje.Add(agenteViaje);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAgenteViaje", new { id = agenteViaje.Id }, agenteViaje);
        }

        // DELETE: api/AgenteViajes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgenteViaje(int id)
        {
            var agenteViaje = await _context.AgentesViaje.FindAsync(id);
            if (agenteViaje == null)
            {
                return NotFound();
            }

            _context.AgentesViaje.Remove(agenteViaje);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AgenteViajeExists(int id)
        {
            return _context.AgentesViaje.Any(e => e.Id == id);
        }
    }
}

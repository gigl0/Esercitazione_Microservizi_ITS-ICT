using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrestitiBibliotecaWebAPI.Models;

namespace PrestitiBibliotecaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestitiController : ControllerBase
    {
        private readonly PrestitiBibliotecaContext _context;

        public PrestitiController(PrestitiBibliotecaContext context)
        {
            _context = context;
        }

        // GET: api/Prestiti
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prestito>>> GetPrestitos()
        {
            return await _context.Prestitos.ToListAsync();
        }

        // GET: api/Prestiti/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Prestito>> GetPrestito(int id)
        {
            var prestito = await _context.Prestitos.FindAsync(id);

            if (prestito == null)
            {
                return NotFound();
            }

            return prestito;
        }

        // PUT: api/Prestiti/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrestito(int id, Prestito prestito)
        {
            if (id != prestito.Id)
            {
                return BadRequest();
            }

            _context.Entry(prestito).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrestitoExists(id))
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

        // POST: api/Prestiti
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Prestito>> PostPrestito(Prestito prestito)
        {
            _context.Prestitos.Add(prestito);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrestito", new { id = prestito.Id }, prestito);
        }

        // DELETE: api/Prestiti/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrestito(int id)
        {
            var prestito = await _context.Prestitos.FindAsync(id);
            if (prestito == null)
            {
                return NotFound();
            }

            _context.Prestitos.Remove(prestito);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PrestitoExists(int id)
        {
            return _context.Prestitos.Any(e => e.Id == id);
        }
    }
}

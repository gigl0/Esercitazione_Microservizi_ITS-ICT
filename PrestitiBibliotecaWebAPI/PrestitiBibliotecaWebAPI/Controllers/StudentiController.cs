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
    public class StudentiController : ControllerBase
    {
        private readonly PrestitiBibliotecaContext _context;

        public StudentiController(PrestitiBibliotecaContext context)
        {
            _context = context;
        }

        // GET: api/Studenti
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Studente>>> GetStudentes()
        {
            return await _context.Studentes.ToListAsync();
        }

        // GET: api/Studenti/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Studente>> GetStudente(int id)
        {
            var studente = await _context.Studentes.FindAsync(id);

            if (studente == null)
            {
                return NotFound();
            }

            return studente;
        }

        // PUT: api/Studenti/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudente(int id, Studente studente)
        {
            if (id != studente.Matricola)
            {
                return BadRequest();
            }

            _context.Entry(studente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudenteExists(id))
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

        // POST: api/Studenti
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Studente>> PostStudente(Studente studente)
        {
            _context.Studentes.Add(studente);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StudenteExists(studente.Matricola))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStudente", new { id = studente.Matricola }, studente);
        }

        // DELETE: api/Studenti/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudente(int id)
        {
            var studente = await _context.Studentes.FindAsync(id);
            if (studente == null)
            {
                return NotFound();
            }

            _context.Studentes.Remove(studente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudenteExists(int id)
        {
            return _context.Studentes.Any(e => e.Matricola == id);
        }
    }
}

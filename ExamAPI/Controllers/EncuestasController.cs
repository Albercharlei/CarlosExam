using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExamAPI.Data;
using ExamAPI.Models;

namespace ExamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncuestasController : ControllerBase
    {
        private readonly ExamAPIContext _context;

        public EncuestasController(ExamAPIContext context)
        {
            _context = context;
        }

        // GET: api/Encuestas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Encuestas>>> GetEncuestas()
        {
            return await _context.Encuestas.ToListAsync();
        }

        // GET: api/Encuestas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Encuestas>> GetEncuestas(int id)
        {
            var encuestas = await _context.Encuestas.FindAsync(id);

            if (encuestas == null)
            {
                return NotFound();
            }

            return encuestas;
        }

        // PUT: api/Encuestas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEncuestas(int id, Encuestas encuestas)
        {
            if (id != encuestas.IdEncuesta)
            {
                return BadRequest();
            }

            _context.Entry(encuestas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EncuestasExists(id))
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

        // POST: api/Encuestas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Encuestas>> PostEncuestas(Encuestas encuestas)
        {
            _context.Encuestas.Add(encuestas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEncuestas", new { id = encuestas.IdEncuesta }, encuestas);
        }

        // DELETE: api/Encuestas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEncuestas(int id)
        {
            var encuestas = await _context.Encuestas.FindAsync(id);
            if (encuestas == null)
            {
                return NotFound();
            }

            _context.Encuestas.Remove(encuestas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EncuestasExists(int id)
        {
            return _context.Encuestas.Any(e => e.IdEncuesta == id);
        }
    }
}

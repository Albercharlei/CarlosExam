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
    public class CamposController : ControllerBase
    {
        private readonly ExamAPIContext _context;

        public CamposController(ExamAPIContext context)
        {
            _context = context;
        }

        // GET: api/Campos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Campos>>> GetCampos()
        {
            return await _context.Campos.ToListAsync();
        }

        // GET: api/Campos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Campos>> GetCampos(int id)
        {
            var campos = await _context.Campos.FindAsync(id);

            if (campos == null)
            {
                return NotFound();
            }

            return campos;
        }

        // PUT: api/Campos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCampos(int id, Campos campos)
        {
            if (id != campos.IdCampo)
            {
                return BadRequest();
            }

            _context.Entry(campos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CamposExists(id))
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

        // POST: api/Campos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Campos>> PostCampos(Campos campos)
        {
            _context.Campos.Add(campos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCampos", new { id = campos.IdCampo }, campos);
        }

        // DELETE: api/Campos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCampos(int id)
        {
            var campos = await _context.Campos.FindAsync(id);
            if (campos == null)
            {
                return NotFound();
            }

            _context.Campos.Remove(campos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CamposExists(int id)
        {
            return _context.Campos.Any(e => e.IdCampo == id);
        }
    }
}

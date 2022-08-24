using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trasportistas_servicios.Models;

namespace Trasportistas_servicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrasportistumsController : ControllerBase
    {
        private readonly BD_TRASPORTISTASContext _context;

        public TrasportistumsController(BD_TRASPORTISTASContext context)
        {
            _context = context;
        }

        // GET: api/Trasportistums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trasportistum>>> GetTrasportista()
        {
          if (_context.Trasportista == null)
          {
              return NotFound();
          }
            return await _context.Trasportista.ToListAsync();
        }

        // GET: api/Trasportistums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trasportistum>> GetTrasportistum(int id)
        {
          if (_context.Trasportista == null)
          {
              return NotFound();
          }
            var trasportistum = await _context.Trasportista.FindAsync(id);

            if (trasportistum == null)
            {
                return NotFound();
            }

            return trasportistum;
        }

        // PUT: api/Trasportistums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrasportistum(int id, Trasportistum trasportistum)
        {
            if (id != trasportistum.Id)
            {
                return BadRequest();
            }

            _context.Entry(trasportistum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrasportistumExists(id))
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

        // POST: api/Trasportistums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Trasportistum>> PostTrasportistum(Trasportistum trasportistum)
        {
          if (_context.Trasportista == null)
          {
              return Problem("Entity set 'BD_TRASPORTISTASContext.Trasportista'  is null.");
          }
            _context.Trasportista.Add(trasportistum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrasportistum", new { id = trasportistum.Id }, trasportistum);
        }

        // DELETE: api/Trasportistums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrasportistum(int id)
        {
            if (_context.Trasportista == null)
            {
                return NotFound();
            }
            var trasportistum = await _context.Trasportista.FindAsync(id);
            if (trasportistum == null)
            {
                return NotFound();
            }

            _context.Trasportista.Remove(trasportistum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrasportistumExists(int id)
        {
            return (_context.Trasportista?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

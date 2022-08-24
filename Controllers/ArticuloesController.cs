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
    public class ArticuloesController : ControllerBase
    {
        private readonly BD_TRASPORTISTASContext _context;

        public ArticuloesController(BD_TRASPORTISTASContext context)
        {
            _context = context;
        }

        // GET: api/Articuloes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Articulo>>> GetArticulos()
        {
          if (_context.Articulos == null)
          {
              return NotFound();
          }
            return await _context.Articulos.ToListAsync();
        }

        // GET: api/Articuloes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Articulo>> GetArticulo(int id)
        {
          if (_context.Articulos == null)
          {
              return NotFound();
          }
            var articulo = await _context.Articulos.FindAsync(id);

            if (articulo == null)
            {
                return NotFound();
            }

            return articulo;
        }

        // PUT: api/Articuloes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticulo(int id, Articulo articulo)
        {
            if (id != articulo.Id)
            {
                return BadRequest();
            }

            _context.Entry(articulo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticuloExists(id))
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

        // POST: api/Articuloes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Articulo>> PostArticulo(Articulo articulo)
        {
          if (_context.Articulos == null)
          {
              return Problem("Entity set 'BD_TRASPORTISTASContext.Articulos'  is null.");
          }
            _context.Articulos.Add(articulo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArticulo", new { id = articulo.Id }, articulo);
        }

        // DELETE: api/Articuloes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticulo(int id)
        {
            if (_context.Articulos == null)
            {
                return NotFound();
            }
            var articulo = await _context.Articulos.FindAsync(id);
            if (articulo == null)
            {
                return NotFound();
            }

            _context.Articulos.Remove(articulo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArticuloExists(int id)
        {
            return (_context.Articulos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

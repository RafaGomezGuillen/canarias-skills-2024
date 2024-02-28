using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Authorization;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComensalController : ControllerBase
    {
        private readonly HotelContext _context;

        public ComensalController(HotelContext context)
        {
            _context = context;
        }

        // GET: api/Comensal
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Comensal>>> GetComensales()
        {
          if (_context.Comensales == null)
          {
              return NotFound();
          }
            return await _context.Comensales.ToListAsync();
        }

        // GET: api/Comensal/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Comensal>> GetComensal(int id)
        {
          if (_context.Comensales == null)
          {
              return NotFound();
          }
            var comensal = await _context.Comensales.FindAsync(id);

            if (comensal == null)
            {
                return NotFound();
            }

            return comensal;
        }

        // POST: api/Comensal
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<ActionResult<Comensal>> PostComensal(ComensalDto comensalDTO)
        {
            var mesasIDs = await _context.Mesas.Select(o => o.Id).ToArrayAsync();

            if (!mesasIDs.Contains(comensalDTO.IdMesa))
            {
                return BadRequest($"La mesa subida no es válida.");
            }

            Mesa mesa = _context.Mesas.Where(mesa => mesa.Id == comensalDTO.IdMesa).Select(m => new Mesa
            {
                Comensales = _context.Comensales.Where(comensal => comensal.IdMesa == m.Id).ToList()
            }).FirstOrDefault();
           
            if (mesa.Comensales.Count > mesa.Capacidad)
            {
                return BadRequest($"No se pueden subir más comensales a esta mesa. Está en su capacidad máxima");
            }

            Comensal comensal = new()
            {
                Nombre = comensalDTO.Nombre,
                IdMesa = comensalDTO.IdMesa,
            };

            _context.Comensales.Add(comensal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComensal", new { id = comensal.Id }, comensal);
        }

        // DELETE: api/Comensal/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Authorize]
        public async Task<IActionResult> DeleteComensal(int id)
        {
            if (_context.Comensales == null)
            {
                return NotFound("Los comensales no han sido encontrados.");
            }

            var comensal = await _context.Comensales.FindAsync(id);
            
            if (comensal == null)
            {
                return NotFound($"El comensal con id: {id} no ha sido encontrado.");
            }

            _context.Comensales.Remove(comensal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComensalExists(int id)
        {
            return (_context.Comensales?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

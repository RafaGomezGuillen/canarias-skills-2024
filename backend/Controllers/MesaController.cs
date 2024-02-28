using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Models;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesaController : ControllerBase
    {
        private readonly HotelContext _context;

        public MesaController(HotelContext context)
        {
            _context = context;
        }

        // GET: api/Mesa
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Mesa>>> GetMesas()
        {
            if (_context.Mesas == null)
            {
                return NotFound("Las mesas no han sido encontradas.");
            }

            var mesas = await _context.Mesas.Select(s => new Mesa
            {
                Id = s.Id,
                NumeroMesa = s.NumeroMesa,
                Capacidad = s.Capacidad,
                IdSala = s.IdSala,
                Sala = _context.Salas.Where(sala => sala.Id == s.IdSala).Select(s => new Sala
                {
                    Id = s.Id,
                    Nombre = s.Nombre,
                    AforoMax = s.AforoMax,
                    AforoMin = s.AforoMin,
                    EstaReservada = s.EstaReservada,
                    Route = s.Route,
                    RouteLocalhost = s.RouteLocalhost,
                }).FirstOrDefault(),
                Comensales = _context.Comensales.Where(comensal => comensal.IdMesa == s.Id).ToList()
            }).ToListAsync();

            return Ok(mesas);
        }

        // GET: api/Mesa/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Mesa>> GetMesa(int id)
        {
            if (_context.Mesas == null)
            {
                return NotFound("Las mesas no han sido encontradas.");
            }

            var mesa = await _context.Mesas.Where(o => o.Id == id).Select(s => new Mesa
            {
                Id = s.Id,
                NumeroMesa = s.NumeroMesa,
                Capacidad = s.Capacidad,
                IdSala = s.IdSala,
                Sala = _context.Salas.Where(sala => sala.Id == s.IdSala).Select(s => new Sala
                {
                    Id = s.Id,
                    Nombre = s.Nombre,
                    AforoMax = s.AforoMax,
                    AforoMin = s.AforoMin,
                    EstaReservada = s.EstaReservada,
                    Route = s.Route,
                    RouteLocalhost = s.RouteLocalhost,
                }).FirstOrDefault(),
                Comensales = _context.Comensales.Where(comensal => comensal.IdMesa == s.Id).ToList()
            }).FirstOrDefaultAsync();

            if (mesa == null)
            {
                return NotFound($"La mesa con id: {id} no ha sido encontrada.");
            }

            return mesa;
        }

        // PUT: api/Mesa/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutMesa(int id, MesaDto mesaDTO)
        {
            var mesa = await _context.Mesas.FindAsync(id);

            if (mesa == null)
            {
                return NotFound($"La mesa con id: {id} no ha sido encontrada.");
            }

            var salasIDs = await _context.Salas.Select(o => o.Id).ToArrayAsync();

            if (!salasIDs.Contains(mesaDTO.IdSala))
            {
                return BadRequest($"La sala subida no es válida.");
            }

            mesa.Capacidad = mesaDTO.Capacidad;
            mesa.IdSala = mesaDTO.IdSala;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!MesaExists(id))
            {
                return NotFound($"La mesa con id: {id} no ha sido encontrada.");
            }

            return Ok(mesa);
        }

        // POST: api/Mesa
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Mesa>> PostMesa(MesaDto mesaDTO)
        {
            var salasIDs = await _context.Salas.Select(o => o.Id).ToArrayAsync();

            if (!salasIDs.Contains(mesaDTO.IdSala))
            {
                return BadRequest($"La sala subida no es válida.");
            }

            Mesa mesa = new()
            {
                Capacidad = mesaDTO.Capacidad,
                IdSala = mesaDTO.IdSala,
            };

            _context.Mesas.Add(mesa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMesa", new { id = mesa.Id }, mesa);
        }

        // DELETE: api/Mesa/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteMesa(int id)
        {
            if (_context.Mesas == null)
            {
                return NotFound("Las mesas no han sido encontradas.");
            }

            var mesa = await _context.Mesas.Include(o => o.Comensales).FirstOrDefaultAsync(a => a.Id == id);

            if (mesa == null)
            {
                return NotFound($"La mesa con id: {id} no ha sido encontrada.");
            }

            _context.Mesas.Remove(mesa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MesaExists(int id)
        {
            return (_context.Mesas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

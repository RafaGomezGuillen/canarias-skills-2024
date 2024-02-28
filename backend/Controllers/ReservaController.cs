using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Authorization;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly HotelContext _context;

        public ReservaController(HotelContext context)
        {
            _context = context;
        }

        // GET: api/Reserva
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Reserva>>> GetReservas()
        {
            if (_context.Reservas == null)
            {
                return NotFound("Las reservas no han sido encontradas.");
            }

            var reservas = await _context.Reservas.Select(r => new Reserva
            {
                Id = r.Id,
                Nombre = r.Nombre,
                Invitados = r.Invitados,
                Date = r.Date,
                Username = r.Username,
                IdSala = r.IdSala,
                Sala = _context.Salas.Where(sala => sala.Id == r.IdSala).Select(s => new Sala
                {
                    Id = s.Id,
                    Nombre = s.Nombre,
                    AforoMax = s.AforoMax,
                    AforoMin = s.AforoMin,
                    EstaReservada = s.EstaReservada,
                    Route = s.Route,
                    RouteLocalhost = s.RouteLocalhost,
                }).FirstOrDefault()
            }).ToListAsync();

            return Ok(reservas);
        }

        // GET: api/Reserva/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<ActionResult<Reserva>> GetReserva(int id)
        {
            if (_context.Reservas == null)
            {
                return NotFound("Las salas no han sido encontradas.");
            }

            var reserva = await _context.Reservas.Where(o => o.Id == id).Select(r => new Reserva
            {
                Id = r.Id,
                Nombre = r.Nombre,
                Invitados = r.Invitados,
                Date = r.Date,
                Username = r.Username,
                IdSala = r.IdSala,
                Sala = _context.Salas.Where(sala => sala.Id == r.IdSala).Select(s => new Sala
                {
                    Id = s.Id,
                    Nombre = s.Nombre,
                    AforoMax = s.AforoMax,
                    AforoMin = s.AforoMin,
                    EstaReservada = s.EstaReservada,
                    Route = s.Route,
                    RouteLocalhost = s.RouteLocalhost,
                }).FirstOrDefault()
            }).FirstOrDefaultAsync();

            if (reserva == null)
            {
                return NotFound($"La reserva con id: {id} no ha sido encontrada.");
            }

            return reserva;
        }

        // PUT: api/Reserva/5
        /// <param name="reservaDTO">El formato de la fecha debe ser año-mes-dia (yyyy-MM-dd).</param>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<IActionResult> PutReserva(int id, ReservaDto reservaDTO)
        {
            var reserva = await _context.Reservas.FindAsync(id);

            if (reserva == null)
            {
                return NotFound($"La reserva con id: {id} no ha sido encontrada.");
            }

            var salasIDs = await _context.Salas.Select(o => o.Id).ToArrayAsync();

            if (!salasIDs.Contains(reservaDTO.IdSala))
            {
                return BadRequest($"La sala subida no es válida.");
            }

            var usernames = await _context.Users.Select(o => o.UserName).ToArrayAsync();

            if (!usernames.Contains(reserva.Username))
            {
                return BadRequest($"El usuario subido no es válido.");
            }

            Sala sala = _context.Salas.Where(sala => sala.Id == reservaDTO.IdSala).Select(s => new Sala
            {
                Id = s.Id,
                Nombre = s.Nombre,
                AforoMax = s.AforoMax,
                AforoMin = s.AforoMin,
                EstaReservada = s.EstaReservada,
                Route = s.Route,
                RouteLocalhost = s.RouteLocalhost,
            }).FirstOrDefault();

            if (reservaDTO.Invitados < sala.AforoMin)
            {
                return BadRequest($"El número de invitados es menor que el aforo mínimo de {sala.Nombre}");
            }

            if (reservaDTO.Invitados > sala.AforoMax)
            {
                return BadRequest($"El número de invitados es mayor que el aforo máximo de {sala.Nombre}");
            }

            reserva.Nombre = reservaDTO.Nombre;
            reserva.Invitados = reservaDTO.Invitados;
            reserva.Date = reservaDTO.Date;
            reserva.Username = reservaDTO.Username;
            reserva.IdSala = reservaDTO.IdSala;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!ReservaExists(id))
            {
                return NotFound($"La reserva con id: {id} no ha sido encontrada.");
            }

            return Ok(reserva);
        }

        // POST: api/Reserva
        /// <param name="reservaDTO">El formato de la fecha debe ser año-mes-dia (yyyy-MM-dd).</param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<ActionResult<Reserva>> PostReserva(ReservaDto reservaDTO)
        {
            var salasIDs = await _context.Salas.Select(o => o.Id).ToArrayAsync();

            if (!salasIDs.Contains(reservaDTO.IdSala))
            {
                return BadRequest($"La sala subida no es válida.");
            }

            var usernames = await _context.Users.Select(o => o.UserName).ToArrayAsync();

            if (!usernames.Contains(reservaDTO.Username))
            {
                return BadRequest($"El usuario subido no es válido.");
            }

            Sala sala = _context.Salas.Where(sala => sala.Id == reservaDTO.IdSala).FirstOrDefault();

            if (reservaDTO.Invitados < sala.AforoMin)
            {
                return BadRequest($"El número de invitados es menor que el aforo mínimo de {sala.Nombre}");
            }

            if (reservaDTO.Invitados > sala.AforoMax)
            {
                return BadRequest($"El número de invitados es mayor que el aforo máximo de {sala.Nombre}");
            }

            Reserva reserva = new()
            {
                Nombre = reservaDTO.Nombre,
                Invitados = reservaDTO.Invitados,
                Date = reservaDTO.Date,
                Username = reservaDTO.Username,
                IdSala = reservaDTO.IdSala,
            };

            sala.EstaReservada = true;

            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReserva", new { id = reserva.Id }, reserva);
        }

        // DELETE: api/Reserva/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Authorize]
        public async Task<IActionResult> DeleteReserva(int id)
        {
            if (_context.Reservas == null)
            {
                return NotFound("Las reservas no han sido encontradas.");
            }

            var reserva = await _context.Reservas.FindAsync(id);

            if (reserva == null)
            {
                return NotFound($"La reserva con id: {id} no ha sido encontrada.");
            }

            Sala sala = _context.Salas.Where(sala => sala.Id == reserva.IdSala).FirstOrDefault();

            sala.EstaReservada = false;

            _context.Reservas.Remove(reserva);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReservaExists(int id)
        {
            return (_context.Reservas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

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
    public class SalaController : ControllerBase
    {
        private readonly HotelContext _context;

        public SalaController(HotelContext context)
        {
            _context = context;
        }

        // GET: api/Sala
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Sala>>> GetSalas()
        {
            if (_context.Salas == null)
            {
                return NotFound("Las salas no han sido encontradas.");
            }

            var salas = await _context.Salas.Select(s => new Sala
            {
                Id = s.Id,
                Nombre = s.Nombre,
                AforoMax = s.AforoMax,
                AforoMin = s.AforoMin,
                EstaReservada = s.EstaReservada,
                Route = s.Route,
                RouteLocalhost = s.RouteLocalhost,
                Reserva = _context.Reservas.Where(reserva => reserva.IdSala == s.Id).ToList(),
                Mesas = _context.Mesas.Where(mesa => mesa.IdSala == s.Id).Select(s => new Mesa
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
                }).ToList(),
            }).ToListAsync();

            return Ok(salas);
        }

        // GET: api/Sala/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Sala>> GetSala(int id)
        {
            if (_context.Salas == null)
            {
                return NotFound("Las salas no han sido encontradas.");
            }

            var sala = await _context.Salas.Where(o => o.Id == id).Select(s => new Sala
            {
                Id = s.Id,
                Nombre = s.Nombre,
                AforoMax = s.AforoMax,
                AforoMin = s.AforoMin,
                EstaReservada = s.EstaReservada,
                Route = s.Route,
                RouteLocalhost = s.RouteLocalhost,
                Reserva = _context.Reservas.Where(reserva => reserva.IdSala == s.Id).ToList(),
                Mesas = _context.Mesas.Where(mesa => mesa.IdSala == s.Id).Select(s => new Mesa
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
                }).ToList(),
            }).FirstOrDefaultAsync();

            if (sala == null)
            {
                return NotFound($"La sala con id: {id} no ha sido encontrada.");
            }

            return sala;
        }

        private bool SalaExists (int id)
        {
            return (_context.Salas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

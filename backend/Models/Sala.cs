using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Sala
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public int AforoMax { get; set; }

        public int AforoMin { get; set; }

        public bool EstaReservada { get; set; }  

        public string Route { get; set; }

        public string RouteLocalhost { get; set; }
        public virtual List<Reserva>? Reserva { get; set; }
    }
}

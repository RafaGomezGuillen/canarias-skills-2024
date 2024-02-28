using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Reserva
    {
        [Key]
        public int Id { get; set; }

        public string Nombre { get; set; }

        public int Invitados { get; set; }

        public DateTime Date { get; set; }

        public string Username { get; set; }

        public int IdSala { get; set; }

        public virtual Sala? Sala { get; set; }
    }

    public class ReservaDto
    {
        [Required(ErrorMessage = "Nombre es requerido.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Introduce un nombre en 3 y 50 caracteres.")]
        public string Nombre { get; set; }

        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Introduce un número mínimo de invitados de 1.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "El número de invitados debe ser un número entero positivo.")]
        public int Invitados { get; set; }

        [Required(ErrorMessage = "Fecha es requerida.")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Nombre de usuario es requerido.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "ID de la sala es requerida.")]
        public int IdSala { get; set; }
    }
}

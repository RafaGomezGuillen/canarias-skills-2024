using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Mesa
    {
        [Key]
        public int Id { get; set; }

        public int NumeroMesa { get; set; }

        public int Capacidad { get; set; }

        public int IdSala { get; set; }
        public virtual Sala? Sala { get; set; }

        public virtual List<Comensal> Comensales { get; set; } = new List<Comensal>();
    }

    public class MesaDto
    {
        [Range(minimum: 0, maximum: int.MaxValue, ErrorMessage = "El número de la mesa debe ser un número entero positivo.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "El número de la mesa debe ser un número entero positivo.")]
        [Required(ErrorMessage = "El número de la mesa es requerido.")]
        public int NumeroMesa { get; set; }

        [Range(minimum: 0, maximum: int.MaxValue, ErrorMessage = "La capacidad de la mesa debe ser un número entero positivo.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "La capacidad de la mesa debe ser un número entero positivo.")]
        [Required(ErrorMessage = "La capacidad es requerido.")]
        public int Capacidad { get; set; }

        [Required(ErrorMessage = "El ID de la sala es requerido.")]
        public int IdSala { get; set; }
    }
}

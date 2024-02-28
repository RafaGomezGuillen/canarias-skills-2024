using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Comensal
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; } 
        public int IdMesa { get; set; }
        public virtual Mesa? Mesa { get; set; }
    }

    public class ComensalDto
    {
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Introduce un nombre entre 50 y 3 carácteres.")]
        [Required(ErrorMessage = "El nombre del comensal es requerido.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El ID de la mesa es requerido.")]
        public int IdMesa { get; set; }
    }
}

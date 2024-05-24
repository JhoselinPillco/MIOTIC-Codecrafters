using MIOTIC.Dto;
using System.ComponentModel.DataAnnotations;

namespace MIOTIC.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string?  Nombre { get; set; }
        [Required]
        public RolEnum Rol { get; set;}

        //relaciones  1------>*
        public virtual List<Contrato>? Contratos { get; set; }
    }
}

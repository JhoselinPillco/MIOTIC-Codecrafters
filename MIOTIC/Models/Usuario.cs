/*using MIOTIC.Dto;
using System.ComponentModel.DataAnnotations;

namespace MIOTIC.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required, MinLength(5)]
        public string? Email { get; set; }
        [Required, MinLength(5)]
        public string? Password { get; set; }
        [Required, MinLength(3)]
        public string?  Nombre { get; set; }
        [Required]
        public RolEnum Rol { get; set;}

        //Un Usuario registra muchos contratos
        //relaciones  1------>*
        public virtual List<Contrato>? Contratos { get; set; }
    }
}
*/
using MIOTIC.Dto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MIOTIC.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required, MinLength(5)]
        public string? Email { get; set; }
        [Required, MinLength(5)]
        public string? Password { get; set; }
        [Required, MinLength(3)]
        public string? Nombre { get; set; }
        [Required]
        public RolEnum Rol { get; set; }
        public string? Foto { get; set; }
        //para archivos
        [NotMapped]
        [Display(Name = "Subir Fotos")]
        public IFormFile? FotoFile { get; set; }
        //Un Usuario registra muchos contratos
        //relaciones  1------>*
        public virtual List<Contrato>? Contratos { get; set; }
    }
}
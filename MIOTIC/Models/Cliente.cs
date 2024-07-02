using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MIOTIC.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Nombre { get; set; }
        [Required]
        public int Ci { get; set; }
        [Required]
        public int Celular { get; set; }
        [Required]
        public string? Email { get; set; }
        public string? Foto { get; set; }
        [NotMapped]
        [Display(Name = "subir la foto")]
        public IFormFile? FotoFile { get; set; }

        //relaciones  1------>*
        public virtual List<Contrato>? Contratos { get; set; }
    }
}

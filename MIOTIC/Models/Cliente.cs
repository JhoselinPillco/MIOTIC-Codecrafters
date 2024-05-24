using System.ComponentModel.DataAnnotations;

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
        public string? Foto { get;}
        public string? Email { get; set; }

        //relaciones  1------>*
        public virtual List<Contrato>? Contratos { get; set; }
    }
}

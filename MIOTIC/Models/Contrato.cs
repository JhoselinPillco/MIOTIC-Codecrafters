using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MIOTIC.Models
{
    public class Contrato
    {
        [Key]
        public int Id { get; set; }
        
        public string? NombreProyecto { get; set; }
        [Required]
        public DateTime FechaContrato { get; set;  }
        [Required]
        public DateTime FechaEntrega { get; set; }
        [Required]
        public int Numero { get; set; }
        [Column(TypeName = "date")]
        public decimal Costo { get; set; }
        [Required]

        //relaciones  *--------->1
        public int ClienteId { get; set; }
        public virtual Cliente? Cliente { get; set; }

        public int UsuarioId { get; set; }
        public virtual Usuario? Usuario { get; set; }



    }
}

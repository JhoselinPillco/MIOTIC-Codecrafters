﻿using System.ComponentModel.DataAnnotations;

namespace MIOTIC.Models
{
    public class Contrato
    {
        [Key]
        public int Id { get; set; }
        public string? NombreProycto { get; set; }
        [Required]
        public DateOnly FechaContrato { get;}
        [Required]
        public DateOnly FechaEntrega { get; }
        [Required]
        public decimal Costo { get; set; }
        [Required]
        //relaciones  *--------->1
        public int UsuarioId { get; set; }
        public int ClienteId { get; set; }
        public virtual Usuario? Usuario { get; set; }   
        public virtual Cliente? Cliente { get; set; }


    }
}

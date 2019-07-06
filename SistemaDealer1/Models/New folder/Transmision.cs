using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace SistemaDealer1.Models
{   [Bind(Exclude = "TransmisionId")]
    public class Transmision
    {
        [Key]
        [ScaffoldColumn(false)]
        public int TransmisionId { get; set; }
        [Required(ErrorMessage = "Por favor insertar la transmision nueva"), MaxLength(30)]
        [StringLength(30, ErrorMessage = "Por favor introduzca 30 caracteres o menos")]
        [Display(Name = "Tipo de Transmision")]
        public string Descripcion { get; set; }
    }
}
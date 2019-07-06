using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


namespace SistemaDealer1.Models
{
    [Bind(Exclude = "CombustibleId")]
    public class Combustible
    {
        [Key]
        [ScaffoldColumn(false)]
        public int CombustibleId { get; set; }
        [Required(ErrorMessage = "Por favor insertar el tipo de combustible nuevo")]
        [StringLength(30, ErrorMessage = "Por favor introduzca 30 caracteres o menos")]
        [Display(Name = "Tipo de Combustible")]
        public string Descripcion { get; set; }
    }
}
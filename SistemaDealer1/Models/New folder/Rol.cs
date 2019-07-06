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
    [Bind(Exclude = "RolId")]
    public class Rol
    {
        [Key]
        [ScaffoldColumn(false)]
        public int RolId { get; set; }
        [Required(ErrorMessage = "Por favor insertar el rol nuevo"), MaxLength(30)]
        [StringLength(30, ErrorMessage = "Por favor introduzca 30 caracteres o menos")]
        [Display(Name = "Rol")]
        public string Descripcion { get; set; }

        public ICollection<Empleado> Empleados { get; set; }
    }
}
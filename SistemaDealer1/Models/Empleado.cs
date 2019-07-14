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
    [Bind(Exclude = "EmpleadoID")]
    public class Empleado : Personas
    {
        [Key]
        [ScaffoldColumn(false)]
        public int EmpleadoId { get; set; }
        [Display(Name = "Rol")]
        public int RolId { get; set; }
        [Required(ErrorMessage = "Por favor insertar el Usuario Nuevo")]
        [StringLength(30, ErrorMessage = "Por favor introduzca 30 caracteres o menos")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "Por favor insertar una Contraseña")]
        [StringLength(20, ErrorMessage = "Por favor introduzca 20 caracteres o menos")]
        public string Contraseña { get; set; }

        [ForeignKey("RolId")]
        public Rol Rol { get; set; }

        public ICollection<Factura> Facturas { get; set; }
    }
}
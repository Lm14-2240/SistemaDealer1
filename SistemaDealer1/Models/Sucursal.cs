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
    [Bind(Exclude = "SucursalID")]
    public class Sucursal
    {
        [Key]
        [ScaffoldColumn(false)]
        public int SucursalId { get; set; }
        [Display(Name = "Encargado")]
        public int EmpleadoId { get; set; }
        [Required(ErrorMessage = "Por favor insertar la Ubicacion"), MaxLength(30)]
        [StringLength(30, ErrorMessage = "Por favor introduzca 30 caracteres o menos")]
        public string Ubicacion { get; set; }
        [Required(ErrorMessage = "Por favor insertar el Telefono"), MaxLength(30)]
        [StringLength(30, ErrorMessage = "Por favor introduzca 30 caracteres o menos")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Por favor insertar el Correo Electronico"), MaxLength(30)]
        [StringLength(30, ErrorMessage = "Por favor introduzca 30 caracteres o menos")]
        [Display(Name = "Correo Electronico")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        public string Correo { get; set; }

        [ForeignKey("EmpleadoId")]
        public Empleado Encargado { get; set; }
    }
}
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
    [Bind(Exclude = "FacturaID")]
    public class Factura
    {
        [Key]
        [ScaffoldColumn(false)]
        public int FacturaId { get; set; }
        [Display(Name = "Empleado")]
        public int EmpleadoId { get; set; }
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }
        [Required(ErrorMessage = "Por favor insertar el Metodo de Pago")]
        [StringLength(30, ErrorMessage = "Por favor introduzca 30 caracteres o menos")]
        [Display(Name = "Metodo de Pago")]
        public string MetodoPago { get; set; }
        [Required(ErrorMessage = "Por favor insertar el Precio total")]
        public decimal PrecioTotal { get; set; }
        [Required(ErrorMessage = "Por favor insertar la fecha")]
        [Display(Name = "Fecha de Venta")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
       
        [ForeignKey("EmpleadoId")]
        public Empleado Empleado { get; set; }
        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }
    }
}

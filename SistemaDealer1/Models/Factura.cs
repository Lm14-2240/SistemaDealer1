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

        [Display(Name = "Vehiculo")]
        public int VehiculoId { get; set; }

        [Required(ErrorMessage = "Por favor insertar el Metodo de Pago")]
        [Display(Name = "Metodo de Pago")]
        public MetodosDePago MetodoPago { get; set; }

        [Required(ErrorMessage = "Por favor insertar el Precio total")]
        public decimal PrecioTotal { get; set; }

        [Required(ErrorMessage = "Por favor insertar la fecha")]
        [Display(Name = "Fecha de Venta")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; } = DateTime.Now;
       
        [ForeignKey("EmpleadoId")]
        public Empleado Empleado { get; set; }

        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }

        [ForeignKey("VehiculoId")]
        public Vehiculo Vehiculo { get; set; }

        public decimal PrecioUnitario { get; set; }
    }

    public enum MetodosDePago
    {
        Efectivo,
        Tarjeta
    }
}

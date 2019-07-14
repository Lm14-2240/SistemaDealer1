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
    public class Movimiento
    {
        [Key]
        [ScaffoldColumn(false)]
        public int MovimientoId { get; set; }

        [Required(ErrorMessage = "Por favor insertar el tipo de movimiento")]
        [StringLength(30, ErrorMessage = "Por favor introduzca 30 caracteres o menos")]
        public string Tipo_Movimiento { get; set; }

        [Required(ErrorMessage = "Por favor insertar la Cantidad comprada/vendida")]
        [Display(Name = "Cantidad Comprada/Vendida")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "Por favor insertar el Vehiculo")]
        [Display(Name = "Vehiculo")]
        public int VehiculoId { get; set; }

        [Display(Name = "Proveedor")]
        public int ProveedorId { get; set; }

        [Required(ErrorMessage = "Por favor insertar el Vehiculo")]
        [Display(Name = "Empleado")]
        public int EmpleadoId { get; set; }

        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }

        [ForeignKey("VehiculoId")]
        public Vehiculo Vehiculo { get; set; }
        [ForeignKey("ProveedorId")]
        public Proveedor Proveedor { get; set; }
        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }
        [ForeignKey("EmpleadoId")]
        public Empleado Empleado { get; set; }
    }
}
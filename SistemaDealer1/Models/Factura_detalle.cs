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
    public class Factura_Detalle
    {
        [Key]
        [ScaffoldColumn(false)]
        public int FacturaDetalleId { get; set; }

        [Required(ErrorMessage = "Por favor insertar el vehiculo")]
        [Display(Name = "Vehiculo")]
        public int VehiculoId { get; set; }

        [Required(ErrorMessage = "Por favor insertar la factura del vehiculo")]
        [Display(Name = "Factura")]
        public int FacturaId { get; set; }

        [Required(ErrorMessage = "Por favor insertar el precio por unidad del vehiculo")]
        [Display(Name = "Precio por Unidad")]
        public decimal PrecioUnidad { get; set; }

        [Required(ErrorMessage = "Por favor insertar la cantidad del vehiculos")]
        [Display(Name = "Cantidad")]
        public int Cantidad { get; set; }

        
        [Display(Name = "SubTotal")]
        public int SubTotal { get; set; }

        [ForeignKey("VehiculoId")]
        public Vehiculo Vehiculo { get; set; }
        [ForeignKey("FacturaId")]
        public Factura Factura { get; set; }
    }
}
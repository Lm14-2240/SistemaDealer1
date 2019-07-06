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
    public class Factura_detalle
    {
        [Display(Name = "Factura")]
        public int FacturaID { get; set; }
        [Display(Name = "Vehiculo")]
        public int VehiculoID { get; set; }
        [Required(ErrorMessage = "Por favor insertar el precio unitario del Vehiculo")]
        [Display(Name = "Precio Unitario")]
        public int PrecioUnitario { get; set; }
        [Required(ErrorMessage = "Por favor insertar la cantidad de vehiculos")]
        public int Cantidad { get; set; }
        public int Descuento { get; set; }

        [ForeignKey ("FacturaID")]
        public Factura Factura { get; set; }
        [ForeignKey("VehiculoID")]
        public Vehiculo Vehiculo { get; set; }

    }
}
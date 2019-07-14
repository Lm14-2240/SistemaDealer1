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
        public int FacturaDetalleId { get; set; }
        public int VehiculoId { get; set; }
        public int FacturaId { get; set; }
        public decimal PrecioUnidad { get; set; }
        public int Cantidad { get; set; }
        public int SubTotal { get; set; }

        [ForeignKey("VehiculoId")]
        public Vehiculo Vehiculo { get; set; }
        [ForeignKey("FacturaId")]
        public Factura Factura { get; set; }
    }
}
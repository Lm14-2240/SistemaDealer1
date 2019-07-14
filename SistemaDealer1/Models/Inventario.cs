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
    public class Inventario
    {
        [Key]
        [ScaffoldColumn(false)]
        public int InventarioId { get; set; }

        [Required(ErrorMessage = "Por favor insertar Cantidad en Existencia")]
        public int CantidadExistencia { get; set; }

        [Required(ErrorMessage = "Por favor insertar el Vehiculo")]
        [Display(Name = "Vehiculo")]
        public int VehiculoId { get; set; }

        [ForeignKey("VehiculoId")]
        public Vehiculo Vehiculo { get; set; }
    }
}
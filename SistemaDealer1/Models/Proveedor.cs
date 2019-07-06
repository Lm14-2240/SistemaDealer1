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
    public class Proveedor
    {
        [Key]
        [ScaffoldColumn(false)]
        public int ProveedorId { get; set; }

        [Required(ErrorMessage = "Por favor insertar el estatus")]
        [StringLength(30, ErrorMessage = "Por favor introduzca 30 caracteres o menos")]
        public string Estatus { get; set; }

        [Required(ErrorMessage = "Por favor insertar la Fecha")]
        //[StringLength(30, ErrorMessage = "Por favor introduzca 30 caracteres o menos")]
        [Display(Name = "Fecha")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Por favor insertar la cedula/pasaporte del Proveedor")]
        [StringLength(30, ErrorMessage = "Por favor introduzca 30 caracteres o menos")]
        [Display(Name = "Cedula/Pasaporte")]
        public string CedulaPasaporte { get; set; }

        [Required(ErrorMessage = "Por favor insertar el Telefono")]
        [StringLength(30, ErrorMessage = "Por favor introduzca 30 caracteres o menos")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Por favor insertar la ubicacion del Proveedor")]
        [StringLength(30, ErrorMessage = "Por favor introduzca 30 caracteres o menos")]
        public string Ubicacion { get; set; }


        public ICollection<Reserva> Reservas { get; set; }
        public ICollection<Factura> Facturas { get; set; }
    }
}
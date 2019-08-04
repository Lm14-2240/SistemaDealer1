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
    [Bind(Exclude = "ClienteID")]
    public class Cliente : Personas
    {
        [Key]
        [ScaffoldColumn(false)]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Por favor insertar el estatus")]
        [StringLength(30, ErrorMessage = "Por favor introduzca 30 caracteres o menos")]
        public string Estatus { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Por favor insertar la Fecha de Nacimiento")]
        //[StringLength(30, ErrorMessage = "Por favor introduzca 30 caracteres o menos")]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Por favor insertar la cedula/pasaporte del Cliente")]
        [StringLength(30, ErrorMessage = "Por favor introduzca 30 caracteres o menos")]
        [Display(Name = "Cedula/Pasaporte")]
        public string CedulaPasaporte { get; set; }

        [Required(ErrorMessage = "Por favor insertar el Telefono")]
        [StringLength(30, ErrorMessage = "Por favor introduzca 30 caracteres o menos")]
        public string Telefono { get; set; }
        
        public ICollection<Factura> Facturas { get; set; }
        public ICollection<Movimiento> Movimiento { get; set; }

    }
}
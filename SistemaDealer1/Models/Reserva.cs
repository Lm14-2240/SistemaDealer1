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
    [Bind(Exclude = "ReservaId")]
    public class Reserva
    {
        [Key]
        [ScaffoldColumn(false)]
        public int ReservaId { get; set; }
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }
        [Display(Name = "Empleado")]
        public int EmpleadoId { get; set; }
        [Display(Name = "Vehiculo")]
        public int VehiculoId { get; set; }

        [Required(ErrorMessage = "Por favor insertar la fecha")]
        //[StringLength(30, ErrorMessage = "Por favor introduzca 30 caracteres o menos")]
        [Display(Name = "Fecha de Inicio")]
        [DataType(DataType.Date)]
        public DateTime FechaReserva { get; set; }

        [Required(ErrorMessage = "Por favor insertar la fecha")]
        //[StringLength(30, ErrorMessage = "Por favor introduzca 30 caracteres o menos")]
        [Display(Name = "Fecha de Final")]
        [DataType(DataType.Date)]
        public DateTime FechaVencimiento { get; set; }
        [Required(ErrorMessage = "Por favor insertar el estatus de la reserva")]
        [StringLength(30, ErrorMessage = "Por favor introduzca 30 caracteres o menos")]
        [Display(Name = "Estatus de la Reserva")]
        public string Estatus { get; set; }

        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }
        [ForeignKey("EmpleadoId")]
        public Empleado Empleado { get; set; }
        [ForeignKey("VehiculoId")]
        public Vehiculo Vehiculo { get; set; }
    }
}
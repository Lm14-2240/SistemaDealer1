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
    public class Personas
    {

        [Required(ErrorMessage = "Por favor insertar nombre")]
        [StringLength(30, ErrorMessage = "Por favor introduzca 30 caracteres o menos")]
        static public string Nombre { get; set; }

        [Required(ErrorMessage = "Por favor insertar apellido")]
        [StringLength(30, ErrorMessage = "Por favor introduzca 30 caracteres o menos")]
        static public string Apellido { get; set; }

        [Required(ErrorMessage = "Por favor insertar el Correo Electronico")]
        [StringLength(30, ErrorMessage = "Por favor introduzca 30 caracteres o menos")]
        [Display(Name = "Correo Electronico")]
        public string Correo { get; set; }

    }
}
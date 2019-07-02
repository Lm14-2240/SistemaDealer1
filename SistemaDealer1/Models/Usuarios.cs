using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaDealer1.Models
{
    public class Usuarios : Personas
    {
        [Key]
        public string Id { get; set; }
        public string Rol { get; set; }
        public string Contrasena { get; set; }
    }
}
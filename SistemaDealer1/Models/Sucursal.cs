using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaDealer1.Models
{
    public class Sucursal
    {
        [Key]
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
        public string Zona { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Representante { get; set; }
        public string Comentario { get; set; }
    }
}
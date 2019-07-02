using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaDealer1.Models
{
    public class Personas
    {
        [Key]
        public string Id { get; set;}
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int CedulaPasaporte { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public char Genero { get; set; }
        public bool Estatus { get; set; }
            
    }
}
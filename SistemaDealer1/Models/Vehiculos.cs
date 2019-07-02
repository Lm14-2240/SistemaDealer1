using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaDealer1.Models
{
    public class Vehiculos
    {
        [Key]
        public string Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public DateTime Anio { get; set; }
        public string Transmision { get; set; }
        public string Color { get; set; }
        public string Pais { get; set; }
        public int Puertas  { get; set; }
        public int CantidadExistente { get; set; }
        public bool Estatus { get; set; }
    }
}
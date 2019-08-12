using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaDealer1.Models
{
    public class VehiculoDTO
    {
        public virtual Vehiculo Vehiculo { get; set; }
        public string MarcaNombre { get; set; }
        public string ModeloNombre { get; set; }
    }
}
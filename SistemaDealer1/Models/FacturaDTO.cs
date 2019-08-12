using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaDealer1.Models
{
    public class FacturaDTO
    {
        public int VehiculoId { get; set; }
        public List<VehiculoDTO> VehiculoE { get; set; }
        public List<Cliente> Cliente { get; set; }
        public List<Empleado> Empleado { get; set; }
    }
}
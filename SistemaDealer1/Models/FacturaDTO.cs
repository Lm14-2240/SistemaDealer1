using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaDealer1.Models
{
    public class FacturaDTO
    {
        public Factura factura { get; set; }
        public List<Cliente> clientes { get; set; }
        public List<Empleado> usuario { get; set; }

    }
}
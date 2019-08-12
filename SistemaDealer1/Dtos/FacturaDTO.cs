using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaDealer1.Models
{
    public class FacturaDTO
    {
        public Factura Factura { get; set; }
        public List<Cliente> Clientes { get; set; }
        public List<Empleado> Usuarios { get; set; }

        public List<Vehiculo> Vehiculos { get; set; }

    }
}
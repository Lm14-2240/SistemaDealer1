using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaDealer1.Models
{
    public class Reserva
    {
        [Key]
        public string Id { get; set; }
        public string IdCliente { get; set; }
        public string IdVehiculo { get; set; }
        public DateTime FechaReserva { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public bool Estatus { get; set; }
    }
}
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaDealer1.Models
{
    public class TipoVehiculo
    {
        [Key]
        public string Id { get; set; }
        public string Descripcion { get; set; }
    }
}
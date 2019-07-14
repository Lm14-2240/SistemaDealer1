using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace SistemaDealer1.Models
{
    [Bind(Exclude = "VehiculoID")]
    public class Vehiculo
    {
        [Key]
        [ScaffoldColumn(false)]
        public int VehiculoId { get; set; }

        [Required(ErrorMessage = "Por favor insertar la marca del vehiculo")]
        [Display(Name = "Marca")]
        public int MarcaId { get; set; }

        [Required(ErrorMessage = "Por favor insertar el modelo del vehiculo")]
        [Display(Name = "Modelo")]
        public int ModeloId { get; set; }

        [Required(ErrorMessage = "Por favor indicar el tipo de transmision")]
        [Display(Name = "Tipo de Transmision")]
        public int TransmisionId { get; set; } = 1;

        [Required(ErrorMessage = "Por favor insertar el combustible usado")]
        [Display(Name = "Combustible")]
        public int CombustibleId { get; set; } = 1;

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Por favor insertar el Año del vehiculo")]
        public DateTime Año { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Por favor insertar el color del vehiculo"), MaxLength(30)]
        public string Color { get; set; }

        [Required(ErrorMessage = "Por favor insertar la cantidad de puertas del vehiculo")]
        public int Puertas { get; set; }

        [Required(ErrorMessage = "Por favor insertar la cantidad en existencia del vehiculo")]
        [Display(Name = "Cantidad en Existencia")]
        public int CantidadExistente { get; set; }

        [Required(ErrorMessage = "Por favor insertar el Proveedor del Vehiculo")]
        [Display(Name = "Proveedor")]
        public int ProveedorId { get; set; } = 1;

        [Display(Name = "Fecha de Entrada un cambio ")]
        public DateTime FechadeEntrada { get; set; } = DateTime.Now;

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Por favor insertar el estatus del vehiculo"), MaxLength(30)]
        public string Estatus { get; set; }

        [ForeignKey("MarcaId")]
        public Marca Marca { get; set; }

        [ForeignKey("ModeloId")]
        public Modelo Modelo { get; set; }

        [ForeignKey("TransmisionId")]
        public Transmision Transmision { get; set; } 

        [ForeignKey("CombustibleId")]
        public Combustible Combustible { get; set; } 

        [ForeignKey("ProveedorId")]
        public Proveedor Proveedor { get; set; }

        public ICollection<Factura> Facturas { get; set; }


    }
}
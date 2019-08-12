using SistemaDealer1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using static SistemaDealer1.Models.Personas;

namespace SistemaDealer1.Dtos
{
    public class Vehiculo1Dto
    {
        [Key]
        //[DataType(DataType.)]
        [ScaffoldColumn(false)]
        public int VehiculoId { get; set; }
        public int EmpleadoId { get; set; }
        [Required(ErrorMessage = "Por favor insertar la marca del vehiculo")]
        [Display(Name = "Marca")]
        public int MarcaId { get; set; }

        [Required(ErrorMessage = "Por favor insertar el modelo del vehiculo")]
        [Display(Name = "Modelo")]
        public int ModeloId { get; set; }

        public int ProveedorId { get; set; }

        [Required(ErrorMessage = "Por favor indicar el tipo de transmision")]
        [Display(Name = "Tipo de Transmision")]
        public int TransmisionId { get; set; }

        [Required(ErrorMessage = "Por favor insertar el combustible usado")]
        [Display(Name = "Combustible")]
        public int CombustibleId { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Por favor insertar el Año del vehiculo")]
        public DateTime Año { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Por favor insertar el color del vehiculo"), MaxLength(30)]
        public string Color { get; set; }

        [Required(ErrorMessage = "Por favor insertar la cantidad de puertas del vehiculo")]
        public int Puertas { get; set; }

        [Required(ErrorMessage = "Por favor insertar el estatus del vehiculo")]
        public Estado Estatus { get; set; }

        [ForeignKey("MarcaId")]
        public Marca Marca { get; set; }

        [ForeignKey("ModeloId")]
        public Modelo Modelo { get; set; }

        [ForeignKey("TransmisionId")]
        public Transmision Transmision { get; set; }

        [ForeignKey("CombustibleId")]
        public Combustible Combustible { get; set; }

        public ICollection<Factura> Facturas { get; set; }
        public ICollection<Inventario> Inventario { get; set; }
        public ICollection<Movimiento> Movimiento { get; set; }
        public virtual Proveedor Proveedor { get; set; }
        public int Cantidad { get; set; }
        public virtual Empleado Empleado { get; set; }
    }
}
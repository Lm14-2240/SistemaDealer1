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
    [Bind(Exclude = "ModeloID")]
    public class Modelo
    {
        [Key]
        [ScaffoldColumn(false)]
        public int ModeloId { get; set; }
        [Display(Name = "Marca")]
        public int MarcaId { get; set; }
        [Required(ErrorMessage = "Por favor insertar el modelo nuevo")]
        [StringLength(30, ErrorMessage = "Por favor introduzca 30 caracteres o menos")]
        [Display(Name = "Modelo")]
        public string Descripcion { get; set; }

        [ForeignKey("MarcaId")]
        public Marca Marca { get; set; }
    }
}
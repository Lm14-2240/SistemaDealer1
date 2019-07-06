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
    [Bind(Exclude =  "MarcaID")]
    public class Marca
    {
        [Key]
        [ScaffoldColumn(false)]
        public int MarcaId { get; set; }
        [Required(ErrorMessage = "Por favor insertar la marca nueva"), MaxLength(30)]
        [StringLength(30, ErrorMessage = "Por favor introduzca 30 caracteres o menos")]
        [Display(Name = "Marca")]
        public string Descripcion { get; set; }

        public ICollection<Modelo> Modelo { get; set; }

    }
}
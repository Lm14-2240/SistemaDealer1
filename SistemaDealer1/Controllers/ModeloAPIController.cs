using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SistemaDealer1.Models;

namespace SistemaDealer1.Controllers
{
    public class ModeloAPIController : ApiController
    {
        private SistemaDealer1DBContext db = new SistemaDealer1DBContext();

        public IQueryable<Modelo> GetModelo(int marcaId)
        {
            return db.Modelos.Where(m => m.MarcaId == marcaId);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ModeloExists(int id)
        {
            return db.Modelos.Count(e => e.ModeloId == id) > 0;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaDealer1.Models;

namespace SistemaDealer1.Controllers
{
    public class Factura_DetalleController : Controller
    {
        private SistemaDealer1DBContext db = new SistemaDealer1DBContext();

        // GET: Factura_Detalle
        public ActionResult Index()
        {
            var factura_Detalles = db.Factura_Detalles.Include(f => f.Factura).Include(f => f.Vehiculo);
            return View(factura_Detalles.ToList());
        }

        // GET: Factura_Detalle/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura_Detalle factura_Detalle = db.Factura_Detalles.Find(id);
            if (factura_Detalle == null)
            {
                return HttpNotFound();
            }
            return View(factura_Detalle);
        }

        // GET: Factura_Detalle/Create
        public ActionResult Create()
        {
            ViewBag.FacturaId = new SelectList(db.Facturas, "FacturaId", "MetodoPago");
            ViewBag.VehiculoId = new SelectList(db.Vehiculoes, "VehiculoId", "Color");
            return View();
        }

        // POST: Factura_Detalle/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FacturaDetalleId,VehiculoId,FacturaId,PrecioUnidad,Cantidad,SubTotal")] Factura_Detalle factura_Detalle)
        {
            if (ModelState.IsValid)
            {
                db.Factura_Detalles.Add(factura_Detalle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FacturaId = new SelectList(db.Facturas, "FacturaId", "MetodoPago", factura_Detalle.FacturaId);
            ViewBag.VehiculoId = new SelectList(db.Vehiculoes, "VehiculoId", "Color", factura_Detalle.VehiculoId);
            return View(factura_Detalle);
        }

        // GET: Factura_Detalle/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura_Detalle factura_Detalle = db.Factura_Detalles.Find(id);
            if (factura_Detalle == null)
            {
                return HttpNotFound();
            }
            ViewBag.FacturaId = new SelectList(db.Facturas, "FacturaId", "MetodoPago", factura_Detalle.FacturaId);
            ViewBag.VehiculoId = new SelectList(db.Vehiculoes, "VehiculoId", "Color", factura_Detalle.VehiculoId);
            return View(factura_Detalle);
        }

        // POST: Factura_Detalle/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FacturaDetalleId,VehiculoId,FacturaId,PrecioUnidad,Cantidad,SubTotal")] Factura_Detalle factura_Detalle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(factura_Detalle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FacturaId = new SelectList(db.Facturas, "FacturaId", "MetodoPago", factura_Detalle.FacturaId);
            ViewBag.VehiculoId = new SelectList(db.Vehiculoes, "VehiculoId", "Color", factura_Detalle.VehiculoId);
            return View(factura_Detalle);
        }

        // GET: Factura_Detalle/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura_Detalle factura_Detalle = db.Factura_Detalles.Find(id);
            if (factura_Detalle == null)
            {
                return HttpNotFound();
            }
            return View(factura_Detalle);
        }

        // POST: Factura_Detalle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Factura_Detalle factura_Detalle = db.Factura_Detalles.Find(id);
            db.Factura_Detalles.Remove(factura_Detalle);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

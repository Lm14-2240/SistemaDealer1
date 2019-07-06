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
    public class ReservasController : Controller
    {
        private SistemaDealer1DBContext db = new SistemaDealer1DBContext();

        // GET: Reservas
        public ActionResult Index()
        {
            var reservas = db.Reservas.Include(r => r.Cliente).Include(r => r.Empleado).Include(r => r.Vehiculo);
            return View(reservas.ToList());
        }

        // GET: Reservas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserva reserva = db.Reservas.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            return View(reserva);
        }

        // GET: Reservas/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Estatus");
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "EmpleadoId", "Usuario");
            ViewBag.VehiculoId = new SelectList(db.Vehiculoes, "VehiculoId", "Color");
            return View();
        }

        // POST: Reservas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                db.Reservas.Add(reserva);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Estatus", reserva.ClienteId);
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "EmpleadoId", "Usuario", reserva.EmpleadoId);
            ViewBag.VehiculoId = new SelectList(db.Vehiculoes, "VehiculoId", "Color", reserva.VehiculoId);
            return View(reserva);
        }

        // GET: Reservas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserva reserva = db.Reservas.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Estatus", reserva.ClienteId);
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "EmpleadoId", "Usuario", reserva.EmpleadoId);
            ViewBag.VehiculoId = new SelectList(db.Vehiculoes, "VehiculoId", "Color", reserva.VehiculoId);
            return View(reserva);
        }

        // POST: Reservas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reserva).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Estatus", reserva.ClienteId);
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "EmpleadoId", "Usuario", reserva.EmpleadoId);
            ViewBag.VehiculoId = new SelectList(db.Vehiculoes, "VehiculoId", "Color", reserva.VehiculoId);
            return View(reserva);
        }

        // GET: Reservas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserva reserva = db.Reservas.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            return View(reserva);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reserva reserva = db.Reservas.Find(id);
            db.Reservas.Remove(reserva);
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

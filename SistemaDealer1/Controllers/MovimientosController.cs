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
    public class MovimientosController : Controller
    {
        private SistemaDealer1DBContext db = new SistemaDealer1DBContext();

        // GET: Movimientos
        public ActionResult Index()
        {
            var movimientos = db.Movimientos.Include(m => m.Cliente).Include(m => m.Empleado).Include(m => m.Proveedor).Include(m => m.Vehiculo);
            return View(movimientos.ToList());
        }

        // GET: Movimientos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movimiento movimiento = db.Movimientos.Find(id);
            if (movimiento == null)
            {
                return HttpNotFound();
            }
            return View(movimiento);
        }

        // GET: Movimientos/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Estatus");
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "EmpleadoId", "Usuario");
            ViewBag.ProveedorId = new SelectList(db.Proveedores, "ProveedorId", "Nombre");
            ViewBag.VehiculoId = new SelectList(db.Vehiculoes, "VehiculoId", "Color");
            return View();
        }

        // POST: Movimientos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovimientoId,Tipo_Movimiento,Cantidad,VehiculoId,ProveedorId,EmpleadoId,ClienteId")] Movimiento movimiento)
        {

            if (movimiento.Tipo_Movimiento == "Venta")
            {
                var existencia = db.Inventarios.SingleOrDefault(i => i.VehiculoId == movimiento.VehiculoId).CantidadExistencia;
                if (existencia < movimiento.Cantidad)
                {
                    ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Estatus", movimiento.ClienteId);
                    ViewBag.EmpleadoId = new SelectList(db.Empleados, "EmpleadoId", "Usuario", movimiento.EmpleadoId);
                    ViewBag.ProveedorId = new SelectList(db.Proveedores, "ProveedorId", "Nombre", movimiento.ProveedorId);
                    ViewBag.VehiculoId = new SelectList(db.Vehiculoes, "VehiculoId", "Color", movimiento.VehiculoId);
                    ModelState.AddModelError("Cantidad", "Esta cantidad de vehículos solicitada, excede la cantidad en inventario.");
                    return View(movimiento);
                }

                if (ModelState.IsValid)
                {
                    db.Movimientos.Add(movimiento);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Estatus", movimiento.ClienteId);
                ViewBag.EmpleadoId = new SelectList(db.Empleados, "EmpleadoId", "Usuario", movimiento.EmpleadoId);
                ViewBag.ProveedorId = new SelectList(db.Proveedores, "ProveedorId", "Nombre", movimiento.ProveedorId);
                ViewBag.VehiculoId = new SelectList(db.Vehiculoes, "VehiculoId", "Color", movimiento.VehiculoId);
                return View(movimiento);

            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.Movimientos.Add(movimiento);
                    var aumentarInventario = db.Inventarios.SingleOrDefault(i => i.VehiculoId == movimiento.VehiculoId);
                    aumentarInventario.CantidadExistencia = aumentarInventario.CantidadExistencia + movimiento.Cantidad;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Estatus", movimiento.ClienteId);
                ViewBag.EmpleadoId = new SelectList(db.Empleados, "EmpleadoId", "Usuario", movimiento.EmpleadoId);
                ViewBag.ProveedorId = new SelectList(db.Proveedores, "ProveedorId", "Nombre", movimiento.ProveedorId);
                ViewBag.VehiculoId = new SelectList(db.Vehiculoes, "VehiculoId", "Color", movimiento.VehiculoId);
                return View(movimiento);
            }


      
        }

        // GET: Movimientos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movimiento movimiento = db.Movimientos.Find(id);
            if (movimiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Estatus", movimiento.ClienteId);
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "EmpleadoId", "Usuario", movimiento.EmpleadoId);
            ViewBag.ProveedorId = new SelectList(db.Proveedores, "ProveedorId", "Nombre", movimiento.ProveedorId);
            ViewBag.VehiculoId = new SelectList(db.Vehiculoes, "VehiculoId", "Color", movimiento.VehiculoId);
            return View(movimiento);
        }

        // POST: Movimientos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovimientoId,Tipo_Movimiento,Cantidad,VehiculoId,ProveedorId,EmpleadoId,ClienteId")] Movimiento movimiento)
        {
            var inventario = db.Inventarios.Where(I => I.VehiculoId == movimiento.VehiculoId).Count();
            var verificacionExistencia = db.Movimientos.Any(M => M.Cantidad > inventario);
            if (verificacionExistencia)
                ModelState.AddModelError("Cantidad", "La Cantidad vendida no puede ser mayor a la cantidad en Existencia");

            if (ModelState.IsValid)
            {
                ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Estatus", movimiento.ClienteId);
                ViewBag.EmpleadoId = new SelectList(db.Empleados, "EmpleadoId", "Usuario", movimiento.EmpleadoId);
                ViewBag.ProveedorId = new SelectList(db.Proveedores, "ProveedorId", "Nombre", movimiento.ProveedorId);
                ViewBag.VehiculoId = new SelectList(db.Vehiculoes, "VehiculoId", "Color", movimiento.VehiculoId);
                return View(movimiento);
            }
            

            db.Entry(movimiento).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Movimientos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movimiento movimiento = db.Movimientos.Find(id);
            if (movimiento == null)
            {
                return HttpNotFound();
            }
            return View(movimiento);
        }

        // POST: Movimientos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movimiento movimiento = db.Movimientos.Find(id);
            db.Movimientos.Remove(movimiento);
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

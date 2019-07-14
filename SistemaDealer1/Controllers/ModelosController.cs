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
    public class ModelosController : Controller
    {
        private SistemaDealer1DBContext db = new SistemaDealer1DBContext();

        // GET: Modelos
        public ActionResult Index()
        {
            var modelos = db.Modelos.Include(m => m.Marca);
            return View(modelos.ToList());
        }

        // GET: Modelos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modelo modelo = db.Modelos.Find(id);
            if (modelo == null)
            {
                return HttpNotFound();
            }
            return View(modelo);
        }

        // GET: Modelos/Create
        public ActionResult Create()
        {
            ViewBag.MarcaId = new SelectList(db.Marcas, "MarcaId", "Descripcion");
            return View();
        }

        // POST: Modelos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Modelo modelo)
        {
            if (ModelState.IsValid)
            {
                db.Modelos.Add(modelo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MarcaId = new SelectList(db.Marcas, "MarcaId", "Descripcion", modelo.MarcaId);
            return View(modelo);
        }

        // GET: Modelos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modelo modelo = db.Modelos.Find(id);
            if (modelo == null)
            {
                return HttpNotFound();
            }
            ViewBag.MarcaId = new SelectList(db.Marcas, "MarcaId", "Descripcion", modelo.MarcaId);
            return View(modelo);
        }

        // POST: Modelos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Modelo modelo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modelo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MarcaId = new SelectList(db.Marcas, "MarcaId", "Descripcion", modelo.MarcaId);
            return View(modelo);
        }

        // GET: Modelos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modelo modelo = db.Modelos.Find(id);
            if (modelo == null)
            {
                return HttpNotFound();
            }
            return View(modelo);
        }

        // POST: Modelos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Modelo modelo = db.Modelos.Find(id);
            db.Modelos.Remove(modelo);
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

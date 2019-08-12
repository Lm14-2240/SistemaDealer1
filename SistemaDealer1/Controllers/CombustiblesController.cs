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
    public class CombustiblesController : Controller
    {
        private SistemaDealer1DBContext db = new SistemaDealer1DBContext();

        // GET: Combustibles
        public ActionResult Index()
        {
            return View(db.Combustibles.ToList());
        }

        // GET: Combustibles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Combustible combustible = db.Combustibles.Find(id);
            if (combustible == null)
            {
                return HttpNotFound();
            }
            return View(combustible);
        }

        // GET: Combustibles/Create
        public ActionResult Create()
        {
            return View();
        }

        //Validaciones
        // POST: Combustibles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Combustible combustible)
        {
            var verificacionExistencia = db.Combustibles.Any(c => c.Descripcion == combustible.Descripcion);
            if (verificacionExistencia)
                ModelState.AddModelError("Descripcion", "Este tipo de combustible ya existe en la base de datos.");

            if (!ModelState.IsValid)
                   return View(combustible);
                       
            db.Combustibles.Add(combustible);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        // GET: Combustibles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Combustible combustible = db.Combustibles.Find(id);
            if (combustible == null)
            {
                return HttpNotFound();
            }
            return View(combustible);
        }

        // POST: Combustibles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Combustible combustible)
        {
            if (ModelState.IsValid)
            {
                db.Entry(combustible).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(combustible);
        }

        // GET: Combustibles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Combustible combustible = db.Combustibles.Find(id);
            if (combustible == null)
            {
                return HttpNotFound();
            }
            return View(combustible);
        }

        // POST: Combustibles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Combustible combustible = db.Combustibles.Find(id);
            db.Combustibles.Remove(combustible);
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

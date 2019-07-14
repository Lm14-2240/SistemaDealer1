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
    public class TransmisionesController : Controller
    {
        private SistemaDealer1DBContext db = new SistemaDealer1DBContext();

        // GET: Transmisiones
        public ActionResult Index()
        {
            return View(db.Transmisions.ToList());
        }

        // GET: Transmisiones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transmision transmision = db.Transmisions.Find(id);
            if (transmision == null)
            {
                return HttpNotFound();
            }
            return View(transmision);
        }

        // GET: Transmisiones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transmisiones/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Transmision transmision)
        {
            if (ModelState.IsValid)
            {
                db.Transmisions.Add(transmision);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(transmision);
        }

        // GET: Transmisiones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transmision transmision = db.Transmisions.Find(id);
            if (transmision == null)
            {
                return HttpNotFound();
            }
            return View(transmision);
        }

        // POST: Transmisiones/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Transmision transmision)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transmision).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transmision);
        }

        // GET: Transmisiones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transmision transmision = db.Transmisions.Find(id);
            if (transmision == null)
            {
                return HttpNotFound();
            }
            return View(transmision);
        }

        // POST: Transmisiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transmision transmision = db.Transmisions.Find(id);
            db.Transmisions.Remove(transmision);
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

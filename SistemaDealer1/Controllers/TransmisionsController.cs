using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using SistemaDealer1.Models;

namespace SistemaDealer1.Controllers
{
    public class TransmisionsController : Controller
    {
        private SistemaDealer1DBContext db = new SistemaDealer1DBContext();

        // GET: Transmisions
        public ActionResult Index()
        {
            return View(db.Transmisions.ToList());
        }

        // GET: Transmisions/Details/5
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

        // GET: Transmisions/Create
        public ActionResult Create()
        {
            return View();
        }

        //Validaciones
        // POST: Transmisions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Transmision transmision)
        {
            var verificacionExistencia = db.Transmisions.Any(t => t.Descripcion == transmision.Descripcion);
            if (verificacionExistencia)
                ModelState.AddModelError("Descripcion", "Este tipo de transmición ya existe en la base de datos.");

            if (ModelState.IsValid)
                return View(transmision);

            db.Transmisions.Add(transmision);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Transmisions/Edit/5
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

        // POST: Transmisions/Edit/5
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

        // GET: Transmisions/Delete/5
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

        // POST: Transmisions/Delete/5
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

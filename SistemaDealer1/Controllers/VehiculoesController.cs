using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using SistemaDealer1.Dtos;
using SistemaDealer1.Models;

namespace SistemaDealer1.Controllers
{
    public class VehiculoesController : Controller
    {
        private SistemaDealer1DBContext db = new SistemaDealer1DBContext();

        // GET: Vehiculoes
        public ActionResult Index()
        {
            var vehiculoes = db.Vehiculoes.Include(v => v.Combustible).Include(v => v.Marca).Include(v => v.Modelo).Include(v => v.Transmision);
            return View(vehiculoes.ToList());
        }

        // GET: Vehiculoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehiculo vehiculo = db.Vehiculoes.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(vehiculo);
        }

        //Validaciones
        // GET: Vehiculoes/Create
        public ActionResult Create()
        {
            ViewBag.CombustibleId = new SelectList(db.Combustibles, "CombustibleId", "Descripcion");
            ViewBag.MarcaId = new SelectList(db.Marcas, "MarcaId", "Descripcion");
            ViewBag.ModeloId = new SelectList(db.Modelos, "ModeloId", "Descripcion");
            ViewBag.TransmisionId = new SelectList(db.Transmisions, "TransmisionId", "Descripcion");
            ViewBag.ProveedorId = new SelectList(db.Proveedores, "ProveedorId", "Nombre");
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "EmpleadoId", "Nombre");
            return View();
        }

        // POST: Vehiculoes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vehiculo1Dto vehiculo)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CombustibleId = new SelectList(db.Combustibles, "CombustibleId", "Descripcion", vehiculo.CombustibleId);
                ViewBag.MarcaId = new SelectList(db.Marcas, "MarcaId", "Descripcion", vehiculo.MarcaId);
                ViewBag.ModeloId = new SelectList(db.Modelos, "ModeloId", "Descripcion", vehiculo.ModeloId);
                ViewBag.TransmisionId = new SelectList(db.Transmisions, "TransmisionId", "Descripcion", vehiculo.TransmisionId);
                return View(vehiculo);      
            }

            var vehiculo1 = new Vehiculo
            {
                Año = vehiculo.Año,
                Color = vehiculo.Color,
                Combustible = vehiculo.Combustible,
                CombustibleId = vehiculo.CombustibleId,
                Estatus = vehiculo.Estatus,
                Facturas = vehiculo.Facturas,
                Inventario = vehiculo.Inventario,
                Marca = vehiculo.Marca,
                MarcaId = vehiculo.MarcaId,
                Modelo = vehiculo.Modelo,
                ModeloId = vehiculo.ModeloId,
                Movimiento = vehiculo.Movimiento,
                Puertas = vehiculo.Puertas,
                Transmision = vehiculo.Transmision,
                TransmisionId = vehiculo.TransmisionId,
                VehiculoId = vehiculo.VehiculoId,
                ProveedorId = vehiculo.ProveedorId,
                EmpleadoId = vehiculo.EmpleadoId,
                PrecioUnitario = vehiculo.PrecioUnitario
            };

            db.Vehiculoes.Add(vehiculo1);
            db.SaveChanges();

            var ultimoVehiculo = db.Vehiculoes.ToList().Last();
            if (db.Inventarios.Any(i=>i.MarcaId == ultimoVehiculo.MarcaId && i.ModeloId == ultimoVehiculo.ModeloId))
            {
                var actualizarMovimiento = db.Inventarios.SingleOrDefault(i => i.MarcaId == ultimoVehiculo.MarcaId && i.ModeloId == ultimoVehiculo.ModeloId);
                actualizarMovimiento.CantidadExistencia = actualizarMovimiento.CantidadExistencia + vehiculo.Cantidad;

                var newMovimiento = new Movimiento
                {
                    Cantidad = vehiculo.Cantidad,
                    Tipo_Movimiento = "Compra",
                    VehiculoId = ultimoVehiculo.VehiculoId,
                    ProveedorId = ultimoVehiculo.ProveedorId,
                    EmpleadoId = ultimoVehiculo.EmpleadoId,
                    
                };

                db.Movimientos.Add(newMovimiento);
                db.SaveChanges();
            }
            else
            {
                var movimientoDeInventario = new Inventario
                {
                    CantidadExistencia = vehiculo.Cantidad,
                    Vehiculo = ultimoVehiculo,
                    VehiculoId = ultimoVehiculo.VehiculoId,
                    MarcaId = ultimoVehiculo.MarcaId,
                    ModeloId = ultimoVehiculo.ModeloId,
                    
                };

                var newMovimiento = new Movimiento
                {
                    Cantidad = vehiculo.Cantidad,
                    Tipo_Movimiento = "Compra",
                    VehiculoId = ultimoVehiculo.VehiculoId,
                    ProveedorId = ultimoVehiculo.ProveedorId,
                    EmpleadoId = ultimoVehiculo.EmpleadoId,
                };

                db.Movimientos.Add(newMovimiento);
                db.Inventarios.Add(movimientoDeInventario);
                db.SaveChanges();
            }




            return RedirectToAction("Index");

        }

        // GET: Vehiculoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehiculo vehiculo = db.Vehiculoes.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            ViewBag.CombustibleId = new SelectList(db.Combustibles, "CombustibleId", "Descripcion", vehiculo.CombustibleId);
            ViewBag.MarcaId = new SelectList(db.Marcas, "MarcaId", "Descripcion", vehiculo.MarcaId);
            ViewBag.ModeloId = new SelectList(db.Modelos, "ModeloId", "Descripcion", vehiculo.ModeloId);
            ViewBag.TransmisionId = new SelectList(db.Transmisions, "TransmisionId", "Descripcion", vehiculo.TransmisionId);
            return View(vehiculo);
        }

        // POST: Vehiculoes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CombustibleId = new SelectList(db.Combustibles, "CombustibleId", "Descripcion", vehiculo.CombustibleId);
            ViewBag.MarcaId = new SelectList(db.Marcas, "MarcaId", "Descripcion", vehiculo.MarcaId);
            ViewBag.ModeloId = new SelectList(db.Modelos, "ModeloId", "Descripcion", vehiculo.ModeloId);
            ViewBag.TransmisionId = new SelectList(db.Transmisions, "TransmisionId", "Descripcion", vehiculo.TransmisionId);
            return View(vehiculo);
        }

        // GET: Vehiculoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehiculo vehiculo = db.Vehiculoes.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(vehiculo);
        }

        // POST: Vehiculoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehiculo vehiculo = db.Vehiculoes.Find(id);
            db.Vehiculoes.Remove(vehiculo);
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

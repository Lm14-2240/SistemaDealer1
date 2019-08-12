using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using SistemaDealer1.Dtos;
using SistemaDealer1.Models;

namespace SistemaDealer1.Controllers
{
    public class FacturasController : Controller
    {
        private SistemaDealer1DBContext db = new SistemaDealer1DBContext();

        // GET: Facturas
        public ActionResult Index()
        {
            var facturas = db.Facturas.Include(f => f.Cliente).Include(f => f.Empleado);

                
            return View(facturas.ToList());
        }

        // GET: Facturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = db.Facturas.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        //Validaciones
        // GET: Facturas/Create
        public ActionResult Create()
        {

            var Usuario = db.Empleados.ToList();
            var Clientes = db.Clientes.ToList();
            var vehiculos = db.Vehiculoes.ToList().Select(c=> new VehiculoDTO {
                Vehiculo = c,
                MarcaNombre = db.Marcas.SingleOrDefault(d => d.MarcaId == c.MarcaId).Descripcion +" "+
                db.Modelos.SingleOrDefault(mo => mo.ModeloId == c.ModeloId).Descripcion
                }).ToList();

            FacturaDTO DTO = new FacturaDTO();//Instancia
            DTO.Usuarios = Usuario;
            DTO.Clientes = Clientes;
            DTO.Vehiculos = vehiculos;

            return View(DTO);
        }

        // POST: Facturas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NuevaFacturaDto factura)
        {
            var existencia = db.Inventarios.SingleOrDefault(c => c.VehiculoId == factura.VehiculoId);
            var vehiculo = db.Vehiculoes.SingleOrDefault(v => v.VehiculoId == factura.VehiculoId);

            if (existencia.CantidadExistencia < factura.Cantidad)
            {
                ModelState.AddModelError("Cantidad", "La cantidad solicitada es mayor a la cantidad en inventario");
                var Usuario = db.Empleados.ToList();
                var Clientes = db.Clientes.ToList();
                var vehiculos = db.Vehiculoes.ToList().Select(c => new VehiculoDTO
                {
                    Vehiculo = c,
                    MarcaNombre = db.Marcas.SingleOrDefault(d => d.MarcaId == c.MarcaId).Descripcion + " " +
                    db.Modelos.SingleOrDefault(mo => mo.ModeloId == c.ModeloId).Descripcion
                }).ToList();

                FacturaDTO DTO = new FacturaDTO();//Instancia
                DTO.Usuarios = Usuario;
                DTO.Clientes = Clientes;
                DTO.Vehiculos = vehiculos;
                return View(DTO);
            }

            if (ModelState.IsValid)
            {
                var nuevaFactura = new Factura
                {
                    ClienteId = factura.ClienteId,
                    EmpleadoId = factura.EmpleadoId,
                    MetodoPago = factura.MetodoPago,
                    PrecioTotal = vehiculo.PrecioUnitario * factura.Cantidad,
                    PrecioUnitario = vehiculo.PrecioUnitario,
                    VehiculoId = vehiculo.VehiculoId
                };
                db.Facturas.Add(nuevaFactura);

                var movimiento = new Movimiento
                {
                    Cantidad = factura.Cantidad,
                    ClienteId = factura.ClienteId,
                    EmpleadoId = factura.EmpleadoId,
                    Tipo_Movimiento = "Venta",
                    VehiculoId = factura.VehiculoId,
                };
                db.Movimientos.Add(movimiento);

                existencia.CantidadExistencia = existencia.CantidadExistencia - factura.Cantidad;

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(factura);
        }

        // GET: Facturas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = db.Facturas.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Estatus", factura.ClienteId);
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "EmpleadoId", "Usuario", factura.EmpleadoId);
            return View(factura);
        }

        // POST: Facturas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Factura factura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(factura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Estatus", factura.ClienteId);
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "EmpleadoId", "Usuario", factura.EmpleadoId);
            return View(factura);
        }

        // GET: Facturas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = db.Facturas.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // POST: Facturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Factura factura = db.Facturas.Find(id);
            db.Facturas.Remove(factura);
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

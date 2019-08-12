using System.Linq;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using SistemaDealer1.Models;

namespace SistemaDealer1.Controllers
{
    public class LoginController : Controller
    {
        private SistemaDealer1DBContext db = new SistemaDealer1DBContext();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string username, string password)
        {
            if (username.IsNullOrWhiteSpace() || password.IsNullOrWhiteSpace())
            {
                ModelState.AddModelError("Usuario", "Debe introducir sus credenciales para acceder");
                return View();
            }

            if (db.Empleados.Any(m => m.Usuario == username) && VerifyUsernamePasswordMatch(username, password))
            {
                return RedirectToAction("Index", "Vehiculoes");
            }

            ModelState.AddModelError("Contraseña", "El usuario o contraseña suministrados son incorrectos");
            return View();
        }

        private bool VerifyUsernamePasswordMatch(string username, string password)
        {
            var signedUser = (from m in db.Empleados
                where m.Usuario == username
                select m).FirstOrDefault();

            return signedUser.Contraseña.Equals(password);
        }
    }
}
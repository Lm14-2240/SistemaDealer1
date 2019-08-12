using System.Web.Mvc;
using Microsoft.Ajax.Utilities;

namespace SistemaDealer1.Controllers
{
    public class LoginController : Controller
    {
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

            return RedirectToAction("Index", "Vehiculoes");
        }
    }
}
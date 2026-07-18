using Microsoft.AspNetCore.Mvc;

namespace Legacy.Controllers
{
    public class AdmMedidoresController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.UserRole = "Administrador";
            ViewData["Title"] = "Administración de Medidores";
            return View();
        }
    }
}

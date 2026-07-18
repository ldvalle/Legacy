using Microsoft.AspNetCore.Mvc;

namespace Legacy.Controllers
{
    public class GestionOTsController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.UserRole = "Administrador";
            ViewData["Title"] = "Gestión de Órdenes de Trabajo";
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace Legacy.Controllers
{
    public class ReclamacionesController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.UserRole = "Administrador";
            ViewData["Title"] = "Gestión de Reclamaciones";
            return View();
        }
    }
}

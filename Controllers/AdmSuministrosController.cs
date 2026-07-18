using Microsoft.AspNetCore.Mvc;

namespace Legacy.Controllers
{
    public class AdmSuministrosController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.UserRole = "Administrador";
            ViewData["Title"] = "Administración de Suministros";
            return View();
        }
    }
}

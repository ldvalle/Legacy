using Microsoft.AspNetCore.Mvc;

namespace Legacy.Controllers
{
    public class GestionSAEController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.UserRole = "Administrador";
            ViewData["Title"] = "Gestión SAE";
            return View();
        }
    }
}

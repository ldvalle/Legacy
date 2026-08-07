using Microsoft.AspNetCore.Mvc;

namespace Legacy.Controllers
{
    public class MiEscritorioController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.UserRole = "Administrador";
            ViewData["Title"] = "Mi Escritorio";
            return View();
        }
    }
}

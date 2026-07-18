using Microsoft.AspNetCore.Mvc;

namespace Legacy.Controllers
{
    public class AnalisisHurtoController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.UserRole = "Administrador";
            ViewData["Title"] = "Análisis de Hurto";
            return View();
        }
    }
}

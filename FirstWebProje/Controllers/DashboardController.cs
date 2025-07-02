using Microsoft.AspNetCore.Mvc;

namespace FirstWebProje.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.v1 = "Dashboard";
            ViewBag.v2 = "Genel";
            ViewBag.v3 = "Dashboard sayfası";
            return View();
        }
    }
}

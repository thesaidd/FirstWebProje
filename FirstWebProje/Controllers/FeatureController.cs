using Microsoft.AspNetCore.Mvc;

namespace FirstWebProje.Controllers
{
    public class FeatureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

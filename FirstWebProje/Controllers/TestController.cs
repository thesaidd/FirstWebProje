using Microsoft.AspNetCore.Mvc;

namespace FirstWebProje.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

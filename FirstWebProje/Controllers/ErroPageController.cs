using Microsoft.AspNetCore.Mvc;

namespace FirstWebProje.Controllers
{
    public class ErroPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace FirstWebProje.Areas.Writer.Controllers
{
    public class ProfileController : Controller
    {
        [Area("Writer")]
        public IActionResult Index()
        {
            return View();
        }
    }
}

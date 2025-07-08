using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebProje.Controllers
{
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EFAboutDal());

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.v1 = "Hakkımda Listesi";
            ViewBag.v2 = "Hakkımda";
            ViewBag.v3 = "Hakkımda Listesi";
            var values = aboutManager.TGetByID(4);
            return View(values);
        }
        [HttpPost]
        public IActionResult Index(About about)
        {

            if (ModelState.IsValid)
            {
                aboutManager.TUpdate(about);
                return RedirectToAction("Index", "Default");
            }

            // Eğer model geçerli değilse, formu hatalarla birlikte geri göster.
            return View(about);
        }
    }
}

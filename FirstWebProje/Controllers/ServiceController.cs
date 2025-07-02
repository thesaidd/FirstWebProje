using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebProje.Controllers
{
    public class ServiceController : Controller
    {
        ServiceManager serviceManager = new ServiceManager(new EFServiceDal());
        public IActionResult Index()
        {
            ViewBag.v1 = "Hizmetler Listesi";
            ViewBag.v2 = "Hizmetler";
            ViewBag.v3 = "Hizmetler Listesi";
            var values = serviceManager.TGetList();
            return View(values);
        }
        //Add
        [HttpGet]
        public IActionResult AddService()
        {
            ViewBag.v1 = "Yeni Hizmetler ekleme";
            ViewBag.v2 = "Hizmetler";
            ViewBag.v3 = "Hizmetler ekle";
            return View();
        }
        [HttpPost]
        public IActionResult AddService(Service service)
        {
            serviceManager.TAdd(service);
            TempData["Message"] = "Yeni Hizmetler başarıyla eklendi.";
            return RedirectToAction("Index");
        }

        //Delete
        [HttpPost]
        public IActionResult DeleteService(int id)
        {
            var values = serviceManager.TGetByID(id);
            if (values != null)
            {
                serviceManager.TDelete(values);
                TempData["Message"] = "Hizmetler başarıyla silindi ve çöp kutusuna taşındı.";
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeletedService()
        {
            ViewBag.v1 = "Silinmiş Hizmetler";
            ViewBag.v2 = "Hizmetler";
            ViewBag.v3 = "Çöp kutusu";
            var values = serviceManager.TGetDeletedList();
            return View(values);
        }
        //Edit
        [HttpGet]
        public IActionResult EditService(int id)
        {
            var values = serviceManager.TGetByID(id);
            if (values == null)
            {
                return NotFound();
            }
            return View(values);
        }

        [HttpPost]
        public IActionResult EditService(Service service)
        {

            serviceManager.TUpdate(service);
            TempData["Message"] = "Hizmetler başarıyla güncellendi.";
            return RedirectToAction("Index");
        }

        //Restore
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RestoreService(int id)
        {
            serviceManager.TRestore(id);
            TempData["Message"] = "Kayıt başarıyla geri yüklendi.";
            return RedirectToAction("DeletedService");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PermanentDeleteService(int id)
        {
            serviceManager.TPermanentDelete(id);
            TempData["Message"] = "Kayıt kalıcı olarak silindi.";
            return RedirectToAction("DeletedService");
        }
    }
}

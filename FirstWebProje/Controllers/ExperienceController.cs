using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebProje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ExperienceController : Controller
    {
        ExperienceManager experienceManager = new ExperienceManager(new EFExperienceDal());
        public IActionResult Index()
        {
            ViewBag.v1 = "Deneyim Listesi";
            ViewBag.v2 = "Deneyimler";
            ViewBag.v3 = "Deneyim Listesi";
            var values = experienceManager.TGetList();
            return View(values);
        }
        //Add
        [HttpGet]
        public IActionResult AddExperience()
        {
            ViewBag.v1 = "Yeni Deneyim ekleme";
            ViewBag.v2 = "Deneyimler";
            ViewBag.v3 = "Deneyim ekle";
            return View();
        }
        [HttpPost]
        public IActionResult AddExperience(Experience experience)
        {
            experienceManager.TAdd(experience);
            TempData["Message"] = "Yeni deneyim başarıyla eklendi."; 
            return RedirectToAction("Index");
        }

        //Delete
        [HttpPost]
        public IActionResult DeleteExperience(int id)
        {
            var values = experienceManager.TGetByID(id);
            if (values != null)
            {
                experienceManager.TDelete(values); 
                TempData["Message"] = "Deneyim başarıyla silindi ve çöp kutusuna taşındı.";
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeletedExperience()
        {
            ViewBag.v1 = "Silinmiş Deneyim";
            ViewBag.v2 = "Deneyimler";
            ViewBag.v3 = "Çöp kutusu";
            var values = experienceManager.TGetDeletedList();
            return View(values);
        }
        //Edit
        [HttpGet]
        public IActionResult EditExperience(int id)
        {
            var values = experienceManager.TGetByID(id);
            if (values == null)
            {
                return NotFound(); 
            }
            return View(values);
        }

        [HttpPost]
        public IActionResult EditExperience(Experience experience)
        {
            
            experienceManager.TUpdate(experience);
            TempData["Message"] = "Deneyim başarıyla güncellendi.";
            return RedirectToAction("Index");
        }
       
        //Restore
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RestoreExperience(int id)
        {
            experienceManager.TRestore(id);
            TempData["Message"] = "Kayıt başarıyla geri yüklendi.";
            return RedirectToAction("DeletedExperience");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PermanentDeleteExperience(int id)
        {
            experienceManager.TPermanentDelete(id);
            TempData["Message"] = "Kayıt kalıcı olarak silindi.";
            return RedirectToAction("DeletedExperience");
        }
    }
}

using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebProje.Controllers
{
    public class SkillController : Controller
    {
        SkillManager skillManager = new SkillManager(new EFSkillDal());
        public IActionResult Index()
        {
            ViewBag.v1 = "Yetenek Listesi";
            ViewBag.v2 = "Yetenekler";
            ViewBag.v3 = "Yetenek Listesi";
            var values = skillManager.TGetList();
            return View(values);
        }

        public IActionResult DeletedSkillList()
        {
            ViewBag.v1 = "Silinmiş Yetenek Listesi";
            ViewBag.v2 = "Yetenekler";
            ViewBag.v3 = "Çöp Kutusu";
            var values = skillManager.TGetDeletedList(); // Yeni servis metodumuzu çağırıyoruz.
            return View(values);
        }


        [HttpGet]
        public IActionResult AddSkill()
        {
            ViewBag.v1 = "Yetenek Ekleme";
            ViewBag.v2 = "Yetenekler";
            ViewBag.v3 = "Yetenek Ekleme";
            return View();
        }
        
        [HttpPost]
        public IActionResult AddSkill(Skill skill)
        {
            skillManager.TAdd(skill);
            return RedirectToAction("index");
        }
        public IActionResult DeleteSkill(int id)
        {
            var values = skillManager.TGetByID(id);
            skillManager.TDelete(values);
            return RedirectToAction("index");
        }
        public IActionResult PermanentDeleteSkill(int id)
        {
            skillManager.TPermanentDelete(id);
            return RedirectToAction("DeletedSkillList");
        }
        public IActionResult RestoreSkill(int id)
        {
            // 1. Ön hazırlıkta yazdığımız metot ile, silinmiş olan kaydı ID'sine göre bul.
            var skillToRestore = skillManager.TGetAnyByID(id);
            // 2. IsDeleted bayrağını tekrar false yap.
            skillToRestore.IsDeleted = false;
            // 3. Normal TUpdate metodunu kullanarak veritabanında güncelle.
            skillManager.TUpdate(skillToRestore);
            // 4. Kullanıcıyı tekrar çöp kutusu listesine yönlendir.
            return RedirectToAction("DeletedSkillList");
        }

        [HttpGet]
        public IActionResult EditSkill(int id)
        {
            ViewBag.v1 = "Güncelleme";
            ViewBag.v2 = "Yetenekler";
            ViewBag.v3 = "Yetenek Güncelleme";
            var values = skillManager.TGetByID(id);
            return View(values);
        }
        public IActionResult EditSkill(Skill skill)
        {
            skillManager.TUpdate(skill);
            return RedirectToAction("index");
        }

    }
}

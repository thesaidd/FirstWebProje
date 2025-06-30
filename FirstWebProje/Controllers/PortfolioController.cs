using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebProje.Controllers
{
    public class PortfolioController : Controller
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EFPortfolioDal());
        public IActionResult Index()
        {
            ViewBag.v1 = "Projeler Listesi";
            ViewBag.v2 = "Projeler";
            ViewBag.v3 = "Projeler Listesi";
            var values = portfolioManager.TGetList();
            return View(values);
        }

        //Add
        [HttpGet]
        public IActionResult AddPortfolio()
        {
            ViewBag.v1 = "Projeler ekle";
            ViewBag.v2 = "Projeler";
            ViewBag.v3 = "Projeler ekleme";
            return View();
        }
        [HttpPost]
        public IActionResult AddPortfolio(Portfolio portfolio)
        {
            PortfolioValidator validations = new PortfolioValidator();
            ValidationResult results = validations.Validate(portfolio);
            if (results.IsValid)
            {

                portfolioManager.TAdd(portfolio);
                TempData["Message"] = "Yeni proje başarıyla eklendi.";
                return RedirectToAction("index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        //Deleted
        public IActionResult DeletedPortfolio()
        {
            ViewBag.v1 = "Projeler SİLME";
            ViewBag.v2 = "Projeler";
            ViewBag.v3 = "Projeler SİLİNDİ";
            var values = portfolioManager.TGetDeletedList();
            return View(values);
        }
        [HttpPost]
        public IActionResult DeletePortfolio(int id)
        {
            var values = portfolioManager.TGetByID(id);
            if (values != null)
            {
                portfolioManager.TDelete(values);
                TempData["Message"] = "Proje başarıyla çöp kutusuna taşındı.";
            }
            else
            {
                TempData["Message"] = "Hata: Silinecek proje bulunamadı.";
            }

            return RedirectToAction("Index");
        }
        //Permanent
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PermanentDeletePortfolio(int id)
        {
            portfolioManager.TPermanentDelete(id);
            return RedirectToAction("DeletedPortfolio");
        }
        //Restore
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RestorePortfolio(int id)
        {
            portfolioManager.TRestore(id);
            TempData["Message"] = "Kayıt başarıyla geri yüklendi.";
            return RedirectToAction("DeletedPortfolio");
        }
        //Edit
        [HttpGet]
        public IActionResult EditPortfolio(int id)
        {
            ViewBag.v1 = "Projeler güncelleme";
            ViewBag.v2 = "Projeler";
            ViewBag.v3 = "Projeler günceşşendi";
            var values = portfolioManager.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditPortfolio(Portfolio portfolio)
        {
            portfolioManager.TUpdate(portfolio);
            return RedirectToAction("Index");
        }
    }
}

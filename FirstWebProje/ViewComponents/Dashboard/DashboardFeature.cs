using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebProje.ViewComponents.Dashboard
{
    public class DashboardSkill : ViewComponent
    {
        SkillManager skillManager = new SkillManager(new EFSkillDal());
        public IViewComponentResult Invoke()
        {
            var values = skillManager.TGetList();
            return View(values);
        }

    }
}

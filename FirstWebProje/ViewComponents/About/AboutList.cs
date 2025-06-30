using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FirstWebProje.ViewComponents.About
{
    public class AboutList : ViewComponent
    {
        AboutManager aboutManager = new AboutManager(new EFAboutDal());
        public IViewComponentResult Invoke()
        {
            var values = aboutManager.TGetList();
            return View(values);
        }
    }
}

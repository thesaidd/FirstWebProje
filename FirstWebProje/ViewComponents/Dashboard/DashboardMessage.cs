using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebProje.ViewComponents.Dashboard
{
    public class DashboardMessage : ViewComponent
    {
        MessageManager messageManager = new MessageManager(new EFMessageDal());
        public IViewComponentResult Invoke()
        {
            var values = messageManager.TGetList();
            return View(values);
        }

    }
}

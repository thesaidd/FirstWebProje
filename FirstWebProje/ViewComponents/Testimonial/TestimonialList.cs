using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FirstWebProje.ViewComponents.Testimonial
{
    public class TestimonialList : ViewComponent
    {
        TestimonialManager testimonialManager = new TestimonialManager(new EFTestimonialDal());

        public IViewComponentResult Invoke()
        {
            var values = testimonialManager.TGetList();
            return View(values);
        }
    }
}

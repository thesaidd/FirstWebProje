﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebProje.ViewComponents.Portfolio
{
    public class PortfolioList : ViewComponent
    {
       PortfolioManager portfolioManager = new PortfolioManager(new EFPortfolioDal());


        public IViewComponentResult Invoke()
        {
            var values= portfolioManager.TGetList(); 
            return View(values);
        }
    }
}

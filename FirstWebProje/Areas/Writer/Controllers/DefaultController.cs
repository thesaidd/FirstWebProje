﻿using Microsoft.AspNetCore.Mvc;

namespace FirstWebProje.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

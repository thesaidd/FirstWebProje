﻿using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace FirstWebProje.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[Controller]/[action]")]
    public class DashboardController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public DashboardController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }
        

        public async Task<IActionResult> IndexAsync()
        {
            //api
            string api = "268f4079773024a8dbe54614ffb4b162";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=London&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document = XDocument.Load(connection);
            ViewBag.v1 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v = values.Name + " " + values.Surname;


            WriterMessageManager A = new WriterMessageManager(new EFWriterMessageDal());
            Context c = new Context();

            string b = values.Email;
            ViewBag.v1 = A.TGetListReciverMessage(b).Count;
            ViewBag.v2 = A.TGetListSenderMessage(b).Count;
            return View();
        }
        
    }
}

//https://api.openweathermap.org/data/2.5/weather?q=London&mode=xml&lang=tr&units=metric&appid=268f4079773024a8dbe54614ffb4b162

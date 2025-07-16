using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebProje.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/Message")]
    public class MessageController : Controller
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EFWriterMessageDal());

        private readonly UserManager<WriterUser> _userManager;

        public MessageController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }
        [Route("")]
        [Route("ReciverMessage")]
        public async Task<IActionResult> ReciverMessage(String p)
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            p = value.Email;
            var messageList = writerMessageManager.TGetListReciverMessage(p);
            return View(messageList);
        }
        [Route("")]
        [Route("SenderMessage")]
        public async Task<IActionResult> SenderMessage(String p)
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            p = value.Email;
            var messageList = writerMessageManager.TGetListSenderMessage(p);
            return View(messageList);
        }

        [Route("MessageDetail/{id}")]
        public IActionResult MessageDetail(int id)
        {
            WriterMessage writerMessage = writerMessageManager.TGetByID(id);
            return View(writerMessage);
        }

        [Route("ReciverMessageDetails/{id}")]
        public IActionResult ReciverMessageDetails(int id)
        {
            WriterMessage writerMessage = writerMessageManager.TGetByID(id);
            return View(writerMessage);
        }
        
        [HttpGet]
        [Route("")]
        [Route("SendMessage")]
        public IActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        [Route("")]
        [Route("SendMessage")]
        public async Task<IActionResult> SendMessage(WriterMessage p)
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            String mail = value.Email;
            string name = value.Name + " " + value.Surname;
            string username = value.UserName;
            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.Sender = mail;
            p.SenderName = username;
            p.ReciverName = username;
            writerMessageManager.TAdd(p);
            return RedirectToAction("SenderMessage");
        }
    }
}

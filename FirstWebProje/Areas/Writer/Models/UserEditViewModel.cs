using Microsoft.AspNetCore.Http;

namespace FirstWebProje.Areas.Writer.Models
{
    public class UserEditViewModel
    {
        public String Name { get; set; }
        public String Surname { get; set; }
        public String Password { get; set; }
        public String PasswordConfrim { get; set; }
        public String PictureURL { get; set; }
        public IFormFile Picture { get; set; }
    }
}


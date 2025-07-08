using System.ComponentModel.DataAnnotations;

namespace FirstWebProje.Areas.Writer.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "adı boş geçilemez")]
        public string  Name { get; set; }

        [Required(ErrorMessage = "Soyadı boş geçilemez")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "resim url boş geçilemez")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Şifre boş geçilemez")]
        public String Password { get; set; }

        [Required(ErrorMessage = "Şifre tekrarı gir")]
        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor")]
        public String ConfirmPassword { get; set; }

        [Required(ErrorMessage = "mail boş geçilemez")]
        public string Mail { get; set; }
    }
}

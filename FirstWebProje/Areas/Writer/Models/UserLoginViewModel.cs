using System.ComponentModel.DataAnnotations;

namespace FirstWebProje.Areas.Writer.Models
{
    public class UserLoginViewModel
    {
        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez.")]
        public string UserName { get; set; }
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre boş geçilemez.")]
        public string Password { get; set; }
    }
}

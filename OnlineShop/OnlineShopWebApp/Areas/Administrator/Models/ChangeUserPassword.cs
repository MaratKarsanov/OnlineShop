using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Areas.Administrator.Models
{
    public class ChangeUserPassword
    {

        [Required(ErrorMessage = "Не указан новый пароль")]
        [StringLength(int.MaxValue, MinimumLength = 4, ErrorMessage = "Пароль должен быть длиннее 4 символов!")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Повторите новый пароль")]
        [Compare("NewPassword", ErrorMessage = "Пароли не совпадают")]
        public string RepeatedNewPassword { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Areas.Administrator.Models
{
    public class EditUserDataViewModel
    {

        [Required(ErrorMessage = "Введите имя")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Введите номер телефона")]
        [Phone(ErrorMessage = "Неверный формат номера")]
        public string PhoneNumber { get; set; }

        public EditUserDataViewModel()
        {
            UserName = PhoneNumber = "";
        }
    }
}
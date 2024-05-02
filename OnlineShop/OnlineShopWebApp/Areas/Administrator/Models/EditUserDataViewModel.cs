using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Areas.Administrator.Models
{
    public class EditUserDataViewModel
    {

        [Required(ErrorMessage = "Введите имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите фамилию")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Введите адрес")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Введите номер телефона")]
        [Phone(ErrorMessage = "Неверный формат номера")]
        public string PhoneNumber { get; set; }

        public EditUserDataViewModel()
        {
            Name = Surname = Address = PhoneNumber = "";
        }
    }
}
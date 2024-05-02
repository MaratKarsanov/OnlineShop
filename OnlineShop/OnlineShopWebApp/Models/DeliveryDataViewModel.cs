using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class DeliveryDataViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Введите имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите фамилию")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Введите адрес")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Введите e-mail")]
        [EmailAddress(ErrorMessage = "Некорректный адрес")]
        public string EMail { get; set; }

        [Required(ErrorMessage = "Введите номер телефона")]
        [Phone(ErrorMessage = "Неверный формат номера")]
        public string PhoneNumber { get; set; }

        public DeliveryDataViewModel()
        {
            Name = Surname = Address = EMail = PhoneNumber = "";
        }

        public override string ToString()
        {
            return $"{Surname} {Name}";
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Order : RepositoryItem
    {
        public List<CartItem> Products { get; set; }
        public PersonalData PersonalData { get; set; }

        [Required(ErrorMessage = "Введите адрес")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Введите e-mail")]
        [EmailAddress(ErrorMessage = "Некорректный адрес")]
        public string EMail { get; set; }

        [Required(ErrorMessage = "Введите номер телефона")]
        [Phone(ErrorMessage = "Неверный формат номера")]
        public string PhoneNumber { get; set; }

        public Order()
        {
            Products = new List<CartItem>();
        }

        public override string ToString()
        {
            return $"User name: {PersonalData.Name} {PersonalData.Surname}\nAddress: {Address}\nE-mail: {EMail}\nPhone number: {PhoneNumber}";
        }
    }
}

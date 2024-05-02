using OnlineShop.Db;
using OnlineShopWebApp.Areas.Administrator.Models;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Не указан логин")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Логин должен быть от 3 до 20 символов!")]
        [EmailAddress(ErrorMessage = "Логин должен быть в формате email")]
        public string? Login { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [StringLength(int.MaxValue, MinimumLength = 4, ErrorMessage = "Пароль должен быть длиннее 4 символов!")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Введите имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите фамилию")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Введите адрес")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Введите номер телефона")]
        [Phone(ErrorMessage = "Неверный формат номера")]
        public string PhoneNumber { get; set; }
        public bool RememberMe { get; set; }
        public RoleViewModel Role { get; set; }

        public UserViewModel() : base()
        {
            Role = new RoleViewModel() { Name = "User" };
        }
    }
}

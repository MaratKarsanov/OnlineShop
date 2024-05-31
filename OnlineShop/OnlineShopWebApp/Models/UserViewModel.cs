using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Не указано имя пользователя")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Имя пользователя должно быть от 3 до 20 символов!")]
        [EmailAddress(ErrorMessage = "Логин должен быть в формате email")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [StringLength(int.MaxValue, MinimumLength = 4, ErrorMessage = "Пароль должен быть длиннее 4 символов!")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Введите номер телефона")]
        [Phone(ErrorMessage = "Неверный формат номера")]
        public string PhoneNumber { get; set; }
        public bool LockoutEnabled { get; set; }
        public List<OrderViewModel> Orders { get; set; }
        public string? ImagePath { get; set; } = "/images/Profiles/defaultAvatar.jpg";
        public bool HasProfileImage => ImagePath != "/images/Profiles/defaultAvatar.jpg";
    }
}

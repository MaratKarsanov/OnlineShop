using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class AutorizationData
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Не указан логин")]
        [StringLength(20, MinimumLength = 3,ErrorMessage = "Логин должен быть от 3 до 20 символов!")]
        [EmailAddress(ErrorMessage = "Логин должен быть в формате email")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [StringLength(int.MaxValue, MinimumLength = 4, ErrorMessage = "Пароль должен быть длиннее 4 символов!")]
        public string? Password { get; set; }
        public bool RememberMe { get; set; }
        public string? ReturnUrl { get; set; }

        public override string ToString()
        {
            return $"Логин: {UserName} Пароль: {Password} Запомнить? {RememberMe}";
        }
    }
}
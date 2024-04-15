using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class AutorizationData : RepositoryItem
    {
        [Required(ErrorMessage = "Не указан логин")]
        [StringLength(20, MinimumLength = 3,ErrorMessage = "Логин должен быть от 3 до 20 символов!")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [StringLength(int.MaxValue, MinimumLength = 4, ErrorMessage = "Пароль должен быть длиннее 4 символов!")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }

        public override string ToString()
        {
            return $"Логин: {Login} Пароль: {Password} Запомнить? {RememberMe}";
        }
    }
}
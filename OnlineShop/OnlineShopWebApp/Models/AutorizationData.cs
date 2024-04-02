namespace OnlineShopWebApp.Models
{
    public class AutorizationData
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }

        public override string ToString()
        {
            return $"Логин: {Login} Пароль: {Password} Запомнить? {RememberMe}";
        }
    }
}
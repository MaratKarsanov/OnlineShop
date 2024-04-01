namespace OnlineShopWebApp.Models
{
    public class AutorizationData
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string CheckBoxValue { get; set; }
        public bool RememberMe => CheckBoxValue == "on";

        public override string ToString()
        {
            return $"Логин: {Login} Пароль: {Password} Запомнить? {RememberMe}";
        }
    }
}
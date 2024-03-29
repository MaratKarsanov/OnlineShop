namespace OnlineShopWebApp.Models
{
    public class AutorizationData
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return $"Логин: {Login} Пароль: {Password}";
        }
    }
}
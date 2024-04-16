namespace OnlineShopWebApp.Models
{
    public class User : RepositoryItem
    {
        public PersonalData? PersonalData { get; set; }
        public AutorizationData AutorizationData { get; set; }
    }
}

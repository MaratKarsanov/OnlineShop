using OnlineShopWebApp.Areas.Administrator.Models;

namespace OnlineShopWebApp.Models
{
    public class User : RepositoryItem
    {
        public PersonalData PersonalData { get; set; }
        public AutorizationData AutorizationData { get; set; }
        public Role Role { get; set; }

        public User() : base()
        {
            PersonalData = new PersonalData();
            AutorizationData = new AutorizationData();
            Role = new Role() { Name = "User" };
        }
    }
}

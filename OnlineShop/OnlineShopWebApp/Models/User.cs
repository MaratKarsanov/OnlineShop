namespace OnlineShopWebApp.Models
{
    public class User : RepositoryItem
    {
        public string Name { get; }
        public User(Guid id, string name) : base(id)
        {
            Name = name;
        }
    }
}

namespace OnlineShop.Db.Models
{
    public class Favourites : RepositoryItem
    {
        public string UserId { get; set; }
        public List<Product> Items { get; set; }
        public int Count => Items?.Count ?? 0;

        public Favourites()
        {
            Items = new List<Product>();
        }
    }
}

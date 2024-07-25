namespace OnlineShop.Db.Models
{
    public class Favourites
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public List<Product> Items { get; set; } = new List<Product>();
        public int Count => Items?.Count ?? 0;

        public Favourites()
        {
            Items = new List<Product>();
        }
    }
}

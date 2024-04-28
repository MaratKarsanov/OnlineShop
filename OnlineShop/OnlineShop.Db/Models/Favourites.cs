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

        public void Add(Product product)
        {
            Items.Add(product);
        }

        public void Remove(Guid id)
        {
            var product = Items.FirstOrDefault(p => p.Id == id);
            if (product is not null)
                Items.Remove(product);
        }

        public bool Contains(Product product)
        {
            return Items.Contains(product);
        }
    }
}

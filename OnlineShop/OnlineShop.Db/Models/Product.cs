namespace OnlineShop.Db.Models
{
    public class Product : RepositoryItem
    {
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public string? ImageLink { get; set; }
        public bool IsInFavourities { get; set; }
        public List<CartItem> CartItems { get; set; }

        public Product()
        {
            CartItems = new List<CartItem>();
        }
    }
}
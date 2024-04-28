namespace OnlineShop.Db.Models
{
    public class Product : RepositoryItem
    {
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public string? ImageLink { get; set; }
        public bool IsInFavourites { get; set; }
        public bool IsInComparison { get; set; }
        public List<CartItem> CartItems { get; set; }
        public List<Favourites> Favourites { get; set; }
        public List<ComparisonItem> ComparisonItems { get; set; }

        public Product()
        {
            CartItems = new List<CartItem>();
            Favourites = new List<Favourites>();
            ComparisonItems = new List<ComparisonItem>();
        }
    }
}
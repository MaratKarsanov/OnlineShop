namespace OnlineShop.Db.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; } = "";
        public List<Image> ProductImages { get; set; }
        public List<CartItem> CartItems { get; set; }
        public List<Favourites> Favourites { get; set; }
        public List<Comparison> Comparisons { get; set; }
    }
}
namespace OnlineShop.Db.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public string? ImageLink { get; set; } 
        public bool IsInFavourites { get; set; }
        public bool IsInComparison { get; set; }

        public Product()
        {
            Id = Guid.NewGuid();
            ImageLink = "/images/DefaultImg.jpg";
        }
    }
}
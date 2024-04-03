using System.Text;

namespace OnlineShopWebApp.Models
{
    public class Product : RepositoryItem
    {
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public string ImageLink { get; set; }
        public bool IsInFavourities { get; set; }

        public Product() 
        {

        }

        public Product(string name = "UnknownProduct",
            decimal cost = 0,
            string description = "-",
            string imageLink = "/images/DefaultImg.jpg")
        {
            Id = Guid.NewGuid();
            Name = name;
            Cost = cost;
            Description = description;
            ImageLink = imageLink;
        }

        public override string ToString()
        {
            return $"{Id}\n{Name}\n{Cost}";
        }
    }
}
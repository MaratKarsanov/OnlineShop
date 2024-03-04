using System.Text;

namespace OnlineShopWebApp.Models
{
    public class Product : RepositoryItem
    {
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public Product(string name = "UnknownProduct",
            decimal cost = 0,
            string description = "")
        {
            Id = Guid.NewGuid();
            Name = name;
            Cost = cost;
            Description = description;
        }
        public override string ToString()
        {
            return $"{Id}\n{Name}\n{Cost}";
        }
    }
}
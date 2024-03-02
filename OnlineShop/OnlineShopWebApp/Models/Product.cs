using System.Text;

namespace OnlineShopWebApp.Models
{
    public class Product : IRepositoryItem
    {
        public Guid Id { get; }
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
            var result = new StringBuilder();
            foreach (var property in typeof(Product).GetProperties().Where(p => p.Name != "Description"))
                result.AppendLine($"{property.Name}: {property.GetValue(this)}");
            result.Remove(result.Length - 1, 1);
            return result.ToString();
        }
    }
}
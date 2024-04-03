using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Product : RepositoryItem
    {
        [Required(ErrorMessage = "Не указано имя товара")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указана стоимость товара")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Нет описания")]
        public string Description { get; set; }
        public string ImageLink { get; set; }
        public bool IsInFavourities { get; set; }

        public Product() // без этого конструктора не передаются данные из представления, не трогать!!!
        {
            ImageLink = Constants.ImageLink;
            IsInFavourities = false;
        }

        public Product(string name = "UnknownProduct",
            decimal cost = 0,
            string description = "-",
            string imageLink = "/images/DefaultImg.jpg") : base()
        {
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
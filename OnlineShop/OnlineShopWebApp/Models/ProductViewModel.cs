using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class ProductViewModel : RepositoryItem
    {
        [Required(ErrorMessage = "Не указано имя товара")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указана стоимость товара")]
        [Range(typeof(decimal), "0", "100000000", ErrorMessage = "Цена должна быть положительной!")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Нет описания")]
        public string Description { get; set; }
        public string ImageLink { get; set; }
        public bool IsInFavourities { get; set; }
    }
}
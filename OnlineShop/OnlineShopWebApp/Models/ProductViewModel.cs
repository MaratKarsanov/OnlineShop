using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Не указано имя товара")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указана стоимость товара")]
        [Range(typeof(decimal), "0", "100000000", ErrorMessage = "Цена должна быть положительной!")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Нет описания")]
        public string Description { get; set; }
        public string ImageLink { get; set; }

        public ProductViewModel()
        {
            Id = Guid.NewGuid();
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (obj is not ProductViewModel)
                return false;
            return ((ProductViewModel)obj).Id == Id;
        }
    }
}
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
        public string[] ImagesPaths { get; set; }
        public string ImagePath => ImagesPaths == null || ImagesPaths.Length == 0
                           ? "/images/DefaultImg.jpg"
                           : ImagesPaths[0];
    }
}
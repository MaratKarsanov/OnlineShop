using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Areas.Administrator.Models
{
    public class AddProductViewModel
    {
        [Required(ErrorMessage = "Не указано название товара")]
        [MinLength(2, ErrorMessage = "Название продукта слишком короткое")]
        [MaxLength(100, ErrorMessage = "Название продукта слишком длинное")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указана стоимость товара")]
        [Range(typeof(decimal), "0", "100000000", ErrorMessage = "Цена должна быть положительной!")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Нет описания")]
        [StringLength(1000, ErrorMessage = "Описание продукта слишком длинное")]
        public string Description { get; set; }
        public IFormFile[] UploadedFiles { get; set; }
    }
}

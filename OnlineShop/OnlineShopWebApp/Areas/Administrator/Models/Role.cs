using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Areas.Administrator.Models
{
    public class Role : RepositoryItem
    {
        [Required(ErrorMessage = "Не указано имя")]
        public string Name { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Role : RepositoryItem
    {
        [Required(ErrorMessage = "Не указано имя")]
        public string Name { get; set; }
    }
}

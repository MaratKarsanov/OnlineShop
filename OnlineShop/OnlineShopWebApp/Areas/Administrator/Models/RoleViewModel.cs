using OnlineShop.Db;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Areas.Administrator.Models
{
    public class RoleViewModel : RepositoryItem
    {
        [Required(ErrorMessage = "Не указано имя")]
        public string Name { get; set; }
    }
}

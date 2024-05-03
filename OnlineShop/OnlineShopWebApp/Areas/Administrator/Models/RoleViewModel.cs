using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Areas.Administrator.Models
{
    public class RoleViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        public string Name { get; set; }
    }
}

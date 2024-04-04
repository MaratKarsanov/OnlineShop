using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class PersonalData
    {
        [Required(ErrorMessage = "Введите имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите фамилию")]
        public string Surname { get; set; }
    }
}

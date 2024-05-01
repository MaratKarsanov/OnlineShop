using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Db
{ 
    public class Role : RepositoryItem
    {
        [Required(ErrorMessage = "Не указано имя")]
        public string Name { get; set; }
    }
}

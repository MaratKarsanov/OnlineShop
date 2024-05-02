using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Db
{
    public class Role
    {
        [Key]
        public string Name { get; set; }
    }
}

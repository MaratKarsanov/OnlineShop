using OnlineShop.Db.Models;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Db
{
    public class User
    {
        [Key]
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public bool RememberMe { get; set; }
        public Role Role { get; set; }
        public string RoleName { get; set; }
        public List<DeliveryData> DeliveryDatas { get; set; } = new List<DeliveryData>();
    }
}

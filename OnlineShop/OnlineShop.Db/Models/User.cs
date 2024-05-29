using Microsoft.AspNetCore.Identity;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class User : IdentityUser
    {
        public List<DeliveryData> DeliveryDatas { get; set; } = new List<DeliveryData>();
        public string ProfileImagePath { get; set; } = "/images/Profiles/defaultAvatar.jpg";
    }
}

using Microsoft.AspNetCore.Identity;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class User : IdentityUser
    {
        public string ProfileImagePath { get; set; } = "/images/Profiles/defaultAvatar.jpg";
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;

namespace OnlineShopWebApp.Views.Shared.Components.UserProfile
{
    public class UserViewComponent : ViewComponent
    {
        private readonly UserManager<User> userManager;

        public UserViewComponent(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            try
            {
                var user = userManager.FindByNameAsync(User.Identity.Name).Result;
                return View("User", user.ProfileImagePath);
            }
            catch
            {
                return View("User", "");
            }
        }
    }
}

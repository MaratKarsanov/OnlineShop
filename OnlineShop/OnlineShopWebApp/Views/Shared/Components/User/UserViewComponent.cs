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

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);
                return View("User", user.ProfileImagePath);
            }
            catch
            {
                return View("User", "");
            }
        }
    }
}

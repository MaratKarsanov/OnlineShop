using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Views.Shared.Components.UserProfile
{
    public class UserViewComponent : ViewComponent
    {
        //private readonly IUserRepository userRepository;

        //public UserViewComponent(IUserRepository userRepository)
        //{
        //    this.userRepository = userRepository;
        //}

        public IViewComponentResult Invoke()
        {
            return View("User");
        }
    }
}

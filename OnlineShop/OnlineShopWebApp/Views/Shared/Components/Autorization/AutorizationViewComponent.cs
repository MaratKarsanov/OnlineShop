using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Views.Shared.Components.Autorization
{
    public class AutorizationViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var userLogin = User.Identity.Name;
            return View("Autorization", userLogin);
        }
    }
}

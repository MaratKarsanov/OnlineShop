using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Views.Shared.Components.Autorization
{
    public class AutorizationViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var userLogin = HttpContext.Request.Cookies["userLogin"];
            ViewData["userLogin"] = userLogin;
            return View("Autorization", userLogin);
        }
    }
}

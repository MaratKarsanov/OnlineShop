using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

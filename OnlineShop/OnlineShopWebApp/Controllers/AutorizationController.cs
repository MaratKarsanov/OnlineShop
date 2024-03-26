using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class AutorizationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignIn(AutorizationData autorizationData)
        {
            return View("Success", autorizationData);
        }
    }
}

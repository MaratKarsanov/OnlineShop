using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class AdministratorController : Controller
    {
        public IActionResult ViewOrders()
        {
            return View("Orders");
        }

        public IActionResult ViewUsers()
        {
            return View("Users");
        }

        public IActionResult ViewRoles()
        {
            return View("Roles");
        }

        public IActionResult ViewProducts()
        {
            return View("Products");
        }
    }
}

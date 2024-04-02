using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignUp(RegistrationData registrationData)
        {
            if (ModelState.IsValid)
                return Content(registrationData.ToString());
            return RedirectToAction("Index", "Registration");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Repositories.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class RegistrationController : Controller
    {
        private IUserRepository userRepository;

        public RegistrationController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignUp(RegistrationData registrationData)
        {
            if (!ModelState.IsValid)
                return View(nameof(Index));
            userRepository.Add(new User() 
            { 
                Login = registrationData.Login,
                Password = registrationData.Password,
                Name = registrationData.Name,
                Surname = registrationData.Surname,
                Address = registrationData.Address,
                PhoneNumber = registrationData.PhoneNumber
            });
            return RedirectToAction(nameof(AutorizationController.Index), "Autorization");
        }
    }
}

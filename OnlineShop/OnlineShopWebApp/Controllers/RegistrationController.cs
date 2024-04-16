using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class RegistrationController : Controller
    {
        private IRepository<User> userRepository;

        public RegistrationController(IRepository<User> userRepository)
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
                return RedirectToAction(nameof(Index));
            userRepository.Add(new User() 
            { 
                AutorizationData = new AutorizationData()
                {
                    Login = registrationData.Login,
                    Password = registrationData.Password
                }
            });
            return RedirectToAction(nameof(AutorizationController.Index), "Autorization");
        }
    }
}

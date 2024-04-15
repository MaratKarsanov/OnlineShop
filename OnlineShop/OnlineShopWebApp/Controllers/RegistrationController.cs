using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class RegistrationController : Controller
    {
        private IRepository<AutorizationData> autorizationDataRepository;

        public RegistrationController(IRepository<AutorizationData> autorizationDataRepository)
        {
            this.autorizationDataRepository = autorizationDataRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignUp(RegistrationData registrationData)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(Index));
            autorizationDataRepository.Add(new AutorizationData() 
            { 
                Login = registrationData.Login, 
                Password = registrationData.Password
            });
            return RedirectToAction(nameof(AutorizationController.Index), "Autorization");
        }
    }
}

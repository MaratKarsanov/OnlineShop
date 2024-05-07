using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Repositories.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class RegistrationController : Controller
    {
        private IUserRepository userRepository;
        private IRoleRepository roleRepository;
        private ICartRepository cartRepository;
        private IComparisonRepository comparisonRepository;
        private IFavouritesRepository favouritesRepository;

        public RegistrationController(IUserRepository userRepository,
            IRoleRepository roleRepository,
            ICartRepository cartRepository,
            IComparisonRepository comparisonRepository,
            IFavouritesRepository favouritesRepository)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
            this.cartRepository = cartRepository;
            this.favouritesRepository = favouritesRepository;
            this.comparisonRepository = comparisonRepository;
            if (roleRepository.GetAll().FirstOrDefault(r => r.Name == "Administrator") is null)
            {
                roleRepository.Add(new Role() { Name = "Administrator" });
                roleRepository.Add(new Role() { Name = "User" });
            }
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
                Role = roleRepository.TryGetByName("User"),
                Login = registrationData.Login,
                Password = registrationData.Password,
                Name = registrationData.Name,
                Surname = registrationData.Surname,
                Address = registrationData.Address,
                PhoneNumber = registrationData.PhoneNumber
            });
            cartRepository.AddCart(registrationData.Login);
            comparisonRepository.AddComparison(registrationData.Login);
            favouritesRepository.AddFavourites(registrationData.Login);
            return RedirectToAction(nameof(AutorizationController.Index), "Autorization");
        }
    }
}
